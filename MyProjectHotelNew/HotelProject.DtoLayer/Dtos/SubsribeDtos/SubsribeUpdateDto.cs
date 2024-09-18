using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.SubsribeDtos
{
	public class SubsribeUpdateDto
	{
        public int SubsribeID { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Mail { get; set; }
    }
}

