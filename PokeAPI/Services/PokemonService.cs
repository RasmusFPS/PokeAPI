using PokeAPI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokeAPI.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Pokemon>> GetPokemon()
        {
            try
            {
                var response = await _httpClient.GetAsync("pokemon?limit=10");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var data = JsonSerializer.Deserialize<PokemonApiResponse>(json, options);

                return data.Results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal class PokemonApiResponse()
        {
            [System.Text.Json.Serialization.JsonPropertyName("results")]
            public List<Pokemon>? Results { get; set; }
        }
    }
}
