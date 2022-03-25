using StudentManagement.Models;

namespace StudentManagement.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRespository<Student> Students { get; }
        IGenericRespository<Class> Classes { get; }
    
        Task Save();

    }
}
