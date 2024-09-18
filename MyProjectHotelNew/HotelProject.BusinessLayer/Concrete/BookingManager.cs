using System;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
	public class BookingManager:IBookingService
	{
		private readonly IBookingDal _bookingDal;
		public BookingManager(IBookingDal bookingDal)
		{
			_bookingDal = bookingDal;
		}

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public Booking TGetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public async Task TInsertAsync(Booking t)
        {
            await _bookingDal.InsertAsync(t);
        }

        public async Task TUpdateAsync(Booking t)
        {
            await _bookingDal.UpdateAsync(t);
        }
    }
}

