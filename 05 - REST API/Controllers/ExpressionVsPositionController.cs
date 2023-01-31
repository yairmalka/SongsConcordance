using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbProject
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireWorld")]
    public class ExpressionVsPositionController : ControllerBase
    {
        public ExpressionVsPositionLogic expVsPsnLogic;

        public ExpressionVsPositionController(ExpressionVsPositionLogic expVsPsnLogic)
        {
            this.expVsPsnLogic = expVsPsnLogic;
        }

        [HttpGet]
        public IActionResult getAllExpressionVsPosition()
        {
            try
            {
                List<ExpressionVsPositionModel> expressionsAndTheirPositions = this.expVsPsnLogic.getAllExpressionVsPosition();
                return Ok(expressionsAndTheirPositions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("getFullDataOfExpression/{expressionId}")]
        public IActionResult getFullDataOfExpression(int expressionId)
        {
            try
            {
                List<SongAndPositionModel> expressionsAndTheirPositions = this.expVsPsnLogic.getFullDataOfExpression(expressionId);
                return Ok(expressionsAndTheirPositions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

    }
}
