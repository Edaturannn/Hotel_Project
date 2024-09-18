using System;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
	//ARTIK BURDA TABLOLARI ÖZELLEŞTIRECEĞİZ MESELA FARKLI BİR METHOD KULNAMAK İSTİYORDAK TABLOLYA
	//ENTİTYE BURAYA YAZMAMIZ GEREKİYOR. BURAYA YAZDIĞIMIZ METHODLAR SADECE YAZDIĞIMIZ ENİTİTYİ ETKİLER.
	public class EFRoomDal : GenericRepository<Room>, IRoomDal
	{
		public EFRoomDal(Context context) : base(context)
		{

		}
    }
}

