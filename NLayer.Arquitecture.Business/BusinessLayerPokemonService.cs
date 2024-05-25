using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;







namespace NLayer.Arquitecture.Business.Services
{
    public class BusinessLayerPokemonService
    {
      private static readonly HttpClient client = new HttpClient();


      public async Task <Pokemon> GetPokemon (string pokemonNombre)
        {
            string apiUrl = $" https://pokeapi.co//api/v2/pokemon/{pokemonNombre.ToLower()}";

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception($"No se pudo obtener informacion del Pokemon.Status Code{response.StatusCode}");            
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            var pokemonData = JObject.Parse(responseBody);
            
            var pokemon = new Pokemon 
            {
                Nombre = pokemonData["nombre"]?.ToString(),
                Tipo = pokemonData["tipo"]?[0]?["tipo"]?["nombre"]?.ToString(),
                SpriteUrl = pokemonData["sprites"]?["front_default"]?.ToString(),
                Moves = pokemonData["moves"]?.Select(m => m["moves"]?["nombre"]?.ToString()).ToList()
            };
            return pokemon;
        }    
    }

    public class Pokemon
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string SpriteUrl { get; set; }

        public List<string> Moves { get; set; } 
    }
}
