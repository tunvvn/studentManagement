using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Models.DTO;


namespace StudentManagement.Services.StudentSerivce
{
    public interface IStudentService
    {
         Task<Student> CreateStudentAsync(CreateStudentDTO createStudentDTO);
        Task<Student> UpdateStudentAsync(int id,CreateStudentDTO createStudentDTO);
        Task<List<StudentDTO>> GetAllStudents([FromQuery] RequestParams requestParams);
        Task<bool> DeleteStudent(int Id);
    }
}
