using System;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
	public class TestimonialManager : ITestimonialService
    {
		private readonly ITestimonialDal _testimonialDal;
		public TestimonialManager(ITestimonialDal testimonialDal)
		{
			_testimonialDal = testimonialDal;
		}

        public void TDelete(Testimonial t)
        {
            _testimonialDal.Delete(t);
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialDal.GetByID(id);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialDal.GetList();
        }

        public async Task TInsertAsync(Testimonial t)
        {
            await _testimonialDal.InsertAsync(t);
        }

        public async Task TUpdateAsync(Testimonial t)
        {
           await _testimonialDal.UpdateAsync(t);
        }
    }
}

