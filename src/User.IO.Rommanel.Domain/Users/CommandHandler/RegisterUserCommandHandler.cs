using MediatR;
using System.Threading;
using System.Threading.Tasks;
using User.IO.Rommanel.Domain.Core.Notifications;
using User.IO.Rommanel.Domain.Interface;
using User.IO.Rommanel.Domain.Users.Commands;
using User.IO.Rommanel.Domain.Users.Events;
using User.IO.Rommanel.Domain.Users.Repository;
using System;
using System.Linq;

namespace User.IO.Rommanel.Domain.Users.CommandHandler
{
    public class RegisterUserCommandHandler: NotificationHandler.CommandHandler,
        IRequestHandler<RegisterUserCommand,bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly DomainNotification _notificationContext;
        public RegisterUserCommandHandler(IUserRepository userRepository, DomainNotification notificationContext,
         IUnitOfWork uow, IMediator mediator) : base(notificationContext,uow)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _notificationContext = notificationContext;
     
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.Cpf.OnlyNumbers(), request.DateBirth, request.City, request.ZipCode.OnlyNumbers(), request.State);
        
            if (!UserValid(user))
            {

                ExistCpfAndEmail(user, request.Messagetype);

                return false;
            }

            if (ExistCpfAndEmail(user,request.Messagetype))
            {
                return false;
            }

            _userRepository.Add(user);

            if (Commit())
            {
                // notificar processo concluido
              await _mediator.Publish(new RegisterUserEvent(user.Id, request.Name, request.Email, request.Cpf, request.DateBirth, request.City, request.ZipCode, request.State));
              return true;
            }

            return false;

        }

        private bool ExistCpfAndEmail(User user, string messageType)
        {
            var baseUserCPF = _userRepository.Search(x => x.Cpf.Equals(user.Cpf)).ToList();
            var baseUserEmail = _userRepository.Search(x => x.Email.Equals(user.Email)).ToList();

            if (baseUserCPF.Any())
            {
                _notificationContext.AddNotification(messageType,"CPF já cadastrado no sistema!");
                
            }

            if (baseUserEmail.Any())
            {
                _notificationContext.AddNotification(messageType, "Email já cadastrado no sistema!");
            }

            if (_notificationContext.HasNotifications)
            {
                return true;
            }

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
