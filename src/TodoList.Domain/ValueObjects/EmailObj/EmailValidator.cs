using TodoList.Common.Validations;
using TodoList.Domain.ValueObjects.LoginObj;

namespace TodoList.Domain.ValueObjects.EmailObj
{
    public class EmailValidator : Validation
    {
        public EmailValidator(Email email)
        {
            IsInvalidEmail(email.Address, "Email", "E-mail inválido");
        }
    }
}
