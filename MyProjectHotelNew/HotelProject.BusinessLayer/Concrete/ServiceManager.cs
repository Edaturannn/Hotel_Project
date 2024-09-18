using System;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
	{
		private readonly IServiceDal _serviceDal;
		public ServiceManager(IServiceDal serviceDal)
		{
			_serviceDal = serviceDal;
		}

        public void TDelete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public Service TGetByID(int id)
        {
            return _serviceDal.GetByID(id); //Geriye değer döndürecek...
        }

        public List<Service> TGetList()
        {
            return _serviceDal.GetList(); //Geriye değer döndürecek...
        }

        public async Task TInsertAsync(Service t)
        {
            await _serviceDal.InsertAsync(t); 
        }

        public async Task TUpdateAsync(Service t)
        {
            await _serviceDal.UpdateAsync(t);
        }
    }
}

