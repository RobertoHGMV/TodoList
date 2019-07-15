using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Models.Users;

namespace TodoList.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(60).HasColumnName("Name");
            builder.OwnsOne(c => c.Login).Property(l => l.UserName).HasMaxLength(20).HasColumnName("UserName");
            builder.OwnsOne(c => c.Login).Property(l => l.Password).HasMaxLength(32).IsFixedLength().HasColumnName("Password");
            builder.OwnsOne(c => c.Login).Ignore(l => l.ConfirmPassword);
            builder.OwnsOne(c => c.Login).Ignore(l => l.Valid);
            builder.OwnsOne(c => c.Email).Property(e => e.Address).HasMaxLength(160).HasColumnName("Email");
            builder.OwnsOne(c => c.Email).Ignore(l => l.Valid);
            builder.Ignore(c => c.Valid);
        }
    }
}
