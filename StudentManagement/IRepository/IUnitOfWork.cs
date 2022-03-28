using StudentManagement.Models;
using StudentManagement.Models.Subject;

namespace StudentManagement.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRespository<Student> Students { get; }
        IGenericRespository<Class> Classes { get; }

        IGenericRespository<Subjects> Subjects { get; }

        Task Save();
        int SaveChange();

    }
}
