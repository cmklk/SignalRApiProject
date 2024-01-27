﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.Dto.ContactDto
{
    public class UpdateContactDto
    {
        public int ContactID { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FooterDescription { get; set; }
    }
}