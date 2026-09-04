using PokeApiNet;
using System.Text.Json.Serialization;

namespace PokeAPI.Models
{
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("weight")]
        public int Weight { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("stats")]
        public List<PokemonStat> Stats { get; set; } = new List<PokemonStat>();

        [JsonPropertyName("sprites")]
        public spritesData Sprites { get; set; }
    }

    public class spritesData
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

    }
}