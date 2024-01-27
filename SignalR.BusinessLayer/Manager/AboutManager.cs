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
    public class AboutManager : IAboutServices
    {
        private readonly IAboutDal aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }

        public void Add(About t)
        {
            aboutDal.Add(t);
        }

        public List<About> GetAll()
        {
            return aboutDal.GetAll();
        }

        public About GetById(int id)
        {
            return aboutDal.GetById(id);
        }

        public void Remove(About t)
        {
            aboutDal.Remove(t);
        }

        public void Update(About t)
        {
            aboutDal.Update(t);
        }
    }
}
