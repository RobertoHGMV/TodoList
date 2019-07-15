using TodoList.Common.Entities;
using TodoList.Domain.ValueObjects.EmailObj;

namespace TodoList.Domain.ValueObjects.LoginObj
{
    public class Email : Entity
    {
        protected Email() { }

        public Email(string address)
        {
            Address = address;
            Validate(new EmailValidator(this));
        }

        public string Address { get; private set; }
    }
}
