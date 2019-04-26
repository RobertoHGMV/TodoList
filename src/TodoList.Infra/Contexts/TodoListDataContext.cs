using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Models.Users;

namespace TodoList.Infra.Contexts
{
    public class TodoListDataContext : DbContext
    {
        public TodoListDataContext(DbContextOptions<TodoListDataContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder builder) { }
    }
}
