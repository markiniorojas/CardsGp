using Business.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _playerService;

    public PlayerController(PlayerService playerService)
    {
        _playerService = playerService;
    }

    /// <summary>Habilita un jugador.</summary>
    [HttpPost("{playerId}/enable")]
    public async Task<IActionResult> EnablePlayer(int playerId)
    {
        await _playerService.EnablePlayerAsync(playerId);
        return Ok($"Jugador {playerId} habilitado.");
    }

    /// <summary>Deshabilita un jugador.</summary>
    [HttpPost("{playerId}/disable")]
    public async Task<IActionResult> DisablePlayer(int playerId)
    {
        await _playerService.DisablePlayerAsync(playerId);
        return Ok($"Jugador {playerId} deshabilitado.");
    }

    /// <summary>Devuelve todos los jugadores habilitados.</summary>
    [HttpGet("enabled")]
    public async Task<IActionResult> GetEnabledPlayers()
    {
        var players = await _playerService.GetEnabledPlayersAsync();
        return Ok(players);
    }
}
