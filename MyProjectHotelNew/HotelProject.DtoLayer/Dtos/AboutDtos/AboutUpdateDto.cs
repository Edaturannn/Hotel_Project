using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.AboutDtos
{
	public class AboutUpdateDto
	{
        public int AboutD { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Title1 { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Title2 { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public int RoomCount { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public int StaffCount { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public int CustomerCount { get; set; }
    }
}

