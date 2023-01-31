using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbProject
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireWorld")]
    public class PositionsController : ControllerBase
    {
        public PositionLogic psnLogic;
        public LinguisticExpressionLogic lingExpLogic;

        public PositionsController(PositionLogic psnLogic, LinguisticExpressionLogic lingExpLogic)
        {
            this.psnLogic = psnLogic;
            this.lingExpLogic = lingExpLogic;
        }

        [HttpGet]
        public IActionResult getAllWordsPositions()
        {
            try
            {
                List<PositionModel> wordsPositions = psnLogic.getAllWordsPositions();
                return Ok(wordsPositions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{positionId}")]
        public IActionResult getOneWordPosition(int positionId)
        {
            try
            {
                PositionModel positionModel = this.psnLogic.getOneWordPosition(positionId);
                return Ok(positionModel);
            }

            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("findWordByIndex/WordIndex/{wordIndex}/SentenceNumber/{sentenceNumber}/VerseNumber/{verseNumber}")]
        public IActionResult findWordByIndex(int wordIndex, int sentenceNumber, int verseNumber)
        {
            try
            {
                List<SongAndPositionModel> words = psnLogic.findWordByIndex(wordIndex, sentenceNumber, verseNumber);
                return Ok(words);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getBrief/{positionID}")]
        public IActionResult getBriefOfWordPosition(int positionID)
        {
            try
            {
                List<PositionModel> brief = psnLogic.getBriefOfWordPosition(positionID);
                return Ok(brief);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllThePositionsOfOneSong/{songID}")]
        public IActionResult getAllThePositionsOfOneSong(int songID)
        {
            try
            {
                List<PositionModel> allPositionsOfOneSong = this.psnLogic.getAllThePositionsOfOneSong(songID);
                return Ok(allPositionsOfOneSong);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }

}
