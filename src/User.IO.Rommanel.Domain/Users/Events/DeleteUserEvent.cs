using System;

namespace User.IO.Rommanel.Domain.Users.Events
{
    public class DeleteUserEvent:BaseUserEvent
    {
        public DeleteUserEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
