﻿using System;
namespace HotelProject.WebUI.Dtos.BookingDtos
{
	public class UpdateBookingDto
	{
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public string AdultCount { get; set; }
        public string ChilCount { get; set; }
        public string RoomCount { get; set; }

        public string SpecialRequest { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }
    }
}
