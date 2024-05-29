using SuperHeroApiDotNet7.UnitOfWork.GenericRepository;

namespace SuperHeroApiDotNet7.UnitOfWork
{
    public class SuperHeroRepository : GenericRepository<SuperHeroModel>, ISuperHeroRepository
    {
        public SuperHeroRepository(DataContext context) : base(context)
        {
        }
    }
}
