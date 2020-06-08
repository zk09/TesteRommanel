using System;
using User.IO.Rommanel.Domain.Core.Events;

namespace User.IO.Rommanel.Domain.Users.Events
{
    public class BaseUserEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Cpf { get; protected set; }
        public DateTime DateBirth { get; protected set; }
        public string City { get; protected set; }
        public string ZipCode { get; protected set; }
        public string State { get; protected set; }

    }
}
