using System;
using System.Diagnostics.Contracts;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
	public class EFContactDal:GenericRepository<Contact>, IContactDal
    {
		public EFContactDal(Context context) : base(context)
        {

        }
    }
}

