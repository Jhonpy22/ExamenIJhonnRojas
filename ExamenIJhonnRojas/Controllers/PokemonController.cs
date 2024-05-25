using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NLayer.Arquitecture.Business.Services;

namespace ExamenIJhonnRojas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly BusinessLayerPokemonService _businessLayerPokemonService;

        public PokemonController(BusinessLayerPokemonService businessLayerPokemonService)
        {
            _businessLayerPokemonService = businessLayerPokemonService;
        }

        [HttpGet("{pokemonNombre}")]
        public async Task<IActionResult> GetPokemon(string pokemonNombre)
        {
            try
            {
                var pokemon = await _businessLayerPokemonService.GetPokemon(pokemonNombre);
                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

