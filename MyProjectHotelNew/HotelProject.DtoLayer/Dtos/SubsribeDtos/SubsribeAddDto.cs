using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.SubsribeDtos
{
	public class SubsribeAddDto
	{
        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Mail { get; set; }
    }
}

