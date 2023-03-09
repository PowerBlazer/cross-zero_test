
using Cross_Zero.Core.Context;
using Cross_Zero.Core.Entities;
using Cross_Zero.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cross_Zero.Infrastructure.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly IApplicationContextEF _context;
        public GameRepository(IApplicationContextEF context)
        {
            _context = context;
        }

        public async Task<int> AddGame(Game game)
        {
            await _context.Games.AddAsync(game);

            await _context.SaveChangesAsync();

            return game.Id;
        }

        public async Task<Game?> GetGameById(int id)
        {
            return await _context.Games.Where(p=>p.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateGame(Game game,int gameId)
        {
            var gameRes = await _context.Games.Where(p=>p.Id == gameId).FirstOrDefaultAsync();

            if(gameRes is not null)
            {
                gameRes.State = game.State;
                gameRes.FirstPlayer = game.FirstPlayer;
                gameRes.PalyingBoardJson = game.PalyingBoardJson;
                gameRes.SecondPlayerId = game.SecondPlayerId;
            }

            await _context.SaveChangesAsync();
        }
    }
}
