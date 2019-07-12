using Microsoft.EntityFrameworkCore;
using TodoList.Common;
using TodoList.Common.Notifications;
using TodoList.Domain.Models.Users;
using TodoList.Domain.ValueObjects.LoginObj;
using TodoList.Infra.Mappings;

namespace TodoList.Infra.Contexts
{
    public class TodoListDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Runtime.ConnectionStringSqlServer);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();
            builder.Ignore<Login>();
            builder.Ignore<Email>();

            builder.ApplyConfiguration(new UserMap());
        }
    }
}
