using TodoList.Common.Entities;

namespace TodoList.Domain.ValueObjects.LoginObj
{
    public class Login : Entity
    {
        protected Login() { }

        public Login(string userName, string password, string confirmPassword)
        {
            UserName = userName;
            Password = password;
            ConfirmPassword = confirmPassword;
            Validate(new LoginValidator(this));
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
    }
}
