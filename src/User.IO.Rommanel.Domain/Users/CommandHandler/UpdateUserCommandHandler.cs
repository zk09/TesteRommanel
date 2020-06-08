using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using User.IO.Rommanel.Domain.Core.Notifications;
using User.IO.Rommanel.Domain.Interface;
using User.IO.Rommanel.Domain.Users.Commands;
using User.IO.Rommanel.Domain.Users.Events;
using User.IO.Rommanel.Domain.Users.Repository;
using static User.IO.Rommanel.Domain.Users.User;

namespace User.IO.Rommanel.Domain.Users.CommandHandler
{
    public class UpdateUserCommandHandler : NotificationHandler.CommandHandler,
       IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly DomainNotification _notificationContext;
     

        public UpdateUserCommandHandler(IUserRepository userRepository,
         IUnitOfWork uow, IMediator mediator, DomainNotification notificationContext) : base(notificationContext,uow)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!ExistUser(request.Id, request.Messagetype)) return false;

            var user = UserFactory.UpdateUser(request.Id, request.Name, request.Email, request.Cpf.OnlyNumbers(), request.DateBirth, request.City, request.ZipCode.OnlyNumbers(), request.State);

            if (!UserValid(user)) return false;

            _userRepository.Update(user);

            if (Commit())
            {
                // notificar processo concluido
                await _mediator.Publish(new UpdateUserEvent(request.Id, request.Name, request.Email, request.Cpf, request.DateBirth, request.City, request.ZipCode, request.State));
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

        private bool UserValid(User user)
        {
            if (user.IsValid()) return true;


            NotificarValidacoesErro(user.ValidationResult);
            return false;

        }
    }
}
