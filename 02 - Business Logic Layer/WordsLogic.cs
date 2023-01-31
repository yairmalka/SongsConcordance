using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class WordsLogic : BaseLogic
    {
        PositionLogic position = new PositionLogic();
        List<Word> words = new List<Word>();
        
        public void startFillDataBaseTables(string allWordsInCurrentFilesLoad)
        {
            songs = db.Songs.AsQueryable().Where(id => id.SongId > 0).ToList(); //returns the whole tables of the whole songs dataBase
            int lastSongId = songs.Last().SongId;

            foreach (Song song in songs)
            {
                int songIDalreadyLocatedInPositionsTable = db.Positions.Where(p => p.SongId == song.SongId).Count();
                if (songIDalreadyLocatedInPositionsTable == 0)
                {
                    addToWordsDbTable(song, lastSongId);
                    position.addingDataToPositionTables(song);
                }
            }
        }

        private void addToWordsDbTable(Song song, int lastSongId)
        {
            StreamReader reader = new StreamReader(song.FilePath);
            string line = reader.ReadLine();
            while (line != null)
            {
                line = reader.ReadLine();
                if (line == null)
                    break;
                string[] splited_line = line.ToLower().Split(words_delimiters, StringSplitOptions.None);
                for(int i = 0; i < splited_line.Length; i++)
                {
                    if (splited_line[i] != "")
                    {
                        Word word = new Word();
                        word.WordValue = splited_line[i].ToLower();
                        word.SongId = song.SongId;
                        word.WordLength = splited_line[i].Length;
                        words.Add(word);
                    }
                }

            }
            reader.Close();
            if(song.SongId == lastSongId)
            {
                HashSet<Word> words_hash_set = words.ToHashSet();
                List<string> allWordsOfWordsTable = db.Words.Select(w => w.WordValue).ToList();
                List<Word> only_words_to_add_list = new List<Word>();
                foreach (Word word in words_hash_set)
                {
                    if (!allWordsOfWordsTable.Contains(word.WordValue))
                            only_words_to_add_list.Add(word);
                }
                saveToDataBase(only_words_to_add_list);
            }
        }

        // this one will happend after the position table will be filled for easier solution rather than harder query
        public void updateWordsCounter()
        {
            List<Position> allWordsPositions = db.Positions.ToList();
            List<Word> all_words = db.Words.ToList();
            for(int i=0; i< all_words.Count(); i++)
                all_words[i].WordCount = allWordsPositions.Where(p=> p.WordValue.Equals(all_words[i].WordValue)).ToList().Count();
            db.SaveChanges();
        }

        //========================From here REST API code====================================================

        public List<WordModel> getAllWords()
        {
            return db.Words.OrderByDescending(w=> w.WordCount).Select(w=> new WordModel(w)).ToList();
        }

        public List<WordModel> getWordsOfOneSong(int songID)
        {
            return db.Words.Where(s => s.SongId == songID).Select(w => new WordModel(w)).ToList();
        }

    }
   
}