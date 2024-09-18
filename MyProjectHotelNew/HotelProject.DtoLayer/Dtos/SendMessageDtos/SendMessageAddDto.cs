using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.SendMessageDtos
{
	public class SendMessageAddDto
	{
        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string ReceiverMail { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string SenderMail { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz!!!")]
        public string Content { get; set; }
    }
}

