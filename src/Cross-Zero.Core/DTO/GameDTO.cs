

using Cross_Zero.Core.Enums;

namespace Cross_Zero.Core.DTO
{
    #pragma warning disable CS8618
    public class GameDTO
    {
        public int GameId { get; set; }
        public GameState State { get; set; }
        public string PlayingBoard { get; set; }
        public bool? isPlayerWin { get; set; }
       
    }
}
