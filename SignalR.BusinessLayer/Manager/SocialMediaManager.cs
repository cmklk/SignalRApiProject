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
    public class SocialMediaManager : ISocialMediaServices
    {
        private readonly ISocialMediaDal socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            this.socialMediaDal = socialMediaDal;
        }

        public void Add(SocialMedia t)
        {
           socialMediaDal.Add(t);
        }

        public List<SocialMedia> GetAll()
        {
            return socialMediaDal.GetAll();
        }

        public SocialMedia GetById(int id)
        {
            return socialMediaDal.GetById(id);
        }

        public void Remove(SocialMedia t)
        {
          socialMediaDal.Remove(t);
        }

        public void Update(SocialMedia t)
        {
            socialMediaDal.Update(t);
        }
    }
}
