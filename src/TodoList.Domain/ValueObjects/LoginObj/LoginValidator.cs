using TodoList.Common.Validations;

namespace TodoList.Domain.ValueObjects.LoginObj
{
    public class LoginValidator : Validation
    {
        public LoginValidator(Login login)
        {
            IsNullOrEmpty(login.UserName, "UserName", "Nome de usuário inválido");
            IsNullOrEmpty(login.Password, "Password", "Senha inválida");
            AreNotEquals(login.Password, login.ConfirmPassword, "Login", "Senha e confirmação de senha não coincidem");
        }
    }
}
