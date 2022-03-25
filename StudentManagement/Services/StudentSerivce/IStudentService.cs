using StudentManagement.Models;

namespace StudentManagement.Services.StudentSerivce
{
    public interface IStudentService
    {
         Task<Student> CreateStudentAsync(CreateStudentDTO createStudentDTO);
        Task<Student> UpdateStudentAsync(int id,CreateStudentDTO createStudentDTO);

    }
}
