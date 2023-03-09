using Cross_Zero.Core.DTO;
using Cross_Zero.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cross_Zero.WebAPI.Controllers
{
    [Route("game")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetGames()
        {
            return Ok(await _gameService.GetGames())
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGame(int userId)
        {
            var game = await _gameService.CreateGame(userId);

            return Ok(game);
        }

        [HttpPost("join")]
        public async Task<IActionResult> JoinGame(int userId,int gameId)
        {
            var game = await _gameService.JoinTheGame(userId, gameId);
           

            return Ok(game);
        }

        [HttpPost("move")]
        public async Task<IActionResult> MakeMove(MoveDTO move)
        {
            var game = await _gameService.MakeMove(move.GameId, move.Value, move.Point);

            return Ok(game);
        }
    }
}
