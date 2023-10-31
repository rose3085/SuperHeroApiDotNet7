using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApiDotNet7.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        public static List<SuperHeroModel> superHeroes = new List<SuperHeroModel>
            {
                new SuperHeroModel{
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "NewYork"
                },
                new SuperHeroModel{
                    Id = 2,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName= "Stark",
                    Place = "Malibu"
                }
        };
        private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHeroModel>> AddHero(SuperHeroModel hero)
        {

          _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHeroModel>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHeroModel>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHeroModel?> GetSingleHero(int id)
        {

            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHeroModel>?> UpdateHero(int id, SuperHeroModel request)
        {

            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Name = request.Name;

            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();

        }

    }
}
