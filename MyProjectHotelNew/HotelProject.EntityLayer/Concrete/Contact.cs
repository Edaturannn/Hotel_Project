using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.EntityLayer.Concrete
{
	public class Contact
	{
		[Key]
		public int ContactID { get; set; }
		public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
		public DateTime Date { get; set; } = DateTime.Today;
    }
}

