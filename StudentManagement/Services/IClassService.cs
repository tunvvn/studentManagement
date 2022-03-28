using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Models.DTO;

namespace StudentManagement.Services.ClassService
{
    public interface IClassService
    {
        Task<Class> CreateClassAsync(CreateClassDTO createClassDTO);
        Task<Class> UpdateClassAsync(int id, CreateClassDTO createClassDTO);
        Task<bool> DeleteClass(int id);
        Task<List<ClassDTO>> GetAllClasses([FromQuery] RequestParams requestParams);
    }
}
