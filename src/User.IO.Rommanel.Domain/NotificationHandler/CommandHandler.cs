using FluentValidation.Results;
using System;
using User.IO.Rommanel.Domain.Core.Notifications;
using User.IO.Rommanel.Domain.Interface;

namespace User.IO.Rommanel.Domain.NotificationHandler
{
    public abstract class CommandHandler
    {
     
        private readonly IUnitOfWork _uow;
        private readonly DomainNotification _notificationContext;
        public CommandHandler(DomainNotification notificationContext,IUnitOfWork uow)
        {
            _uow = uow;
            _notificationContext = notificationContext;

        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
                _notificationContext.AddNotifications(validationResult);
        }

        protected bool Commit()
        {

            // Validar regra de negócio
            if (_notificationContext.HasNotifications) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            Console.WriteLine("Ocorreu um erro ao salvar os dados no banco");
            _notificationContext.AddNotification("Commit", "Ocorreu um erro ao salvar os dados no banco");

            return false;
        }


    }
}
