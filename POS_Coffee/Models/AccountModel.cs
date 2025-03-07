﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public bool isActive { get; set; }
    }
}
