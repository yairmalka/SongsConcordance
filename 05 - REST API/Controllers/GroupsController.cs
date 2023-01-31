using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbProject
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireWorld")]
    public class GroupsController : ControllerBase
    {
        public GroupLogic groupLogic;
        public GroupsController(GroupLogic groupLogic)
        {
            this.groupLogic = groupLogic;
        }

        [HttpPost]
        public IActionResult addGroup(GroupModel groupModel)
        {
            try
            {
                GroupModel groupToAdd = groupLogic.addGroup(groupModel);
                return Created("api/Groups/" + groupToAdd.GroupId, groupToAdd);
            }

            catch(Exception ex)
            {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult getAllGroups()
        {
            try
            {
                List<GroupModel> groups = this.groupLogic.getAllGroups();
                return Ok(groups);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
