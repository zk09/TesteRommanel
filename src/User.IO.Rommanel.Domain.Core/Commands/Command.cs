using MediatR;
using System;
using User.IO.Rommanel.Domain.Core.Events;

namespace User.IO.Rommanel.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
