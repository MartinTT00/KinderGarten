using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Kid> Kids { get; set; }
    }
}
