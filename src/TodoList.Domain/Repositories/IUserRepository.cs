using System.Collections.Generic;
using TodoList.Domain.Models.Users;

namespace TodoList.Domain.Repositories
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        User GetByKey(int id);
        void Add(User user);
        void Update(User user);
        void Remove(User user);
    }
}
