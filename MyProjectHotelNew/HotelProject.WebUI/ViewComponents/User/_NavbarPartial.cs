using System;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.User
{
	public class _NavbarPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}

