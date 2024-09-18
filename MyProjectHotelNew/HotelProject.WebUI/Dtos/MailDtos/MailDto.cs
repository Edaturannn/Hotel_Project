using System;
namespace HotelProject.WebUI.Dtos.MailDtos
{
	public class MailDto
	{
        public string Name { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

