 using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.IRepository;
using StudentManagement.Models;
using StudentManagement.Models.DTO;
using StudentManagement.Services.ClassService;

namespace StudentManagement.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        private readonly IClassService iclassService;
        private readonly ILogger<ClassController> ilogger;

        public ClassController( ILogger<ClassController> logger,  IClassService classService)
        {
            ilogger = logger;
            iclassService = classService;
        }

        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpGet]
        public async Task<IActionResult> GetAllClass([FromQuery] RequestParams requestParams)
        {
            try
            {
                var results = await iclassService.GetAllClasses(requestParams);
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
        public async Task<IActionResult> CreateClass([FromBody] CreateClassDTO createClassDTO)
        {
            if (!ModelState.IsValid)
            {
                ilogger.LogError($"Invaild POST attempt in {nameof(CreateClass)}");
                return BadRequest(ModelState);
            }
            try
            {
                var clas = await iclassService.CreateClassAsync(createClassDTO);
                return Ok(clas);

            }
            catch (Exception e)
            {

                ilogger.LogError(e, $"wrong");
                return StatusCode(500, "try again");
            }
        }

        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateClass(int id, [FromBody] CreateClassDTO createClassDTO)
        {
         
            try
            {
                var result = await iclassService.UpdateClassAsync(id, createClassDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                ilogger.LogError(e, $"Something Wrong {nameof(UpdateClass)}");
                return StatusCode(500);

            }
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
               
                await iclassService.DeleteClass(id);
                return new JsonResult($"Delete Success {id} ");

            }
            catch (Exception ex)
            {
                ilogger.LogError(ex, $"Something Wrong {nameof(DeleteClass)}");
                return StatusCode(500);

            }
        }
    }
}
