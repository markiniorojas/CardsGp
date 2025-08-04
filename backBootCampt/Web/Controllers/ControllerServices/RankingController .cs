using Business.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RankingController : ControllerBase
{
    private readonly RankingService _rankingService;

    public RankingController(RankingService rankingService)
    {
        _rankingService = rankingService;
    }

    /// <summary>Obtiene los 3 mejores jugadores habilitados por puntos.</summary>
    [HttpGet("{gameId}/top3")]
    public async Task<IActionResult> GetTop3Players(int gameId)
    {
        var topPlayers = await _rankingService.GetTop3PlayersAsync(gameId);
        if (topPlayers == null || !topPlayers.Any())
            return NotFound("No se encontraron jugadores activos en este juego.");

        return Ok(topPlayers);
    }
}
