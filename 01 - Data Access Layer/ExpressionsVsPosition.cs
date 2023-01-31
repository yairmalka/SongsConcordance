using System;
using System.Collections.Generic;

namespace DbProject
{
    public partial class ExpressionsVsPosition
    {
        public int ExpressionVsPositionId { get; set; }
        public int? ExpressionId { get; set; }
        public int? PositionId { get; set; }

        public virtual LinguisticExpression? Expression { get; set; }
        public virtual Position? Position { get; set; }
    }
}
