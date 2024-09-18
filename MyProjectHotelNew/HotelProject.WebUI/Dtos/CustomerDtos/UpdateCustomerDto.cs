using System;
namespace HotelProject.WebUI.Dtos.CustomerDtos
{
	public class UpdateCustomerDto
	{
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
    }
}

