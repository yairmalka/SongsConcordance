using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class SongsLogic : BaseLogic
    {
        public static string allTheWordsInTheDB = "";
        public string Dirpath = "C:\\Projects\\AngularProjectTest\\SongApplication\\TextAppVer2NotOriginal\\Uploads";
        public static List<Song> userListOfSongs = new List<Song>();
        public WordsLogic wLogic;
        public LinguisticExpressionLogic lLogic;
        public PositionLogic psnLogic;
        public SongsLogic(WordsLogic wLogic, LinguisticExpressionLogic linguisticExpressionLogic, PositionLogic psnLogic) //dipendency injection
        {
            this.wLogic = wLogic;
            this.lLogic = linguisticExpressionLogic;
            this.psnLogic = psnLogic;
        }

        public SongsLogic() { }

        public List<SongModel> getAllSongs()
        {
            return db.Songs.Select(s => new SongModel(s)).ToList();
        }

        public SongModel getOneSong(int id)
        {
            return db.Songs.Where(s => s.SongId == id).Select(s => new SongModel(s)).SingleOrDefault();
        }

        public SongModel addSong(IFormFile userSongFile)
        {
            Song song = new Song();
            string extension; // file extension
            if (!Directory.Exists(Dirpath))
                Directory.CreateDirectory(Dirpath);
            
                extension = Path.GetExtension(userSongFile.FileName);
  
            
                string filePath = Path.Combine(Dirpath, Guid.NewGuid() + extension);
            song.FilePath = filePath;

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                userSongFile.CopyTo(fileStream);
            }

            parseTheSong(filePath, song); //fileName == filePath
            userSongFile = null;
            userListOfSongs.Add(song);

            return new SongModel(song);
        }

        private void parseTheSong(string fileName, Song song)
        {
            StreamReader reader = new StreamReader(fileName);
            string line = reader.ReadLine(); 
            string[] songColumns = line.Split(","); // first Line
            song.Artist = songColumns[0]; //Artist name in the file
            song.Title = songColumns[1];
            while(line != null)
            {
                line = reader.ReadLine();
                allTheWordsInTheDB += line;
            }
            allTheWordsInTheDB += "\n";
            reader.Close();
        }

        public SongModel editPartialSong(SongModel songModel)
        {
            Song song = db.Songs.SingleOrDefault(s => s.SongId == songModel.SongId);

            if (song == null)
                return null;
            if (songModel.Year != null)
                song.Year = songModel.Year;
            if(songModel.Album != null)
                song.Album = songModel.Album;
            if(songModel.Genre != null)
                song.Genre = songModel.Genre;

            db.SaveChanges();
            return songModel;
        }
        
        // O(n) instead of O(2^n) => this function walking through the tables returns from the db,
        // if in any situation the table that returns equals to zero, it means all the intersections were not matched
        //and therfore we should return empty list.
        public List<SongModel> findSongsByData(SongModel songModel, string wordsFromText)
        {
            var query = db.Songs.Select(s=> new SongModel(s)).ToList();

                if (!string.IsNullOrEmpty(songModel.Artist))
                {
                query = query.Where(s => s.Artist.ToLower() == songModel.Artist.ToLower()).ToList();
                    if (query.Count() == 0)
                        return new List<SongModel>();
                }

            if (!string.IsNullOrEmpty(songModel.Title))
            {
                query = query.Where(s => s.Title.ToLower() == songModel.Title.ToLower()).ToList();
                if (query.Count() == 0)
                    return new List<SongModel>();
            }
            if (songModel.Year != null && songModel.Year > 0)
            {
                query = query.Where(s => s.Year == songModel.Year).ToList();
                if (query.Count() == 0)
                    return new List<SongModel>();
            }

            if (!string.IsNullOrEmpty(songModel.Album))
            {
                query = query.Where(s => s.Album == songModel.Album).ToList();
                if (query.Count() == 0)
                    return new List<SongModel>();
            }

            if (!string.IsNullOrEmpty(songModel.Genre))
            {
                query = query.Where(s => s.Genre == songModel.Genre).ToList();
                if (query.Count() == 0)
                    return new List<SongModel>();
            }

            if (!string.IsNullOrEmpty(wordsFromText))
            {
                List<SongAndPositionModel> tableOfSongsWithTheWordsThatMatchTheUserWordsInput = lLogic.findLinguisticExpressions(wordsFromText);
                if (tableOfSongsWithTheWordsThatMatchTheUserWordsInput.Count() == 0)
                    return new List<SongModel>();

                else
                {
                    query = (from sng in query
                             join sng2 in tableOfSongsWithTheWordsThatMatchTheUserWordsInput
                             on sng.SongId equals sng2.SongId
                             where sng.SongId == sng2.SongId
                             select new SongModel
                             {
                                 SongId = sng.SongId,
                                 Artist = sng.Artist,
                                 Title = sng.Title,
                                 Year = sng.Year,
                                 Album = sng.Album,
                                 Genre = sng.Genre,
                                 FilePath = sng.FilePath
                             }).DistinctBy(s => s.SongId).ToList();
                }
            }

            return query;

        }

        public void makeAllSongsLyricFile()
        {
            List<string?> allFilesPathsList = db.Songs.Select(s => s.FilePath).ToList();
            saveToDataBase(userListOfSongs); // saving all the user list of songs to db and not one by one (reducing time)
                string allWordsInCurrentFilesLoadtxt = Dirpath + "\\allWordsInCurrentFilesLoad.txt";
            foreach (string file in Directory.EnumerateFiles(Dirpath, "*.txt"))
            {
                if ((!file.Equals(allWordsInCurrentFilesLoadtxt)) && (!allFilesPathsList.Contains(file))) //if te file isn't the file allWordsInTheDB.txt accidently, because this file is in the same DIR and we dont want to access it accidently and,
                                                                                               //if the file has already in the db, don't do anything with it. but if it is not, so load his data to the alldbWords text.
                {
                    var lines = File.ReadLines(file).Skip(1);
                    File.AppendAllLines(allWordsInCurrentFilesLoadtxt, lines);
                }
            }
            StreamReader reader = new StreamReader(allWordsInCurrentFilesLoadtxt);
            string allWordsInCurrentFilesLoad = reader.ReadToEnd();
            reader.Close();
            wLogic.startFillDataBaseTables(allWordsInCurrentFilesLoad.ToLower());

            File.WriteAllText(allWordsInCurrentFilesLoadtxt, string.Empty); // removes all the content of the all allWordsInTheDBtxt for next files insertions
            userListOfSongs.Clear(); // clear the content of the list for next files insertions
            lLogic.updateExpressionsOccurrences(); // this updated all the expressions table and their occurences because maybe 
                                                   // the Occurrences number had chenged due to last insertions.
        }

        public string getSongLyricByID(int songId)
        {
            string fileName = db.Songs.Where(s => s.SongId == songId).Select(s => s.FilePath).SingleOrDefault();
            StreamReader reader = new StreamReader(fileName);
            string songLyric = "";
            string line = reader.ReadLine();
            while (line != null)
            {
                line = reader.ReadLine();
                songLyric = songLyric + line + "\n";
            }
            reader.Close();
            return songLyric;
        }


        public StatisticalDataModel getSongStatisticalData(int songID)
        {
            StatisticalDataModel songStatisticalData = new StatisticalDataModel();
            List<Position> allTheWordsInTheSong = db.Positions.Where(p => p.SongId == songID).ToList();
            songStatisticalData.LongestWord = findTheLongestWordInTheSong(songID, allTheWordsInTheSong);
            songStatisticalData.ShortestWord = findTheShortestWordInTheSong(songID, allTheWordsInTheSong);
            songStatisticalData.WordsAvgLength = songWordsLengthAvg(songID, allTheWordsInTheSong);
            songStatisticalData.HowMuchWordsInTheSong = allTheWordsInTheSong.Count;
            songStatisticalData.howMuchWordsInVerses = calculateHowMuchWordsInEachVerse(songID, allTheWordsInTheSong);
            songStatisticalData.howMuchWordsInSentences = calculateHowMuchWordsInSentences(songID, allTheWordsInTheSong);
            songStatisticalData.wordsAppearsTheMostInTheSong = theMostAppearsWorsdInTheSong(songID, allTheWordsInTheSong);

            return songStatisticalData;
        }

        private List<string?> theMostAppearsWorsdInTheSong(int songID, List<Position> allTheWordsInTheSong)
        {
        int NUM_OF_WORDS = 10;
        List<string?> tenMostWords = allTheWordsInTheSong
            .GroupBy(p => p.WordValue)
            .Where(p => p.Count() > 1)
            .OrderByDescending(p => p.Count())
            .Select(p => p.Key).Take(NUM_OF_WORDS).ToList();

            return tenMostWords;
        }


        //FIX IT: SOME ISSUE WITH THE "" ( PRESENTS 0 SOMEWHERE - PLEASE DUBUG)
        private List<int> calculateHowMuchWordsInSentences(int songID, List<Position> allTheWordsInTheSong)
        {
            List<int> howMuchWordsInSentences = new List<int>();
            int numOfWords = 0;
            int sentenceIndex = 1;
            foreach (Position word in allTheWordsInTheSong)
            {
                if (word.SentenceNumber == sentenceIndex)
                    numOfWords++;
                else
                {
                        howMuchWordsInSentences.Add(numOfWords);
                        numOfWords = 1;
                        sentenceIndex += 1;
                }
            }
            howMuchWordsInSentences.Add(numOfWords);
            return howMuchWordsInSentences;
        }

        private List<int> calculateHowMuchWordsInEachVerse(int songID, List<Position> allTheWordsInTheSong)
        {
            List<int> howMuchWordsInVerses = new List<int>();
            int numOfWords = 0;
            int verseIndex = 1;
            foreach(Position word in allTheWordsInTheSong)
            {
                if (word.VerseNumber == verseIndex)
                    numOfWords++;
                else
                {
                    howMuchWordsInVerses.Add(numOfWords);
                    numOfWords = 1;
                    verseIndex += 1;
                }
            }
            howMuchWordsInVerses.Add(numOfWords); // to not avoid missing the last verse
            return howMuchWordsInVerses;
        }

        private float songWordsLengthAvg(int songID, List<Position> allTheWordsInTheSong)
        {
            float sumOfLength = 0;
            foreach(Position position in allTheWordsInTheSong)
                sumOfLength += position.WordValue.Length;

            if(allTheWordsInTheSong.Count > 0)
                return (float)(sumOfLength / allTheWordsInTheSong.Count);

            return -999;
        }

        private string findTheLongestWordInTheSong(int songID, List<Position> allTheWordsInTheSong)
        {
         
            string longestWord = "";
            foreach (Position p in allTheWordsInTheSong)
            {
                if (p.WordValue.Length > longestWord.Length)
                    longestWord = p.WordValue;
            }
            return longestWord;
        }

        private string findTheShortestWordInTheSong(int songID,List<Position> allTheWordsInTheSong)
        {
            {
                string shortestWord = allTheWordsInTheSong[0].WordValue;
                foreach (Position p in allTheWordsInTheSong)
                {
                    if (p.WordValue.Length < shortestWord.Length)
                        shortestWord = p.WordValue;
                }
                return shortestWord;
            }
        }
    }
}