using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class SongAndPositionModel
    {

        public int SongId { get; set; }
        public int PositionId { get; set; }
        public string Artist { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? WordValue { get; set; }
        public string? ArtistAndTitle { get; set; }
        public int? WordIndex { get; set; }
        public int? SentenceNumber { get; set; }
        public int? VerseNumber { get; set; }

        //public SongAndPositionModel(int songId,int positionId, string artist, string title, string? wordValue)
        //{
        //    PositionId = positionId;
        //    SongId = songId;
        //    Artist = artist;
        //    Title = title;
        //    WordValue = wordValue;
        //}

        public SongAndPositionModel()
        {

        }

    }
}
