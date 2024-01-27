using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Services
{
    public interface IGenericServices<T> where T : class
    {
        void Add(T t);
        void Remove(T t);
        void Update(T t);
        List<T> GetAll();
        T GetById(int id);
    }
}
