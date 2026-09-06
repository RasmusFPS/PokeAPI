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

        public async Task<IActionResult> Details(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction("Index");
            }

            var pokemonDetails = await _pokemonService.GetPokemonDetails(name);

            if(pokemonDetails == null)
            {
                return View((PokeAPI.Models.Pokemon?)null);
            }

            return View(pokemonDetails);
        }
    }
}
