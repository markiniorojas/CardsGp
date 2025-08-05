using Business.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly CardAssignmentService _cardService;

    public CardController(CardAssignmentService cardService)
    {
        _cardService = cardService;
    }

    /// <summary>Asigna 8 cartas a cada jugador habilitado.</summary>
    [HttpPost("assign")]
    public async Task<IActionResult> AssignCardsToEnabledPlayers()
    {
        await _cardService.AssignCardsToEnabledPlayersAsync();
        return Ok("Cartas asignadas a jugadores habilitados.");
    }
}
 