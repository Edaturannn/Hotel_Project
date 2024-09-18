using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.CustomerDtos
{
	public class CustomerAddDto
	{
        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string City { get; set; }
    }
}

