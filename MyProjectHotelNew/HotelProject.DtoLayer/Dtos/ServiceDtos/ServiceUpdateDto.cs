using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.ServiceDtos
{
	public class ServiceUpdateDto
	{
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Description { get; set; }
    }
}

