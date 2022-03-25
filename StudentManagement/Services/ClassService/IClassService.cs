using StudentManagement.Models;

namespace StudentManagement.Services.ClassService
{
    public interface IClassService
    {
        Task<Class> CreateClassAsync(CreateClassDTO createClassDTO);
        Task<Class> UpdateClassAsync(int id, CreateClassDTO createClassDTO);
    }
}
