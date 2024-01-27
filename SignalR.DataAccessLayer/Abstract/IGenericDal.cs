using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();
        void Add (T t);
        void Remove (T t);
        void Update (T t);
        T GetById(int id);
    }
}
