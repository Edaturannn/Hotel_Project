using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.UserDtos
{
	public class UserRegisteDto
	{
		[Required(ErrorMessage ="Boş Geçmeyiniz!!!")]
		public string Username { get; set; } = string.Empty;

		[Required(ErrorMessage ="Boş Geçmeyiniz!!!")]
		public string Password { get; set; } = string.Empty;
	}
}

