using System;
using System.Collections.Generic;

namespace DbProject
{
    public partial class WordsVsGroup
    {
        public int WordVsGroupId { get; set; }
        public int GroupId { get; set; }
        public int WordId { get; set; }
        public string? WordValue { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual Word Word { get; set; } = null!;
    }
}
