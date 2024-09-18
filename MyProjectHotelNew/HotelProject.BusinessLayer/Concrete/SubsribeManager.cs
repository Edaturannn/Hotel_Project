using System;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
	public class SubsribeManager : ISubsribeService
    {
        private readonly ISubsribeDal _subsribeDal;
        public SubsribeManager(ISubsribeDal subsribeDal)
        {
            _subsribeDal = subsribeDal;
        }
        public void TDelete(Subsribe t)
        {
            _subsribeDal.Delete(t);
        }

        public Subsribe TGetByID(int id)
        {
            return _subsribeDal.GetByID(id);
        }

        public List<Subsribe> TGetList()
        {
            return _subsribeDal.GetList();
        }

        public async Task TInsertAsync(Subsribe t)
        {
            await _subsribeDal.InsertAsync(t);
        }

        public async  Task TUpdateAsync(Subsribe t)
        {
            await _subsribeDal.UpdateAsync(t);
        }
    }
}

