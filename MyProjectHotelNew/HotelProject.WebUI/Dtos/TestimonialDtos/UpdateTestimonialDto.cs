﻿using System;
namespace HotelProject.WebUI.Dtos.TestimonialDtos
{
	public class UpdateTestimonialDto
	{
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}

