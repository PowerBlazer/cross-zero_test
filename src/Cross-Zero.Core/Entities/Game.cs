

using Cross_Zero.Core.Enums;


namespace Cross_Zero.Core.Entities
{
    #pragma warning disable CS8618
    public class Game:BaseEntity
    {
        /// <summary>
        /// Игровое поле в виде одномерного массива
        /// </summary>
        public string PalyingBoardJson { get; set; } = string.Empty;

        /// <summary>
        /// Внешний ключ первого игрока
        /// </summary>
        public int FirstPlayerId { get; set; }
        /// <summary>
        /// Внешний ключ второго игрока
        /// </summary>
        public int? SecondPlayerId { get; set; }
        /// <summary>
        /// Cостояние игры
        /// </summary>
        public GameState State { get; set; } = GameState.Waiting;

        public User FirstPlayer { get; set; }
        public User SecondPlayer { get; set; }
    }
}
