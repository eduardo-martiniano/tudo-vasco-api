using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.TelegramId)
                .IsRequired();

            builder.Property(p => p.DateLastNews);

            builder.Property(p => p.ReceiveOnlyImportant)
                .IsRequired();
        }
    }
}
