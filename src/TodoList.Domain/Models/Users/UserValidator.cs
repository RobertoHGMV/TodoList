using TodoList.Common.Validations;

namespace TodoList.Domain.Models.Users
{
    public class UserValidator : Validation
    {
        User _user;

        public UserValidator(User user)
        {
            _user = user;

            AddNotifications(user.Login.Notifications);
            AddNotifications(user.Email.Notifications);
            IsNullOrEmpty(_user.Name, "Name", "Nome inválido");
        }
    }
}
