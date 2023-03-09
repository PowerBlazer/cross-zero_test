using Cross_Zero.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cross_Zero.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User[]
            {
               new User { Id = 1,Nickname="Vlad"},
               new User { Id = 2,Nickname="Tolya"},
            });
        }
    }
}
