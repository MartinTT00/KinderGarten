﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Parent Parents { get; set; }
        public Kid Kids { get; set; }
    }
}
