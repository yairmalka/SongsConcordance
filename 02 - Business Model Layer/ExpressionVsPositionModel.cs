using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class ExpressionVsPositionModel {

        public int ExpressionVsPositionId { get; set; }
        public int? ExpressionId { get; set; }
        public int? PositionId { get; set; }



        public ExpressionVsPositionModel() { }

        public ExpressionVsPositionModel(ExpressionsVsPosition expVsPos)
        {
            ExpressionVsPositionId = expVsPos.ExpressionVsPositionId;
            ExpressionId = expVsPos.ExpressionId;
            PositionId = expVsPos.PositionId;
        }

    }

}

