using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Datas;
using StudentManagement.IRepository;
using StudentManagement.Models;

namespace StudentManagement.Services.StudentSerivce
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork iunitOfWork;
        private readonly ILogger<StudentService> ilogger;
        private readonly IMapper imapper;

     

        public StudentService(IUnitOfWork unitofWork, ILogger<StudentService> logger, IMapper mapper)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
        }
        public async Task<Student> CreateStudentAsync(CreateStudentDTO createStudentDTO)
        {

            //var student = imapper.Map<Student>(createStudentDTO);
            if (createStudentDTO.ClassId!=null)
            {
                var cl = await iunitOfWork.Classes.Get(q => q.Id==(createStudentDTO.ClassId));
                //var clas = db.Classes.Where(u => u.Id.Equals(createStudentDTO.ClassId)).FirstOrDefault();
                if (cl == null)
                {
                    throw new Exception("ClassId not exit!");
                }
            }
            var student =  imapper.Map<Student>(createStudentDTO);

            //var student = new Student();
            //student.Id = Guid.NewGuid().ToString();
            //student.ClassId = createStudentDTO.ClassId;
            //student.Name = createStudentDTO.Name;
            //student.Gender = createStudentDTO.Gender;
            //student.Birthday = createStudentDTO.Birthday;
            student.CreateBy = 1;
            student.UpdateBy = 1;

            //student.CreateDate = System.DateTime.Now;
            //student.FatherName = createStudentDTO.FatherName;
            //student.MotherName = createStudentDTO.MotherName;
            //db.Students.Add(student);
            await iunitOfWork.Students.Insert(student);
            var check= iunitOfWork.SaveChange();
            if (check ==0)
            {
                throw new Exception("Class not update!");
            }
            //db.SaveChanges();
            return student;



        }

        public async Task<Student> UpdateStudentAsync(int id,CreateStudentDTO createStudentDTO)
        {
            var student = await iunitOfWork.Students.Get(q => q.Id == (id));
            if (student == null)
            {
                ilogger.LogError($"Invaild PUT attempt");
                throw new NotImplementedException();

            }
            if (createStudentDTO.ClassId != null)
            {
                var cl = iunitOfWork.Classes.Get(q => q.Id.Equals(createStudentDTO.ClassId));
                if (cl == null)
                {
                    throw new Exception("ClassId not exit!");
                }
            }
            imapper.Map(createStudentDTO, student);
            student.UpdateBy = 1;
            iunitOfWork.Students.Update(student);
            await iunitOfWork.Save();
            //throw new NotImplementedException();
            return student;
        }

        public async Task<bool> DeleteStudent(int Id)
        {
            var subject = await iunitOfWork.Students.Get(q => q.Id == (Id));
            if (subject == null)
            {
                ilogger.LogError($"Invaild PUT attempt in {nameof(DeleteStudent)}");
                throw new Exception("invaild subject");
            }
            await iunitOfWork.Subjects.Delete(Id);
            var check = iunitOfWork.SaveChange();
            if (check == 0)
            {
                throw new Exception("invaild delete student");
            }
            else
                return true;


        }

        public async Task<List<StudentDTO>> GetAllStudents([FromQuery] RequestParams requestParams)
        {
            var uni = await iunitOfWork.Students.GetPageList(requestParams);
            var results = imapper.Map<List<StudentDTO>>(uni);
            return results;
        }
    }
}
