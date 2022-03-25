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
        private readonly IUnitOfWork iunitOfWork;
        private readonly ILogger<StudentController> ilogger;
        private readonly IMapper imapper;

        public StudentController(IUnitOfWork unitofWork, ILogger<StudentController> logger, IMapper mapper, IStudentService studentService)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
        _istudentService = studentService;
        }

        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudent([FromQuery] RequestParams requestParams)
        {

            try
            {
                var uni = await iunitOfWork.Students.GetPageList(requestParams);
                var results = imapper.Map<List<StudentDTO>>(uni);
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
            /* if (!ModelState.IsValid)
             {
                 ilogger.LogError($"Invaild POST attempt in {nameof(CreateStudent)}");
                 return BadRequest(ModelState);
             }
             try
             {
                 var student = imapper.Map<Student>(createStudentDTO);
                 await iunitOfWork.Students.Insert(student);
                 await iunitOfWork.Save();
                 return Ok(student);
                 //var result = student.UpdateStudent(createStudentDTO);
                  //return StatusCode(HttpStatusCode.OK, student);

             }
             catch (Exception e)
             {

                 ilogger.LogError(e, $"wrong");
                 return StatusCode(500, "try again");
             }*/
            try
            {
                 var result = _istudentService.CreateStudentAsync(createStudentDTO);
                return Ok(200);
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

        public async Task<IActionResult> UpdateStudent(int id, [FromBody] CreateStudentDTO createStudentDTO)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            try
            {

                var student = _istudentService.UpdateStudentAsync(id, createStudentDTO);
                return Ok(200);
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
                var country = await iunitOfWork.Students.Get(q => q.Id==(id));
                if (country == null)
                {

                }
                await iunitOfWork.Students.Delete(id);
                await iunitOfWork.Save();
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
