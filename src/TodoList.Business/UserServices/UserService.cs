using System;
using System.Collections.Generic;
using TodoList.Domain.Commands.Inputs.User;
using TodoList.Domain.Models.Users;
using TodoList.Domain.Repositories;
using TodoList.Domain.Services;
using TodoList.Domain.ValueObjects.LoginObj;
using TodoList.Infra.Transactions;

namespace TodoList.Business.UserServices
{
    public class UserService : IUserService
    {
        IUserRepository _respository;
        IUow _uow;

        public UserService(IUserRepository respository, IUow uow)
        {
            _respository = respository;
            _uow = uow;
        }

        public IList<User> GetAll()
        {
            return _respository.GetAll();
        }

        public User GetByKey(int id)
        {
            return _respository.GetByKey(id);
        }

        public User Add(AddUserInput userInput)
        {
            var login = new Login(userInput.UserName, userInput.Password, userInput.Password);
            var email = new Email(userInput.Email);
            var user = new User(login, email, userInput.Name);

            if (user.Invalid) return user;

            _respository.Add(user);
            _uow.Commit();
            return user;
        }

        public User Update(UpdateUserInput userInput)
        {
            var user = _respository.GetByKey(userInput.Id);
            user.Update(user.Email, user.Name);

            if (user.Invalid) return user;

            _respository.Update(user);
            _uow.Commit();
            return user;
        }

        public void Remove(int id)
        {
            var user = _respository.GetByKey(id);
            _respository.Remove(user);
            _uow.Commit();
        }
    }
}
