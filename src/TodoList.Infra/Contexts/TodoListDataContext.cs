using Microsoft.EntityFrameworkCore;
using TodoList.Common;
using TodoList.Domain.Models.Users;

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

        protected override void OnModelCreating(ModelBuilder builder) { }
    }
}
