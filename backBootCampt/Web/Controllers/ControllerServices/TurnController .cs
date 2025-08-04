//using Business.Services;
//using Microsoft.AspNetCore.Mvc;

//[ApiController]
//[Route("api/[controller]")]
//public class TurnController : ControllerBase
//{
//    private readonly TurnService _turnService;

//    public TurnController(TurnService turnService)
//    {
//        _turnService = turnService;
//    }

//    /// <summary>Devuelve el siguiente jugador activo en turno.</summary>
//    [HttpGet("{gameId}/next")]
//    public async Task<IActionResult> GetNextPlayer(int gameId, [FromQuery] int currentPlayerId)
//    {
//        var next = await _turnService.GetNextTurnPlayerAsync(gameId, currentPlayerId);
//        if (next == null)
//            return NotFound("No se encontró el siguiente jugador.");

//        return Ok(new
//        {
//            next.id,
//            next.playersId
//        });
//    }
//}
