using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class LinguisticExpressionLogic : BaseLogic
    {

        public List<LinguisticExpressionModel> getAllExpressions()
        {
            return db.LinguisticExpressions.Select(e => new LinguisticExpressionModel(e)).ToList();
        }

        public LinguisticExpressionModel getOneLinguisticExpression(int expressionId)
        {
            return db.LinguisticExpressions.Where(exp => exp.ExpressionId == expressionId).Select(exp => new LinguisticExpressionModel(exp)).SingleOrDefault();
        }

        //this method also include automatic adding to expVsPos table for each expression that exists in the db===============
        public LinguisticExpressionModel addLinguisticExpression(LinguisticExpressionModel linguisticExpressionModel)
        {
            LinguisticExpression lngExpressionRaw = new LinguisticExpression();

            lngExpressionRaw.ExpressionValue = linguisticExpressionModel.ExpressionValue.ToLower();
            lngExpressionRaw.ExpressionValue = linguisticExpressionModel.ExpressionValue;
            List<SongAndPositionModel> expresionsWithPositionsToFillExpVsPosTable = findLinguisticExpressions(linguisticExpressionModel.ExpressionValue);
            lngExpressionRaw.ExpressionOccurrences = expresionsWithPositionsToFillExpVsPosTable.Count();
            if (lngExpressionRaw.ExpressionOccurrences > 0)
            {
                lngExpressionRaw.ExpressionExist = true;
            }
            else
                lngExpressionRaw.ExpressionExist = false;

            db.LinguisticExpressions.Add(lngExpressionRaw);
            db.SaveChanges();
            linguisticExpressionModel.ExpressionId = lngExpressionRaw.ExpressionId;

//=======all of this code is for the filling Expression Vs Position Table================================
            List<ExpressionsVsPosition> expressionsVsPositionList = new List<ExpressionsVsPosition>();
            foreach (var exp in expresionsWithPositionsToFillExpVsPosTable)
            {
                ExpressionsVsPosition expressionsVsPositionRow = new ExpressionsVsPosition
                {
                    ExpressionId = lngExpressionRaw.ExpressionId,
                    PositionId = exp.PositionId
                };
                expressionsVsPositionList.Add(expressionsVsPositionRow);
            }
            if(expressionsVsPositionList.Count() > 0)
                saveToDataBase(expressionsVsPositionList);
 //=======all of this code is for the filling Expression Vs Position Table================================
            
            return new LinguisticExpressionModel(lngExpressionRaw);
        }

        public List<SongAndPositionModel> findLinguisticExpressions(string linguisticExpression)
        {
            linguisticExpression = linguisticExpression.ToLower();
            int matchedWords = 0; // number of matched words row after row.
            string[] linguisticExpressionWords = linguisticExpression.Split(' ');
            int numberOfWordsInThExpression = linguisticExpressionWords.Length;
            List<Position> allWordPositoins = db.Positions.ToList();
            List<Position> relevantWords = allWordPositoins.Where(p => p.WordValue.Equals(linguisticExpressionWords[0])).ToList();
            List<Position> relevantExactExpression = new List<Position>();
            if (relevantWords.Count() > 0)
            {
                matchedWords++;
                foreach (Position wordPosition in relevantWords)
                {
                    for (int i = 1; i < numberOfWordsInThExpression; i++)
                    {
                        int? nextID = wordPosition.PositionId + i;
                        if (nextID > allWordPositoins.Last().PositionId) // it means we arrive the last songID, the other one will be null for sure so break here.
                            break;
                        string nextWord = allWordPositoins.Where(p => p.PositionId == nextID).SingleOrDefault().WordValue;

                        if (linguisticExpressionWords[i].Equals(nextWord))
                            matchedWords++;
                    }
                    if (matchedWords == numberOfWordsInThExpression)
                        relevantExactExpression.Add(wordPosition);
                    matchedWords = 1;
                }
                return convertToSongAndPositionModel(relevantExactExpression);
            }
            return new List<SongAndPositionModel>();
        }

        public List<SongAndPositionModel> convertToSongAndPositionModel(List<Position> relevantExactExpression)
        {
            List<SongAndPositionModel> res = (from psn in relevantExactExpression
                         join sng in db.Songs on psn.SongId equals sng.SongId
                         select new SongAndPositionModel
                         {
                             SongId = sng.SongId,
                             PositionId = psn.PositionId,
                             Artist = sng.Artist,
                             Title = sng.Title,
                             WordIndex = psn.WordIndex,
                             SentenceNumber = psn.SentenceNumber,
                             VerseNumber = psn.VerseNumber,
                             ArtistAndTitle = sng.Artist + " - " + sng.Title
                         }).ToList();
            return res;

        }

        // this method occurs after adding new song to the db, therfore need to update the occourences.
        public void updateExpressionsOccurrences()
        {
            List<LinguisticExpression> listToUpdate = db.LinguisticExpressions.ToList();
            if (listToUpdate.Count > 0)
            {
                for (int i = 0; i < listToUpdate.Count; i++)
                {
                    listToUpdate[i].ExpressionOccurrences = findLinguisticExpressions(listToUpdate[i].ExpressionValue).Count();
                }
                db.SaveChanges();
            }
        }


    }
}