using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Login
{
	public class LoginViewModel
	{
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }


        [Required]
        [DisplayName("Sifre")]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}

