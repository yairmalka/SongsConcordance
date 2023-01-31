
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DbProject
{
    public partial class Song
    {
        public Song()
        {
            Positions = new HashSet<Position>();
            Words = new HashSet<Word>();
        }
        public int SongId { get; set; }
        public string Artist { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int? Year { get; set; }
        [XmlElement(IsNullable = true)]
        public string? Album { get; set; }
        [XmlElement(IsNullable = true)]
        public string? Genre { get; set; }
        public string? FilePath { get; set; }

        [XmlIgnore]
        public virtual ICollection<Position> Positions { get; set; }
        [XmlIgnore]
        public virtual ICollection<Word> Words { get; set; }
    }
}

