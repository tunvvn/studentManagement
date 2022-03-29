using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Models.DTO;
using StudentManagement.Services;

namespace StudentManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TranscriptController : ControllerBase
    {


        private readonly ITranscriptService itranscriptService;
        private readonly ILogger<SubjectController> ilogger;

        public TranscriptController(ILogger<SubjectController> logger, ITranscriptService transcriptService)
        {
            ilogger = logger;
            itranscriptService = transcriptService;
        }


        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpGet]
        public async Task<IActionResult> GetAllTranscripts([FromQuery] RequestParams requestParams)
        {
            try
            {
                var results = await itranscriptService.GetAllTranscripts(requestParams);
                return Ok(results);
            }
            catch (Exception ex)
            {
                ilogger.LogError(ex, $"wrong");
                return StatusCode(500, "try again");
            }
        }
        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpPost]
        public async Task<IActionResult> CreateTranscript([FromBody] CreateTranscriptDTO createSubjectDTO)
        {
            if (!ModelState.IsValid)
            {
                ilogger.LogError($"Invaild POST attempt in {nameof(CreateTranscript)}");
                return BadRequest(ModelState);
            }

            try
            {
                var result = await itranscriptService.CreateTranscript(createSubjectDTO);
                return Ok(result);
            }
            catch (Exception e)
            {

                ilogger.LogError(e, $"wrong");
                return StatusCode(500, "try again");
            }

            //return StatusCode(HttpStatusCode.OK, result);

        }

        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateTranscript(int id, [FromBody] CreateTranscriptDTO createTranscriptDTO)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            try
            {

                var transcript = await itranscriptService.UpdateTranscript(id, createTranscriptDTO);
                return Ok(transcript);
            }
            catch (Exception e)
            {
                ilogger.LogError(e, $"Something Wrong {nameof(UpdateTranscript)}");
                return StatusCode(500);

            }
        }

        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTranscript(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                itranscriptService.DeleteTranscript(id);
                return new JsonResult($"Delete Success {id} ");

            }
            catch (Exception ex)
            {
                ilogger.LogError(ex, $"Something Wrong {nameof(DeleteTranscript)}");
                return StatusCode(500);

            }
        }
        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpPost("/ScoreSumaryBySubject")]
        public async Task<IActionResult> ScoreSummaryBySubject([FromBody] ScoreSumaryBySubject scoreSumaryBySubject)
        {
            if (!ModelState.IsValid)
            {
                ilogger.LogError($"Invaild POST attempt in {nameof(ScoreSummaryBySubject)}");
                return BadRequest(ModelState);
            }
            try
            {
                var transcript = await itranscriptService.ScoreSummaryBySubject(scoreSumaryBySubject);
                return Ok(transcript);
                //return Ok(200);
            }
            catch (Exception e)
            {
                ilogger.LogError(e, $"Something Wrong {nameof(ScoreSummaryBySubject)}");
                return StatusCode(500);

            }
        }


    }
}
