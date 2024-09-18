using System;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.User
{
	public class _AboutUsPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly Context _context;
		public _AboutUsPartial(IHttpClientFactory httpClientFactory, Context context)
		{
			_httpClientFactory = httpClientFactory;
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7212/api/About");
			if (responseMessage.IsSuccessStatusCode)
			{
                ViewBag.roomscount = _context.Rooms.Count().ToString();
                ViewBag.staffscount = _context.Staffs.Count().ToString();
                ViewBag.customerscount = _context.Customers.Count().ToString();
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
				return View(values);
			}
            return View();
		}
	}
}
