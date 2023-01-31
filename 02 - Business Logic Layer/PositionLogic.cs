using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DbProject
{
    public class PositionLogic : BaseLogic
    {
        public PositionLogic() 
        {
        }

        public void addingDataToPositionTables(Song song)
        {
            List<Position> positions = new List<Position>();
            StreamReader reader = new StreamReader(song.FilePath);
            int wordIndex = 1;
            int sentenceIndex = 1;
            int verseIndex = 1;
            string line = reader.ReadLine();
            while (line != null)
            {
                line = reader.ReadLine();
                
                if (line == "")
                {
                    verseIndex++;
                    continue;
                }
                if (line == null)   //end of song
                    break;

                string[] splited_line = line.ToLower().Split(words_delimiters, StringSplitOptions.None);
                for (int i = 0; i < splited_line.Length; i++)
                {
                    if (splited_line[i] != "") 
                    {
                        Position pos = new Position();
                        pos.SongId = song.SongId;
                        pos.WordValue = splited_line[i];
                        pos.WordIndex = wordIndex;
                        pos.VerseNumber = verseIndex;
                        pos.SentenceNumber = sentenceIndex;
                        wordIndex++;
                        positions.Add(pos);
                    }
                }
                sentenceIndex++;
            }
            reader.Close();
            saveToDataBase(positions);
            WordsLogic wrdLogic = new WordsLogic();
            wrdLogic.updateWordsCounter();
        }

        //============================FROM HERE: FUNCTIONS TO THE REST API LAYER============================

        public List<PositionModel> getAllWordsPositions()
        {
            
            return db.Positions.Select(p => new PositionModel(p)).ToList();
        }

        public List<PositionModel> getAllThePositionsOfOneSong(int songID)
        {
            return db.Positions.Where(p=> p.SongId == songID).Select(p=> new PositionModel(p)).ToList();
        }

        public PositionModel getOneWordPosition(int positionId)
        {
            return db.Positions.Where(p => p.PositionId == positionId).Select(p => new PositionModel(p)).SingleOrDefault();
        }

        public List<SongAndPositionModel> findWordByIndex(int wordIndex, int sentenceNumber, int verseNumber)
        {

            List<SongAndPositionModel> words = (from psn in db.Positions
                         join sng in db.Songs on psn.SongId equals sng.SongId
                         where psn.SentenceNumber == sentenceNumber &&
                               psn.VerseNumber == verseNumber &&
                               psn.WordIndex == wordIndex
                         orderby sng.SongId
                         select new SongAndPositionModel
                         {
                            SongId = sng.SongId,
                            PositionId = psn.PositionId,
                            Artist = sng.Artist,
                            Title = sng.Title,
                            WordValue = psn.WordValue
                         }).ToList();

            return words;

        }

        public List<PositionModel> getBriefOfWordPosition(int PositionId)
        {
            PositionModel desiredPositionModel = getOneWordPosition(PositionId);
            string res = "";
                 
            List<PositionModel> desiredWordVerses = (from psn in db.Positions
                                     where psn.SongId == desiredPositionModel.SongId &&
                                          (psn.VerseNumber == desiredPositionModel.VerseNumber ||
                                           psn.VerseNumber + 1 == desiredPositionModel.VerseNumber ||
                                           psn.VerseNumber -1 == desiredPositionModel.VerseNumber)
                                     select new PositionModel
                                     {
                                      PositionId = psn.PositionId,
                                      SongId = psn.SongId,
                                      WordValue = psn.WordValue,
                                      WordIndex = psn.WordIndex,
                                      SentenceNumber = psn.SentenceNumber,
                                      VerseNumber = psn.VerseNumber
                                     }).ToList();

            return desiredWordVerses;
        }

    }
}