using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbProject
{
    [Route("api/[controller]")]
    [EnableCors("EntireWorld")]
    [ApiController]
    public class LinguisticExpressionsController : ControllerBase
    {
        public LinguisticExpressionLogic lingExpLogic;

        public LinguisticExpressionsController( LinguisticExpressionLogic lingExpLogic)
        {
            this.lingExpLogic = lingExpLogic;
        }

        [HttpGet]
        public IActionResult getAllExpressions()
        {
            try
            {
                List<LinguisticExpressionModel> expressions = lingExpLogic.getAllExpressions();
                return Ok(expressions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("{expressionId}")]
        public IActionResult getOneLinguisticExpression(int expressionId)
        {
            try
            {
                LinguisticExpressionModel expression = this.lingExpLogic.getOneLinguisticExpression(expressionId);
                return Ok(expression);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult addLinguisticExpression(LinguisticExpressionModel linguisticExpression)
        {
            try
            {
                LinguisticExpressionModel expressionModelToAdd = lingExpLogic.addLinguisticExpression(linguisticExpression);
                return Created("api/LinguisticExpression/" + expressionModelToAdd.ExpressionId, expressionModelToAdd);
            }

            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("findLinguisticExpressions/{expression}")]
        public IActionResult findLinguisticExpressions(string expression)
        {
            try
            {
                List<SongAndPositionModel> words = this.lingExpLogic.findLinguisticExpressions(expression);
                return Ok(words);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
