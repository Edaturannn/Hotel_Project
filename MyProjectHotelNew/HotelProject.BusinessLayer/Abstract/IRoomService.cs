using System;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
	//ARTIK BURDA TABLOLARI ÖZELLEŞTIRECEĞİZ MESELA FARKLI BİR METHOD KULNAMAK İSTİYORDAK TABLOLYA
    //ENTİTYE BURAYA YAZMAMIZ GEREKİYOR. BURAYA YAZDIĞIMIZ METHODLAR SADECE YAZDIĞIMIZ ENİTİTYİ ETKİLER.
    public interface IRoomService : IGenericService<Room>
	{
	}
}

