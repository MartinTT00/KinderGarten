using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string Address { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(40)]

        public string City { get; set; }
        public Parent Parents { get; set; }
        public Kid Kids { get; set; }
    }
}
