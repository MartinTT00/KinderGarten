using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Parent
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(10)]
        public string EGN { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public List<Kid> Kids { get; set; }
        public List<Location> Locations { get; set; }
    }
}
