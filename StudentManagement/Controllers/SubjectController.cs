using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.IRepository;
using StudentManagement.Models;
using StudentManagement.Models.Subject;
using StudentManagement.Services.StudentSerivce;
using StudentManagement.Services.SubjectService;

namespace StudentManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {

        private readonly ISubjectService iSubjectService;
        private readonly ILogger<SubjectController> ilogger;

        public SubjectController(ILogger<SubjectController> logger, ISubjectService subjectService)
        {
            ilogger = logger;
            iSubjectService = subjectService;
        }

        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpGet]
        public async Task<IActionResult> GetAllSubjects([FromQuery] RequestParams requestParams)
        {
            try
            {
                var results= await iSubjectService.GetAllSubjects(requestParams);
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
        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDTO createSubjectDTO)
        {
            if (!ModelState.IsValid)
            {
                ilogger.LogError($"Invaild POST attempt in {nameof(CreateSubject)}");
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await iSubjectService.CreateSubject(createSubjectDTO);
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
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                /* var country = await iunitOfWork.Classes.Get(q => q.Id == (id));
                 if (country == null)
                 {
                     ilogger.LogError($"Invaild PUT attempt in {nameof(DeleteClass)}");
                     return BadRequest(ModelState);
                 }
                 await iunitOfWork.Classes.Delete(id);
                 await iunitOfWork.Save();*/
                iSubjectService.DeleteSubject(id);
                return new JsonResult($"Delete Success {id} ");

            }
            catch (Exception ex)
            {
                ilogger.LogError(ex, $"Something Wrong {nameof(DeleteClass)}");
                return StatusCode(500);

            }
        }


        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateSubject(int id, [FromBody] CreateSubjectDTO createSubjectDTO)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            try
            {

                var student = await iSubjectService.UpdateSubject(id, createSubjectDTO);
                return Ok(student);
            }
            catch (Exception e)
            {
                ilogger.LogError(e, $"Something Wrong {nameof(UpdateSubject)}");
                return StatusCode(500);

            }
        }
    }
}
