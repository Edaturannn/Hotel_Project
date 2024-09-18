using System;
using AutoMapper;
using HotelProject.DtoLayer.Dtos.CustomerDtos;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDtos;
using HotelProject.WebUI.Dtos.BookingDtos;
using HotelProject.WebUI.Dtos.ContactDtos;
using HotelProject.WebUI.Dtos.CustomerDtos;
using HotelProject.WebUI.Dtos.RoomDtos;
using HotelProject.WebUI.Dtos.ServiceDtos;
using HotelProject.WebUI.Dtos.StaffDtos;
using HotelProject.WebUI.Dtos.SubsribeDtos;
using HotelProject.WebUI.Dtos.TestimonialDtos;
using HotelProject.WebUI.Models.Booking;
using HotelProject.WebUI.Models.Subsribe;

namespace HotelProject.WebUI.Mapping
{
	public class AutoMapperConfig:Profile
	{
        public AutoMapperConfig()
        {
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();

            CreateMap<CreateRoomDto, Room>().ReverseMap();
            CreateMap<ResultRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();

            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();

            CreateMap<CreateStaffDto, Staff>().ReverseMap();
            CreateMap<ResultStaffDto, Staff>().ReverseMap();
            CreateMap<UpdateStaffDto, Staff>().ReverseMap();

            CreateMap<CreateSubsribeDto, Subsribe>().ReverseMap();
            CreateMap<ResultSubsribeDto, Subsribe>().ReverseMap();
            CreateMap<UpdateSubsribeDto, Subsribe>().ReverseMap();

            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();

            CreateMap<CreateCustomerDto, Customer>().ReverseMap();
            CreateMap<ResultCustomerDto, Customer>().ReverseMap();
            CreateMap<UpdateCustomerDto, Customer>().ReverseMap();

            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, CreateCustomerDto>();
        }
    }
}

