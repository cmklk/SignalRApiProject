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
    public class FeatureManager : IFeaturesServices
    {
        private readonly IFeatureDal featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            this.featureDal = featureDal;
        }

        public void Add(Feature t)
        {
            featureDal.Add(t);
        }

        public List<Feature> GetAll()
        {
          return featureDal.GetAll();
        }

        public Feature GetById(int id)
        {
           return featureDal.GetById(id);
        }

        public void Remove(Feature t)
        {
            featureDal.Remove(t);
        }

        public void Update(Feature t)
        {
           featureDal.Update(t);
        }
    }
}
