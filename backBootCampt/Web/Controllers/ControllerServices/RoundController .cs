//using Business.Enums;
//using Business.Services;
//using Microsoft.AspNetCore.Mvc;

//[ApiController]
//[Route("api/[controller]")]
//public class RoundController : ControllerBase
//{
//    private readonly RoundService _roundService;

//    public RoundController(RoundService roundService)
//    {
//        _roundService = roundService;
//    }

//    /// <summary>Evalúa una ronda comparando un atributo específico.</summary>
//    [HttpPost("{gameId}/play")]
//    public async Task<IActionResult> PlayRound(int gameId, [FromQuery] AttributeToCompare attribute)
//    {
//        var winner = await _roundService.EvaluateTurnAsync(gameId, attribute);
//        if (winner == null)
//            return NotFound("No se pudo determinar un ganador.");

//        return Ok(winner);
//    }
//}

using Business.Enums;
using Business.Services;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoundController : ControllerBase
    {
        private readonly RoundService _roundService;

        public RoundController(RoundService roundService)
        {
            _roundService = roundService;
        }

        /// <summary>
        /// Evalúa la ronda con el atributo seleccionado, asigna el punto al ganador,
        /// marca las cartas como usadas y devuelve el siguiente jugador en turno.
        /// Si no quedan cartas activas, se finaliza el juego.
        /// </summary>
        /// <param name="gameId">ID del juego</param>
        /// <param name="currentPlayerId">ID del jugador que acaba de jugar</param>
        /// <param name="attribute">Atributo a comparar</param>
        /// <returns>Resultado de la ronda con el ganador, siguiente jugador y mensaje</returns>
        [HttpPost("{gameId}/play-turn")]
        public async Task<IActionResult> PlayTurn(
            int gameId,
            [FromQuery] int currentPlayerId,
            [FromQuery] AttributeToCompare attribute)
        {
            var result = await _roundService.EvaluateTurnAndGetNextAsync(gameId, attribute, currentPlayerId);

            if (result == null)
                return NotFound("No se pudo evaluar la ronda. Verifica si hay cartas o jugadores activos.");

            return Ok(result);
        }
    }
}
