using System;
namespace HotelProject.DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class //Tüm tablolar yani Entiyler için kullanacağiımız ortak imzalar..
	{
		Task InsertAsync(T t); //Tüm tablolar entityler için ekleme methodun imzası T ise gelecek entity adı...

        void Delete(T t);

		Task UpdateAsync(T t);

		List<T> GetList();

		T GetByID(int id);
	}
}

