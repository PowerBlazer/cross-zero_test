

using Cross_Zero.Core.Entities;

namespace Cross_Zero.Core.Repository
{
    public interface IGameRepository
    {
        Task<int> AddGame(Game game);
        Task UpdateGame(Game game,int gameId);
        Task<Game?> GetGameById(int id);
    }
}
