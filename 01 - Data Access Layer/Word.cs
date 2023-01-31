using System;
using System.Collections.Generic;

namespace DbProject
{
    public partial class Word
    {
        public Word()
        {
            WordsVsGroups = new HashSet<WordsVsGroup>();
        }

        public int WordId { get; set; }
        public int SongId { get; set; }
        public string? WordValue { get; set; }
        public int? WordLength { get; set; }
        public int? WordCount { get; set; }

        public virtual Song Song { get; set; } = null!;
        public virtual ICollection<WordsVsGroup> WordsVsGroups { get; set; }
    }
}
