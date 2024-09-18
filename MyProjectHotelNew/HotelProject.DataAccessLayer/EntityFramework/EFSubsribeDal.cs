using System;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
	public class EFSubsribeDal : GenericRepository<Subsribe>, ISubsribeDal
    {
		public EFSubsribeDal(Context context) : base(context)
		{
		}
	}
}

