
using Cross_Zero.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cross_Zero.Infrastructure.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasOne(p => p.FirstPlayer)
                .WithMany(p => p.FirstPlayers)
                .HasForeignKey(p => p.FirstPlayerId);

            builder.HasOne(p => p.SecondPlayer)
                .WithMany(p => p.SecondPlayers)
                .HasForeignKey(p => p.SecondPlayerId);
       
        }
    }
}
