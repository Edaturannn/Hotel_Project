using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.StaffDtos
{
	public class StaffAddDto
	{
        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string SocialMedia1 { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string SocialMedia2 { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string SocialMedia3 { get; set; }
    }
}

