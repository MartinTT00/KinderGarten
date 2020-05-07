﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EGN { get; set; }
        public string Sex { get; set; }

        public int PhoneNumber { get; set; }

        List<Kid> Kids { get; set; }
        List<Location> Locations { get; set; }
    }
}
