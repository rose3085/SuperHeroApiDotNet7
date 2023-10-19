using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApiDotNet7.Services.SuperHeroService;

namespace SuperHeroApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService superHeroService;

        //ctor
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this.superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHeroModel>>> GetAllHeroes()
        {
            var result = this.superHeroService.GetAllHeroes();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHeroModel>>> GetSingleHero(int id)
        {
            var result = this.superHeroService.GetSingleHero(id);
            if (result is null)
            {
                return NotFound("Hero does not exists");
            }
            return Ok(result);
        }
        [HttpPost] //add a hero

        public async Task<ActionResult<List<SuperHeroModel>>> AddHero(SuperHeroModel hero)
        {
            var result = this.superHeroService.AddHero(hero);
            return Ok(result);
        }
        [HttpPut("{id}")] // Update a hero
        public async Task<ActionResult<List<SuperHeroModel>>> UpdateHero(int id, SuperHeroModel request)
        {
            var result = this.superHeroService.UpdateHero(id, request);
            if (result is null)
            {
                return NotFound("Sorry, but this hero doesn't exist.");
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHeroModel>>> DeleteHero(int id)
        {
            var result = this.superHeroService.DeleteHero(id);
            if (result is null)
            {
                return NotFound("Hero not found");
            }
            return Ok(result);
        }
        
    }
}
