using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.IRepository;
using StudentManagement.Models;
using StudentManagement.Services.StudentSerivce;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _istudentService;
        private readonly ILogger<StudentController> ilogger;


        public StudentController( ILogger<StudentController> logger, IStudentService studentService)
        {
            ilogger = logger;
         _istudentService = studentService;
        }

        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudent([FromQuery] RequestParams requestParams)
        {

            try
            {
                var results = await _istudentService.GetAllStudents(requestParams);
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
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO createStudentDTO)
        {
            if (!ModelState.IsValid)
            {
                ilogger.LogError($"Invaild POST attempt in {nameof(CreateStudent)}");
                return BadRequest(ModelState);
            }       
            try
            {
                 var result = await _istudentService.CreateStudentAsync(createStudentDTO);
                return Ok(result);
            }
            catch (Exception e)
            {

                ilogger.LogError(e, $"wrong");
                return StatusCode(500, "try again");
            }
            
        }

        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateStudent(int id, [FromBody] CreateStudentDTO createStudentDTO)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var student = await _istudentService.UpdateStudentAsync(id, createStudentDTO);
                return Ok(student);
            }
            catch (Exception e)
            {
                ilogger.LogError(e, $"Something Wrong {nameof(UpdateStudent)}");
                return StatusCode(500);

            }
        }
 //       [Authorize(Roles = "ADMINSTRATOR")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _istudentService.DeleteStudent(id);
                return new JsonResult($"Delete Success {id} ");

            }
            catch (Exception ex)
            {
                ilogger.LogError(ex, $"Something Wrong {nameof(DeleteStudent)}");
                return StatusCode(500);

            }
        }
    }
}
