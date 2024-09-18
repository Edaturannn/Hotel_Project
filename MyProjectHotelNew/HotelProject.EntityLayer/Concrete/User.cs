using System;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.EntityLayer.Concrete
{
	public class User
	{
		[Key]
		public int UserID { get; set; }
		public string Username { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }

		//API İÇİN BİR GİRİŞ YANI JWT TOKEN İLE BİR GİRİŞ SİSTEMİ HAZIRLIYORUZ. BU DA USER TABLOSU
		//KAYIT OLAN KULLANICILAR BU USER TABLOSUNA EKLENECEK. GİRİŞ YAPAN KULLANICI BİR GİRİŞ TOKENI OLUŞACAK.
		//AMA TOKEN BİR VERİTABANI ÜZERİNDE TUTULMAYACAK. BELLİ BİR SÜRESİ OLACAK. O SÜRE SONRASINDA ÖLECEK TOKEN YANİ GEÇERSİZ OLACAK.
		//GİRİŞ YAPMAYAN KİŞİLER API İÇİNDEKİ TABLOLARI GÖREMEYECEK ULAŞAMAYACAK.
		//GİRİŞ YAPIPI OLUŞAN GİRİŞ TOKEN I KONTROLÜ OAUTH2.0 İLE KONTROL EDİLECEK.
	}
}

