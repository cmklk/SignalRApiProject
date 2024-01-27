using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly SignalRContext _context;
        public GenericRepository(SignalRContext context)
        {
         _context = context;
        }
        public void Add(T t)
        {
           _context.Add(t);
           _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();  
        }

        public T GetById(int id)
        {
           return _context.Set<T>().Find(id);
        }

        public void Remove(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}
