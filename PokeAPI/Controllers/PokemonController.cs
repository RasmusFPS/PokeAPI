using Microsoft.AspNetCore.Mvc;
using PokeAPI.Services;

namespace PokeAPI.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<IActionResult> Index()
        {
            var pokemonlist = await _pokemonService.GetPokemon();

            return View(pokemonlist);
        }
    }
}
