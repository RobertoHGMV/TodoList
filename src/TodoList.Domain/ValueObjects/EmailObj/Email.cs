using TodoList.Common.Entities;
using TodoList.Domain.ValueObjects.EmailObj;

namespace TodoList.Domain.ValueObjects.LoginObj
{
    public class Email : Entity
    {
        public Email(string address)
        {
            Address = address;
            new EmailValidator(this);
        }

        public string Address { get; private set; }
    }
}
