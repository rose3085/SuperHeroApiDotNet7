using System.Linq.Expressions;

namespace SuperHeroApiDotNet7.UnitOfWork.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DataContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DataContext context)
        {
            _context = context;
           
        }

        public async Task Add(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
        }

        public Task AddAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateField(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> GetById(int id)
        {
         var result = await _context.Set<T>().FindAsync(id);
            if (result is null)
            {

                return default(T);
            
            }


            return result;

        }
    }
}
