using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Register
{
	public class RegisterViewModel
	{
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }


        [Required]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }


        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }


        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage = "Eposta adresinizi düzgün giriniz…")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Sifre")]
        public string Password { get; set; }


        [Required]
        [DisplayName("Sifre Tekarı")]
        [Compare("Password", ErrorMessage = "Şifreleriniz Uyuşmuyor…")]
        public string RePassword { get; set; }
    }
}

