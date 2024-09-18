using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.BookingDtos
{
	public class BookingUpdateDto
	{
		public int BookingID { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string AdultCount { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string ChilCount { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string RoomCount { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string SpecialRequest { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Status { get; set; }
	}
}

