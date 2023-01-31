using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class ExpressionVsPositionLogic: BaseLogic
    {
        public LinguisticExpressionLogic linguisticExpressionLogic;
        public ExpressionVsPositionLogic(LinguisticExpressionLogic linguisticExpressionLogic)
        {
            this.linguisticExpressionLogic = linguisticExpressionLogic;
        }

        public List<ExpressionVsPositionModel> getAllExpressionVsPosition()
        {
            return db.ExpressionsVsPositions.Select(e=> new ExpressionVsPositionModel(e)).ToList();
        }

        public List<SongAndPositionModel> getFullDataOfExpression(int expressionId)
        {
            List<ExpressionsVsPosition> listOfExpressionsAndPositions = getPositionsOfExpressionsByExpressionId(expressionId);
            // querhy that return the expressionsPositions but in anonymous type
            var expressionsPositions = (from p in listOfExpressionsAndPositions
                         join psn in db.Positions on p.PositionId equals psn.PositionId
                         select new Position
                         {
                             PositionId = psn.PositionId,
                             SongId = psn.SongId,
                             WordValue = psn.WordValue,
                             WordIndex = psn.WordIndex,
                             SentenceNumber = psn.SentenceNumber,
                             VerseNumber = psn.VerseNumber,
                         }).ToList();

            return this.linguisticExpressionLogic.convertToSongAndPositionModel(expressionsPositions);
        }

        private List<ExpressionsVsPosition> getPositionsOfExpressionsByExpressionId(int expressionId)
        {
            return db.ExpressionsVsPositions.Where(exp => exp.ExpressionId == expressionId).ToList();
        }

    }
}
