using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbProject
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireWorld")]
    public class SongsController : ControllerBase
    {
        public SongsLogic sngLogic;
        public LinguisticExpressionLogic linguisticExpressionLogic;

        public SongsController(SongsLogic sngLogic, LinguisticExpressionLogic linguisticExpressionLogic)
        {
            this.sngLogic = sngLogic;
            this.linguisticExpressionLogic = linguisticExpressionLogic;
        }

        [HttpGet]
        public IActionResult getAllSongs()
        {
            try
            {
                List<SongModel> songs = this.sngLogic.getAllSongs();
                return Ok(songs);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getOneSong(int id)
        {
            try
            {
                SongModel song = this.sngLogic.getOneSong(id);
                return Ok(song);
            }

            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult addSong(IFormFile userSongFile)
        {
            try
            {
                SongModel addedSongFile = sngLogic.addSong(userSongFile);
                return Ok(addedSongFile);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("loadAllTables")]
        public IActionResult loadAllTables()
        {
            try
            {
                sngLogic.makeAllSongsLyricFile();
                return Ok(true);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch]
        [Route("{songID}")]
        public IActionResult editPartialSong(int songID, SongModel songModel)
        {
            try
            {
                songModel.SongId = songID;
                SongModel songToEdit = sngLogic.editPartialSong(songModel);

                if (songToEdit == null)
                    return NotFound("song not found");
                return Ok(songToEdit);

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("findSongsByData")]
        public IActionResult findSongsByData([FromQuery] SongModel songModel, [FromQuery] string? wordsFromText)
        {
            try
            {

                List<SongModel> songModels = sngLogic.findSongsByData(songModel, wordsFromText);
                if (songModels == null)
                    return NotFound("There are no matches by your data");
                return Ok(songModels);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("getSongLyricByID/{songID}")]
        public IActionResult getSongLyricByID(int songID)
        {
            try
            {
                string songLyric = sngLogic.getSongLyricByID(songID);
                return Ok(songLyric);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getSongStatisticalData/{songID}")]
        public IActionResult getSongStatisticalData(int songID)
        {
            try
            {
                StatisticalDataModel statisticalDataModel = sngLogic.getSongStatisticalData(songID);
                return Ok(statisticalDataModel);
            }

            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
