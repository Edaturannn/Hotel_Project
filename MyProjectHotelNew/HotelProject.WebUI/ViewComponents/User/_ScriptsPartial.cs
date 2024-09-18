using System;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.User
{
	public class _ScriptsPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}

