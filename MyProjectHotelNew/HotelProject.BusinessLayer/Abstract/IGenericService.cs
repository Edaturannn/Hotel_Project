using System;
namespace HotelProject.BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		//Ortak methodların imzasını attık...
		Task TInsertAsync(T t);
		void TDelete(T t);
		Task TUpdateAsync(T t);
		List<T> TGetList();
		T TGetByID(int id);
	}
}

