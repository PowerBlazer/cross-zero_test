using Cross_Zero.Core.DTO;
using Cross_Zero.Core.Entities;
using Cross_Zero.Core.Services;
using Newtonsoft.Json;
using Cross_Zero.Core.Enums;
using Cross_Zero.Core.Repository;
using Cross_Zero.Core.Common;

namespace Cross_Zero.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameDTO> CreateGame(int userId)
        {
            string gameBoardJson = JsonConvert.SerializeObject(new int[3, 3]
            {
                {0,0,0},
                {0,0,0},
                {0,0,0}
            });

            Game newGame = new()
            {
                PalyingBoardJson = gameBoardJson,
                FirstPlayerId = userId,
                State = GameState.Waiting,
            };

            int newGameId = await _gameRepository.AddGame(newGame);

            return new GameDTO()
            {
                GameId= newGameId,
                PlayingBoard = newGame.PalyingBoardJson,
                State = newGame.State,
            };
        }

        public async Task<GameDTO> JoinTheGame(int userId,int gameId)
        {
            Game? game = await _gameRepository.GetGameById(gameId);

            if(game is null)
            {
                throw new Exception("Игра не найдена");
            }

            game.SecondPlayerId = userId;
            game.State = GameState.Processed;

            await _gameRepository.UpdateGame(game,gameId);

            return new GameDTO
            {
                GameId=gameId,
                PlayingBoard = game.PalyingBoardJson,
                State = game.State,
            };
        }

        public async Task<GameDTO> MakeMove(int gameId,int value,Point point)
        {
            Game? game = await _gameRepository.GetGameById(gameId);

            if(game is null)
            {
                throw new Exception("Игры не существует");
            }

            int[,]? gameBoard = JsonConvert.DeserializeObject<int[,]>(game.PalyingBoardJson);

            if (gameBoard is null)
            {
                throw new Exception("Произошла ошибка");
            }

            gameBoard[point.X, point.Y] = value;

            string newGameBoard = JsonConvert.SerializeObject(gameBoard);

            game.PalyingBoardJson = newGameBoard;

            if (IsWinner(gameBoard, value))
            {
                game.State = GameState.Finished;

                await _gameRepository.UpdateGame(game,gameId);

                return new GameDTO
                {
                    GameId = gameId,
                    isPlayerWin = true,
                    PlayingBoard = game.PalyingBoardJson,
                    State = game.State,
                };
            }

            await _gameRepository.UpdateGame(game, gameId);

            return new GameDTO
            {
                GameId = gameId,                
                PlayingBoard = game.PalyingBoardJson,
                State = game.State,
            };

        }

        private bool IsWinner(int[,] gameBoard,int value)
        {            
            return (
                // Rows
                (gameBoard[0, 0] == value && gameBoard[0, 1] == value && gameBoard[0, 2] == value) ||
                (gameBoard[1, 0] == value && gameBoard[1, 1] == value && gameBoard[1, 2] == value) ||
                (gameBoard[2, 0] == value && gameBoard[2, 1] == value && gameBoard[2, 2] == value) ||
                // Columns
                (gameBoard[0, 0] == value && gameBoard[1, 0] == value && gameBoard[2, 0] == value) ||
                (gameBoard[0, 1] == value && gameBoard[1, 1] == value && gameBoard[2, 1] == value) ||
                (gameBoard[0, 2] == value && gameBoard[1, 2] == value && gameBoard[2, 2] == value) ||
                // Diagonals
                (gameBoard[0, 0] == value && gameBoard[1, 1] == value && gameBoard[2, 2] == value) ||
                (gameBoard[0, 2] == value && gameBoard[1, 1] == value && gameBoard[2, 0] == value)
            );
        }
    }
}
