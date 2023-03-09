

using Cross_Zero.Core.Common;

namespace Cross_Zero.Core.DTO
{
    public class MoveDTO
    {
        public MoveDTO()
        {
            Point = new Point();
        }

        public Point Point { get; set; }

        public int Value { get; set; } 
        public int GameId { get; set; }
    }
}
