using System;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;

namespace HotelProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class //Ortak method imzalarının içini dolduraçağız...
    {
        private readonly Context _context;
        public GenericRepository(Context context) //Service çağırdık. Dependency SOLID prensibini kullandık... CRUD İŞLEMLERİNİ YAZDIK VERİ TABANI İLE İLETİŞİM KURACAGIMIZ ALAN BU CLASS
        {
            _context = context;
        }
        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges(); //Veri tabanı ile iletişim kurduğumuz await kullanmalıyız...
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public async Task InsertAsync(T t)
        {
            _context.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _context.Update(t);
           await _context.SaveChangesAsync();
        }
    }
}

