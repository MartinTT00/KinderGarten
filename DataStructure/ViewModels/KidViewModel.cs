using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModels
{
    public class KidViewModel
    {

            public int Id { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }

            public string EGN { get; set; }
            public string Sex { get; set; }
            public List<Activity> Activities { get; set; }
            public int ParentId { get; set; }
            public List<Location> Locations { get; set; }
            public Group Groups { get; set; }
        }
    }

