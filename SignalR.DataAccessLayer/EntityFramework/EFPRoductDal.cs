using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignR.Entitylayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EFPRoductDal : GenericRepository<Product>, IProductDal
    {
        public EFPRoductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetListWithCategories()
        {
           var context = new SignalRContext();
            var list = context.Products.Include(x=>x.Category).ToList();
            return list;
        }
    }
}
