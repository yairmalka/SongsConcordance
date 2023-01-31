using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class LinguisticExpressionModel
    {
        public int ExpressionId { get; set; }
        public string? ExpressionValue { get; set; }
        public bool? ExpressionExist { get; set; }
        public int? ExpressionOccurrences { get; set; }

        public LinguisticExpressionModel(LinguisticExpression le)
        {
            ExpressionId = le.ExpressionId;
            ExpressionValue = le.ExpressionValue;
            ExpressionExist = le.ExpressionExist;
            ExpressionOccurrences = le.ExpressionOccurrences;
        }

        public LinguisticExpressionModel() { }

    }

}
