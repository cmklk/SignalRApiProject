using SignalR.BusinessLayer.Services;
using SignalR.DataAccessLayer.Abstract;
using SignR.Entitylayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Manager
{
    public class TestimonialManager : ITestimonialServices
    {
        private readonly ITestimonialDal testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            this.testimonialDal = testimonialDal;
        }

        public void Add(Testimonial t)
        {
            testimonialDal.Add(t);
        }

        public List<Testimonial> GetAll()
        {
            return testimonialDal.GetAll();
        }

        public Testimonial GetById(int id)
        {
            return testimonialDal.GetById(id);
        }

        public void Remove(Testimonial t)
        {
           testimonialDal.Remove(t);
        }

        public void Update(Testimonial t)
        {
            testimonialDal.Update(t);
        }
    }
}
