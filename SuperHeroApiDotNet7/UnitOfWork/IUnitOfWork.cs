using SuperHeroApiDotNet7.UnitOfWork.GenericRepository;

namespace SuperHeroApiDotNet7.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        ISuperHeroRepository Name { get; }

        int Save();
    }
}
