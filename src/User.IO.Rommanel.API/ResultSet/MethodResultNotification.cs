using System.Collections.Generic;

namespace User.IO.Rommanel.API.ResultSet
{
    public class MethodResultNotification
    {
        private readonly List<MethodResult> _notifications;
        public IReadOnlyCollection<MethodResult> Notifications => _notifications;
        public MethodResultNotification()
        {
            _notifications = new List<MethodResult>();
        }
       
        public void AddResult(string key, string message)
        {
            _notifications.Add(new MethodResult(key, message));
        }
    }
}
