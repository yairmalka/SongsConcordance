using System;
using System.Collections.Generic;

namespace DbProject
{
    public partial class LinguisticExpression
    {
        public LinguisticExpression()
        {
            ExpressionsVsPositions = new HashSet<ExpressionsVsPosition>();
        }

        public int ExpressionId { get; set; }
        public string? ExpressionValue { get; set; }
        public bool? ExpressionExist { get; set; }
        public int? ExpressionOccurrences { get; set; }

        public virtual ICollection<ExpressionsVsPosition> ExpressionsVsPositions { get; set; }
    }
}
