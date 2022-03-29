using StudentManagement.Models;

namespace StudentManagement.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRespository<Student> Students { get; }
        IGenericRespository<Class> Classes { get; }
        IGenericRespository<Transcript> Transcripts { get; }
      
        IGenericRespository<Subjects> Subjects { get; }

        Task Save();
        int SaveChange();

    }
}
