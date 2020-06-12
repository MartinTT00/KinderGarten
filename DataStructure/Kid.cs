using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Kid
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }


        [Required]
        [MinLength(6)]
        [MaxLength(10)]
        public string EGN { get; set; }

        [Required]
        public string Sex { get; set; }
        public List<Activity> Activities { get; set; }
        public Parent Parents { get; set; }
        public List<Location> Locations { get; set; }
        public virtual Group Groups { get; set; }
    }
}
