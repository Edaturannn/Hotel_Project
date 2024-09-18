using System;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
	public class EFSendMessageDal:GenericRepository<SendMessage>, ISendMessageDal
	{
		public EFSendMessageDal(Context context) : base(context)
		{

		}
    }
}

