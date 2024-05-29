using System.Linq.Expressions;

namespace SuperHeroApiDotNet7.UnitOfWork.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<T> GetById(int id);
        //Task<IEnumerable<T>> GetAll();
        //void Delete(T entity);
        //void Update(T entity);
        Task<List<T>> GetAll(
            Expression<Func<T,bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);



        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task Add(T entity);

        Task<T> GetById(int id);
        Task AddAsync(IEnumerable<T> entities);

        Task Delete(T entity);
        void DeleteAsync(IEnumerable<T> entities);
        void Update(T entity);


        void UpdateField(T entity);



    }
}
