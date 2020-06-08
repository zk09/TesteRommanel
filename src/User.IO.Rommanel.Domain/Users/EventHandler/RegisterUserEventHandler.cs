using MediatR;
using System.Threading;
using System.Threading.Tasks;
using User.IO.Rommanel.Domain.Users.Events;

namespace User.IO.Rommanel.Domain.Users.EventHandler
{
    public class RegisterUserEventHandler :
        INotificationHandler<RegisterUserEvent>
    {
        public Task Handle(RegisterUserEvent notification, CancellationToken cancellationToken)
        {
            //Enviar email
            //Service Bus
            // etc..
            return Task.FromResult(true);
        }
    }
}
