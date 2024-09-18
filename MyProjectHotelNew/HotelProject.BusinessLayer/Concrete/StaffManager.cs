using System;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
	public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;
        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }
        public void TDelete(Staff t)
        {
            _staffDal.Delete(t);
        }

        public Staff TGetByID(int id)
        {
            return _staffDal.GetByID(id);
        }

        public List<Staff> TGetList()
        {
            return _staffDal.GetList();
        }

        public async Task TInsertAsync(Staff t)
        {
            await _staffDal.InsertAsync(t);
        }

        public async Task TUpdateAsync(Staff t)
        {
            await _staffDal.UpdateAsync(t);
        }
    }
}

