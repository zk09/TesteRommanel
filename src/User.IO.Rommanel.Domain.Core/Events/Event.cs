using MediatR;
using System;

namespace User.IO.Rommanel.Domain.Core.Events
{
    public abstract class Event :Message
    {
        public DateTime Timestamp { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
