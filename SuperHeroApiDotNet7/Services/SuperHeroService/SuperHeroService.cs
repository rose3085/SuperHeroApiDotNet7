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
        public List<SuperHeroModel> AddHero(SuperHeroModel hero)
        {

            superHeroes.Add(hero);
            return superHeroes;
        }

        public List<SuperHeroModel>? DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return null;
            }
            superHeroes.Remove(hero);
            return superHeroes;
        }

        public List<SuperHeroModel> GetAllHeroes()
        {
            return superHeroes;
        }

        public SuperHeroModel GetSingleHero(int id)
        {

            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return null;
            }
            return hero;
        }

        public List<SuperHeroModel>? UpdateHero(int id, SuperHeroModel request)
        {

            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
            {
                return null;
            }
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Name = request.Name;

            return superHeroes;

        }

    }
}
