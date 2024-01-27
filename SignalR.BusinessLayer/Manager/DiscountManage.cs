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
    public class DiscountManage : IDiscountServices
    {
        private readonly IDiscountDal discountDal;

        public DiscountManage(IDiscountDal discountDal)
        {
            this.discountDal = discountDal;
        }

        public void Add(Discount t)
        {
            discountDal.Add(t);
        }

        public List<Discount> GetAll()
        {
            return discountDal.GetAll();
        }

        public Discount GetById(int id)
        {
            return discountDal.GetById(id);
        }

        public void Remove(Discount t)
        {
           discountDal.Remove(t);
        }

        public void Update(Discount t)
        {
            discountDal.Update(t);
        }
    }
}
