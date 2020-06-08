using System;
using MediatR;

namespace User.IO.Rommanel.Domain.Core.Events
{
    public abstract class Message: INotification,IRequest<bool>
    {
        public string Messagetype { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            Messagetype = GetType().Name;

        }

    }
}
