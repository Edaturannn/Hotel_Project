using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.EntityLayer.Concrete
{
	public class Subsribe
	{
		[Key]
        public int SubsribeID { get; set; }
        public string Mail { get; set; }
    }
}

