using StudentManagement.Models;
using StudentManagement.Models.DTO;
namespace StudentManagement.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}
