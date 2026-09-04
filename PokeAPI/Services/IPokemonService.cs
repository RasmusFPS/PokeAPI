using PokeAPI.Models;

namespace PokeAPI.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetPokemon();
        Task<Pokemon?> GetPokemonDetails(string name);
    }
}
