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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            this.bookingDal = bookingDal;
        }

        public void Add(Booking t)
        {
            bookingDal.Add(t);
        }

        public List<Booking> GetAll()
        {
            return bookingDal.GetAll();
        }

        public Booking GetById(int id)
        {
            return bookingDal.GetById(id);
        }

        public void Remove(Booking t)
        {
            bookingDal.Remove(t);
        }

        public void Update(Booking t)
        {
            bookingDal.Update(t);
        }
    }
}
