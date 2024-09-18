using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.RoomDtos
{
	public class RoomUpdateDto
	{
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string BathCount { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Wifi { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Description { get; set; }
    }
}

