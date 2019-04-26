using TodoList.Common.Entities;
using TodoList.Domain.ValueObjects.LoginObj;

namespace TodoList.Domain.Models.Users
{
    public class User : Entity
    {
        public User(Login login, Email email, string name)
        {
            Login = login;
            Email = email;
            Name = name;

            Validate(new UserValidator(this));
        }

        public int Id { get; private set; }
        public Login Login { get; private set; }
        public Email Email { get; private set; }
        public string Name { get; set; }

        public void Update(Email email, string name)
        {
            Email = email;
            Name = name;

            Validate(new UserValidator(this));
        }
    }
}
