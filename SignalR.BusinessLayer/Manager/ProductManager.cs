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
    public class ProductManager : IProductServices
    {
        private readonly IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void Add(Product t)
        {
            productDal.Add(t);
        }

        public List<Product> GetAll()
        {
            return productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return productDal.GetById(id);
        }

        public void Remove(Product t)
        {
          productDal.Remove(t);
        }

        public List<Product> TGetListWithCategory()
        {
           return productDal.GetListWithCategories();
        }

        public void Update(Product t)
        {
           productDal.Update(t);
        }
    }
}
