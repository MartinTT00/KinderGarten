using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Kid
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int EGN { get; set; }
        public string Sex { get; set; }

        List<Activity> Activities { get; set; }
        Parent Parents { get; set; }
        List<Location> Locations { get; set; }
        Group Groups { get; set; }
    }
}
