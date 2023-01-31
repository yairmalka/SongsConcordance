using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class PositionModel
    {
        public int PositionId { get; set; }
        public int SongId { get; set; }
        public string? WordValue { get; set; }
        public int? WordIndex { get; set; }
        public int? SentenceNumber { get; set; }
        public int? VerseNumber { get; set; }


        public PositionModel(Position position)
        {
            PositionId = position.PositionId;
            SongId = position.SongId;
            WordValue = position.WordValue;
            WordIndex = position.WordIndex;
            SentenceNumber = position.SentenceNumber;
            VerseNumber = position.VerseNumber;
        }

        public PositionModel() { }
    }

    
}
