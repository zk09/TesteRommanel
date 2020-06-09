using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace User.IO.Rommanel.Domain.Core.Notifications
{
	public class DomainNotificationFilter : IAsyncResultFilter
    {
		private readonly DomainNotification _notificationContext;
		public DomainNotificationFilter(DomainNotification notificationContext)
        {
         
			_notificationContext = notificationContext;

		}
		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if (_notificationContext.HasNotifications)
			{
				context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				context.HttpContext.Response.ContentType = "application/json";

				var notifications = _notificationContext.Notifications.Select(n=> n.Message);

				var result = new
				{
					success = false,
					errors = notifications
				};

				var jsonResult =  JsonConvert.SerializeObject(result);
				await context.HttpContext.Response.WriteAsync(jsonResult);

				return;
			}

			await next();
		}
	}
}
