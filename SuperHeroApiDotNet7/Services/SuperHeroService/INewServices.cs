namespace SuperHeroApiDotNet7.Services.SuperHeroService
{
    public interface INewServices
    {
        Task<bool> AddHero(SuperHeroModel hero);
    }
}
