namespace Cross_Zero.Core.Entities
{
    #pragma warning disable CS8618
    public class User:BaseEntity
    {
        /// <summary>
        /// ������� ������
        /// </summary>
        public string? Nickname { get; set; }

        public ICollection<Game> FirstPlayers { get; set; }
        public ICollection<Game> SecondPlayers { get; set; }
    }
}