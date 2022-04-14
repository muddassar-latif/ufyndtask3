using NLog;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Hotel.API
{
	public class ExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext context)
		{
			ILogger _logger = LogManager.GetCurrentClassLogger();
			_logger.Error(context.Exception.Message);
		}
	}
}