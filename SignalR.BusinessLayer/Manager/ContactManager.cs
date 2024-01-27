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
    public class ContactManager : IContactServices
    {
        private readonly IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public void Add(Contact t)
        {
           contactDal.Add(t);
        }

        public List<Contact> GetAll()
        {
            return contactDal.GetAll();
        }

        public Contact GetById(int id)
        {
            return contactDal.GetById(id);
        }

        public void Remove(Contact t)
        {
            contactDal.Remove(t);
        }

        public void Update(Contact t)
        {
            contactDal.Update(t);
        }
    }
}
