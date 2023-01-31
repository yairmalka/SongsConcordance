using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public  class WordModel
    {

        public int WordId { get; set; }
        public int SongId { get; set; }
        public string? WordValue { get; set; }
        public int? WordLength { get; set; }
        public int? WordCount { get; set; }


        public WordModel(Word word)
        {
            this.WordId = word.WordId;
            this.SongId = word.SongId;
            this.WordValue = word.WordValue;
            this.WordLength = word.WordLength;
            this.WordCount = word.WordCount;
    }


    }


}
