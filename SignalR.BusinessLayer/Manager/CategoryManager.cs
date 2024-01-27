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
    public class CategoryManager : ICategoryServices
    {
        private readonly ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void Add(Category t)
        {
            categoryDal.Add(t);
        }

        public List<Category> GetAll()
        {
          return categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return categoryDal.GetById(id); 
        }

        public void Remove(Category t)
        {
           categoryDal.Remove(t);
        }

        public void Update(Category t)
        {
            categoryDal.Update(t);
        }
    }
}
