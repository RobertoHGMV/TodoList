using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
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
            builder.OwnsOne(c => c.Login).Property(c => c.UserName).HasMaxLength(20).HasColumnName("UserName");
            builder.OwnsOne(c => c.Login).Property(c => c.Password).HasMaxLength(32).IsFixedLength().HasColumnName("Password");
            builder.OwnsOne(c => c.Email).Property(c => c.Address).HasMaxLength(160).HasColumnName("Email");
        }
    }
}
