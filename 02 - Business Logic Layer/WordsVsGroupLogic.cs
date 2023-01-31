using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class WordsVsGroupLogic : BaseLogic
    {

        public WordVsGroupModel addWordsToGivenGroup(WordVsGroupModel wordVsGroupModel)
        {
            WordsVsGroup wordsVsGroupRow = new WordsVsGroup();
            if (wordVsGroupModel.GroupName != null && wordVsGroupModel.WordValue != null) 
            {
                wordVsGroupModel.GroupName = wordVsGroupModel.GroupName.ToLower();
                wordVsGroupModel.WordValue = wordVsGroupModel.WordValue.ToLower();
                
                Group groupRow;
                Word wordRow;

                groupRow = db.Groups.AsQueryable().Where(p => p.GroupName.Equals(wordVsGroupModel.GroupName)).SingleOrDefault();
                wordRow = db.Words.AsQueryable().Where(p => p.WordValue.Equals(wordVsGroupModel.WordValue)).SingleOrDefault();

                if (groupRow != null && groupRow.GroupId > 0 && wordRow != null)
                {
                    wordsVsGroupRow.GroupId = groupRow.GroupId;
                    wordsVsGroupRow.WordValue = wordRow.WordValue;
                    wordsVsGroupRow.WordId = wordRow.WordId;
                }
                else
                    return null;

                db.WordsVsGroups.Add(wordsVsGroupRow);
                db.SaveChanges();
                wordVsGroupModel.ID = wordsVsGroupRow.WordVsGroupId;
                return wordVsGroupModel;
            }
            return null;
        }

        public List<WordVsGroupModel> getAllWordsVsGroups()
        {
            List<WordVsGroupModel> res = (from grp in db.Groups
                                              join wVg in db.WordsVsGroups on grp.GroupId equals wVg.GroupId
                                              select new WordVsGroupModel
                                              {
                                              GroupId = grp.GroupId,
                                              WordId = wVg.WordId,
                                              GroupName = grp.GroupName,
                                              WordValue = wVg.WordValue,
                                              }).ToList();
            return res;
        }

        public List<WordVsGroupModel> getWordsVsGroupsByGroupID(int groupID)
        {
            List<WordVsGroupModel> WordsVsGroupsByGroupID = (from grp in db.Groups
                                          join wVg in db.WordsVsGroups on grp.GroupId equals wVg.GroupId
                                          where grp.GroupId == groupID
                                          select new WordVsGroupModel
                                          {
                                              GroupId = grp.GroupId,
                                              WordId = wVg.WordId,
                                              GroupName = grp.GroupName,
                                              WordValue = wVg.WordValue,
                                          }).ToList();
            return WordsVsGroupsByGroupID;
        }

        
    }
}