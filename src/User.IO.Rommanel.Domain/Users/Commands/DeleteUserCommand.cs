using System;

namespace User.IO.Rommanel.Domain.Users.Commands
{
    public class DeleteUserCommand:BaseUserCommand
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
