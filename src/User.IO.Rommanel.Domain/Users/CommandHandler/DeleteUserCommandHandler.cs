using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using User.IO.Rommanel.Domain.Core.Notifications;
using User.IO.Rommanel.Domain.Interface;
using User.IO.Rommanel.Domain.Users.Commands;
using User.IO.Rommanel.Domain.Users.Events;
using User.IO.Rommanel.Domain.Users.Repository;

namespace User.IO.Rommanel.Domain.Users.CommandHandler
{
    public class DeleteUserCommandHandler : NotificationHandler.CommandHandler,
         IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly DomainNotification _notificationContext;

        public DeleteUserCommandHandler(IUserRepository userRepository,
         IUnitOfWork uow, IMediator mediator, DomainNotification notificationContext) : base(notificationContext,uow)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (!ExistUser(request.Id, request.Messagetype)) return false;

            //Valiadacoes de negocios
            //...
            //...
            _userRepository.Delete(request.Id);

            if (Commit())
            {
               await _mediator.Publish(new DeleteUserEvent(request.Id));
               return true;
            }

            return false;
        }

        private bool ExistUser(Guid id, string messageType)
        {
            var user = _userRepository.GetById(id);

            if (user != null) return true;

            _notificationContext.AddNotification(messageType, "Usuário não encontrado");

            return false;
        }

    }
}
