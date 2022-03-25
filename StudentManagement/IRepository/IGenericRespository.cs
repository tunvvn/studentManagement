using StudentManagement.Models;
using System.Linq.Expressions;
using X.PagedList;

namespace StudentManagement.IRepository
{
    public interface IGenericRespository<T> where T : class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            List<string> include = null);

        Task<IPagedList<T>> GetPageList(
             RequestParams requesparams ,
             List<string> includes = null
           );

        Task<T> Get(Expression<Func<T, bool>> expression, List<string> include = null);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int Id);
        Task DeleteById(string Id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
