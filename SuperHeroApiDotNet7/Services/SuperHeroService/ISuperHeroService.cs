using SuperHeroApiDotNet7.UnitOfWork.GenericRepository;

namespace SuperHeroApiDotNet7.Services.SuperHeroService
{
    public interface ISuperHeroService
    { //define your method here
        Task<List<SuperHeroModel>> GetAllHeroes();
        Task<SuperHeroModel?> GetSingleHero(int id);

        Task<List<SuperHeroModel>> AddHero(SuperHeroModel hero);

        Task<List<SuperHeroModel>?> Update(int id, SuperHeroModel request);

        Task<List<SuperHeroModel>?> DeleteHero(int id);

    }
}

