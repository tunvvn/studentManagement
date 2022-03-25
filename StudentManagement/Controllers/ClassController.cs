 using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.IRepository;
using StudentManagement.Models;
using StudentManagement.Services.ClassService;

namespace StudentManagement.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        private readonly IClassService iclassService;
        private readonly IUnitOfWork iunitOfWork;
        private readonly ILogger<ClassController> ilogger;
        private readonly IMapper imapper;

        public ClassController(IUnitOfWork unitofWork, ILogger<ClassController> logger, IMapper mapper, IClassService classService)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
            iclassService = classService;
        }

        //[Authorize(Roles = "ADMINSTRATOR")]
        [HttpGet]
        public async Task<IActionResult> GetAllClass([FromQuery] RequestParams requestParams)
        {
            try
            {
                var uni = await iunitOfWork.Classes.GetPageList(requestParams);
                var results = imapper.Map<List<ClassDTO>>(uni);
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
                var clas = iclassService.CreateClassAsync(createClassDTO);
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
                var clas = await iunitOfWork.Students.Get(q => q.Id==(id));
                if (clas == null)
                {
                    ilogger.LogError($"Invaild PUT attempt in {nameof(UpdateClass)}");
                    return BadRequest(ModelState);
                }
                if (createClassDTO.StudentIds.Count() > 0)
                {
                    foreach (int s in createClassDTO.StudentIds)
                    {
                        var student = await iunitOfWork.Students.Get(q => q.Id == (id));
                        student.ClassId = student.Id;
                        iunitOfWork.Students.Update(student);
                        await iunitOfWork.Save();
                    }
                        
                }
                imapper.Map(createClassDTO, clas);
                iunitOfWork.Students.Update(clas);
                await iunitOfWork.Save();
                return Ok(200);
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
                var country = await iunitOfWork.Classes.Get(q => q.Id==(id));
                if (country == null)
                {
                    ilogger.LogError($"Invaild PUT attempt in {nameof(DeleteClass)}");
                    return BadRequest(ModelState);
                }
                await iunitOfWork.Classes.Delete(id);
                await iunitOfWork.Save();
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
