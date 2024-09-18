using System;
using HotelProject.DataAccessLayer.ServiceResponse;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.AuthRepository
{
	public interface IAuthRepository //GİRİŞ İÇİN METHODLARIN İMZASINI ATIYORUZ.
	{
		Task<ServiceResponse<int>> Register(User user, string password); //Kayıt olma Methodu.

		Task<ServiceResponse<string>> Login(string username, string password); //Giriş yapma Method.

		Task<bool> UserExists(string username); //Çıkış yapma Methodu.

	}
}

