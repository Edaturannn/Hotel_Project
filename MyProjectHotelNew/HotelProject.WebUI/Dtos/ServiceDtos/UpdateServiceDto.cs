﻿using System;
namespace HotelProject.WebUI.Dtos.ServiceDtos
{
	public class UpdateServiceDto
	{
        public int ServiceID { get; set; }
        public string ServiceIcon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
