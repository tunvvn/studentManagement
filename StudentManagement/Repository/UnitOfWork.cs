using StudentManagement.Datas;
using StudentManagement.IRepository;
using StudentManagement.Models;
using StudentManagement.Models.Subject;

namespace StudentManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _dataBaseContext ;

        private IGenericRespository<Class> _classes;
        private IGenericRespository<Student> _students;
        private IGenericRespository<Subjects> _subjects;

        public UnitOfWork(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }


        public IGenericRespository<Student> Students => _students ??= new GenericRespository<Student>(_dataBaseContext);
        public IGenericRespository<Class> Classes => _classes ??= new GenericRespository<Class>(_dataBaseContext);

        public IGenericRespository<Subjects> Subjects => _subjects ??= new GenericRespository<Subjects>(_dataBaseContext);

        public void Dispose()
        {
            _dataBaseContext.Dispose();
            GC.SuppressFinalize(this);
        }

      
        public async Task Save()
        {
           await _dataBaseContext.SaveChangesAsync();
        }

        public int SaveChange()
        {
           return _dataBaseContext.SaveChanges();
        }
    }
}
