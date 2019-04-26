using System.Collections.Generic;
using TodoList.Domain.Commands.Inputs.User;
using TodoList.Domain.Models.Users;

namespace TodoList.Domain.Services
{
    public interface IUserService
    {
        IList<User> GetAll();
        IList<User> GetByKey(int id);
        User Add(AddUserInput userInput);
        User Update(UpdateUserInput userInput);
        void Remove(int user);
    }
}
