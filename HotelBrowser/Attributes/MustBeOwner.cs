using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using HotelBrowser.Core.Contracts;
using HotelBrowser.Controllers;
using System.Security.Claims;

namespace HotelBrowser.Attributes
{
	public class MustBeOwner : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			IOwnerService? agentService = context.HttpContext.RequestServices.GetService<IOwnerService>();

			if (agentService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}


			if (agentService != null
				&& agentService.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
			{
				context.Result = new RedirectToActionResult(nameof(OwnerController.Become), "Owner", null);
			}
		}
	}
}
