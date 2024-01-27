﻿using SignalR.DataAccessLayer.Abstract;
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
    public class EFSocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        public EFSocialMediaDal(SignalRContext context) : base(context)
        {
        }
    }
}
