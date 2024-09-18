using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.ContactDtos
{
	public class ContactUpdateDto
	{
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public DateTime Date { get; set; } = DateTime.Today;
    }
}

