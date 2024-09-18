using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.TestimonialDtos
{
	public class TestimonialAddDto
	{
        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Image { get; set; }
    }
}

