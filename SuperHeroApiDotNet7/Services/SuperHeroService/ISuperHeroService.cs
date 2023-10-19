namespace SuperHeroApiDotNet7.Services.SuperHeroService
{
    public interface ISuperHeroService
    { //define your method here
        List<SuperHeroModel> GetAllHeroes();
        SuperHeroModel GetSingleHero(int id);

        List<SuperHeroModel> AddHero(SuperHeroModel hero);

        List<SuperHeroModel>? UpdateHero(int id, SuperHeroModel request);

        List<SuperHeroModel>? DeleteHero(int id);

    }
}

