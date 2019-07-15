using System.Collections.Generic;
using System.Linq;
using TodoList.Domain.Models.Users;
using TodoList.Domain.Repositories;
using TodoList.Infra.Contexts;

namespace TodoList.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        TodoListDataContext _context;

        public UserRepository(TodoListDataContext context)
        {
            _context = context;
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByKey(int id)
        {
            return _context.Users.FirstOrDefault(c => c.Id == id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
