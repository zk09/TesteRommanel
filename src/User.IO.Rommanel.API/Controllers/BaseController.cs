using Microsoft.AspNetCore.Mvc;
using User.IO.Rommanel.Domain.Core.Notifications;

namespace User.IO.Rommanel.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotification _notificationContext;
   
        public BaseController(DomainNotification notificationContext)
        {
            _notificationContext = notificationContext;
        
        }

        protected bool OperacaoValida()
        {
            return (!_notificationContext.HasNotifications);
        }
    }
}
