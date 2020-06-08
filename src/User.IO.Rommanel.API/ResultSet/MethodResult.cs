using System.Collections.Generic;

namespace User.IO.Rommanel.API.ResultSet
{
	public  class MethodResult
    {
		
		public  string Key { get; }
		public  string Message { get; }

		public MethodResult(string key, string message)
		{
			Key = key;
			Message = message;
		}
	}
}
