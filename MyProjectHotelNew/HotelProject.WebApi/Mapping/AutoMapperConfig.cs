using System;
using AutoMapper;
using HotelProject.DtoLayer.Dtos.AboutDtos;
using HotelProject.DtoLayer.Dtos.BookingDtos;
using HotelProject.DtoLayer.Dtos.ContactDtos;
using HotelProject.DtoLayer.Dtos.CustomerDtos;
using HotelProject.DtoLayer.Dtos.MessageCategoryDtos;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.DtoLayer.Dtos.SendMessageDtos;
using HotelProject.DtoLayer.Dtos.ServiceDtos;
using HotelProject.DtoLayer.Dtos.StaffDtos;
using HotelProject.DtoLayer.Dtos.SubsribeDtos;
using HotelProject.DtoLayer.Dtos.TestimonialDtos;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<RoomAddDto, Room>();
			CreateMap<Room, RoomAddDto>();

			CreateMap<ServiceAddDto, Service>();
			CreateMap<Service, ServiceAddDto>();

            CreateMap<StaffAddDto, Staff>();
            CreateMap<Staff, StaffAddDto>();

            CreateMap<SubsribeAddDto, Subsribe>();
            CreateMap<Subsribe, SubsribeAddDto>();

            CreateMap<TestimonialAddDto, Testimonial>();
            CreateMap<Testimonial, TestimonialAddDto>();

            CreateMap<AboutAddDto, About>();
            CreateMap<About, AboutAddDto>();

            CreateMap<BookingAddDto, Booking>();
            CreateMap<Booking, BookingAddDto>();

            CreateMap<ContactAddDto, Contact>();
            CreateMap<Contact, ContactAddDto>();

            CreateMap<CustomerAddDto, Customer>();
            CreateMap<Customer, CustomerAddDto>();

            CreateMap<SendMessageAddDto, SendMessage>();
            CreateMap<SendMessage, SendMessageAddDto>();

           


            CreateMap<RoomUpdateDto, Room>().ReverseMap();
            CreateMap<ServiceUpdateDto, Service>().ReverseMap();
            CreateMap<StaffUpdateDto, Staff>().ReverseMap();
            CreateMap<SubsribeUpdateDto, Subsribe>().ReverseMap();
            CreateMap<TestimonialUpdateDto, Testimonial>().ReverseMap();
            CreateMap<AboutUpdateDto, About>().ReverseMap();
            CreateMap<BookingUpdateDto, Booking>().ReverseMap();
            CreateMap<ContactUpdateDto, Contact>().ReverseMap();
            CreateMap<CustomerUpdateDto, Customer>().ReverseMap();
            CreateMap<SendMessageUpdateDto, SendMessage>().ReverseMap();
        }
    }
}

