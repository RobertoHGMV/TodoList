using System.Collections.Generic;
using TodoList.Common.Notifications;
using TodoList.Common.Validations;

namespace TodoList.Common.Entities
{
    public class Entity
    {
        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public IReadOnlyCollection<Notification> Notifications { get; private set; }

        public Entity()
        {
            Valid = true;
            Notifications = new List<Notification>();
        }

        public bool Validate(Validation validation)
        {
            Notifications = validation.Notifications;
            return Valid = !validation.HasNotifications;
        }
    }
}
