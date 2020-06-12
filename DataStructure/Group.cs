using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Kid> Kids { get; set; }
    }
}
