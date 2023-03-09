using Cross_Zero.Core.Common;
using Cross_Zero.Core.DTO;

namespace Cross_Zero.Core.Services
{
    public interface IGameService
    {
        Task<GameDTO> CreateGame(int userId);
        Task<GameDTO> JoinTheGame(int userId,int gameId);
        Task<GameDTO> MakeMove(int gameId,int value, Point point);
    }
}
