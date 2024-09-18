using System;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
	public class EFBookingDal:GenericRepository<Booking>, IBookingDal
	{
		public EFBookingDal(Context context) : base(context)
		{

		}
    }
}

