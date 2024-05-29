using Microsoft.EntityFrameworkCore;

namespace SuperHeroApiDotNet7.UnitOfWork
{
    public class UnitOfWorkServices : IUnitOfWork
    {
        private DataContext _context; //private ISuperHeroRepository Name { get; }
        private ISuperHeroRepository _superHeroRepository;
        public ISuperHeroRepository Name => _superHeroRepository;

        public UnitOfWorkServices(DataContext context,
                                    ISuperHeroRepository superHeroRepository
            )
        {
            _context = context;

            _superHeroRepository = superHeroRepository;
            //Name = superHeroRepository;

        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }



        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
