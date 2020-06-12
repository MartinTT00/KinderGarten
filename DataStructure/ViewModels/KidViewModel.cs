using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.ViewModels
{
    public class KidViewModel
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
            public int ParentId { get; set; }
            public List<Location> Locations { get; set; }
            public int GroupID { get; set; }
            public virtual Group Groups { get; set; }

        public KidViewModel() { }

        public KidViewModel(Kid kid)
        {
            Name = kid.Name;
            Age = kid.Age;
            EGN = kid.EGN;
            Sex = kid.Sex;
            Groups = kid.Groups;
        }
        public static List<KidViewModel> ToList(ICollection<Kid> kids)
        {
            List<KidViewModel> kidViewModels = new List<KidViewModel>();
            foreach (Kid kid in kids)
            {
                KidViewModel kidViewModel = new KidViewModel(kid);
                kidViewModels.Add(kidViewModel);
            }
            return kidViewModels;
        }
    }
    }

