using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.EntityLayer.Concrete
{
	public class Service
	{
		[Key]
        public int ServiceID { get; set; }
        public string ServiceIcon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

