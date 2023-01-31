using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireWorld")]
    public class WordsController : ControllerBase
    {
        public WordsLogic wordLogic;
    
        public WordsController(WordsLogic wordLogic)
        {
            this.wordLogic = wordLogic;
        }

        [HttpGet]
        public IActionResult getAllWords()
        {
            try
            {
                List<WordModel> allWords = wordLogic.getAllWords();
                return Ok(allWords);
            }

            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/words/getWordsOfOneSong/{songId}")]
        public IActionResult getWordsOfOneSong(int songId)
        {
            try
            {
                List<WordModel> wordsOfOneSong = wordLogic.getWordsOfOneSong(songId);
                return Ok(wordsOfOneSong);
            }

            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
