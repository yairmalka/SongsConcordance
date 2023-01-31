using System;
using System.Collections.Generic;

namespace DbProject
{
    public partial class Position
    {
        public Position()
        {
            ExpressionsVsPositions = new HashSet<ExpressionsVsPosition>();
        }

        public int PositionId { get; set; }
        public string? WordValue { get; set; }
        public int SongId { get; set; }
        public int? WordIndex { get; set; }
        public int? SentenceNumber { get; set; }
        public int? VerseNumber { get; set; }

        public virtual Song Song { get; set; } = null!;
        public virtual ICollection<ExpressionsVsPosition> ExpressionsVsPositions { get; set; }
    }
}
