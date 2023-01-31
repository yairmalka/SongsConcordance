using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DbProject
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireWorld")]
    public class WordsVsGroupsController : ControllerBase
    {
        public WordsVsGroupLogic wrdsVsGrpLogic;

        public WordsVsGroupsController(WordsVsGroupLogic wrdsVsGrpLogic)
        {
            this.wrdsVsGrpLogic = wrdsVsGrpLogic;
        }
        
        [HttpPost]
        public IActionResult addWordsToGivenGroup(WordVsGroupModel wordVsGroupModel)
        {
            try
            {
                WordVsGroupModel wordVsGroupToAdd = wrdsVsGrpLogic.addWordsToGivenGroup(wordVsGroupModel);
                if(wordVsGroupToAdd == null)
                    return NotFound(wordVsGroupModel.GroupName + " hasn't found or "+ wordVsGroupModel.WordValue + " hasn't found");
                return Created("/api/WordsVsGroups/" + wordVsGroupToAdd.ID, wordVsGroupToAdd);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        // actually I don't need this function for the controller, just for tests
        [HttpGet]
        public IActionResult getAllWordsVsGroups()
        {
            try
            {
                List<WordVsGroupModel> allWordsVsGroupModel = wrdsVsGrpLogic.getAllWordsVsGroups();
                return Ok(allWordsVsGroupModel);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getWordsVsGroupsByGroupID/{groupID}")]
        public IActionResult getWordsVsGroupsByGroupID(int groupID)
        {
            try
            {
                List<WordVsGroupModel> allWordsVsGroupModel = wrdsVsGrpLogic.getWordsVsGroupsByGroupID(groupID);
                return Ok(allWordsVsGroupModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
