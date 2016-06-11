using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheDynamicKarateCupV2.Models
{
    public class Coach
    {
        public int CoachID { get; set; }
        [Display(Name ="Firstname coach"), Required(ErrorMessage = "Firstname coach is mandatory!")]
        public string CoachFirstName { get; set; }
        [Display(Name ="Name coach"), Required(ErrorMessage = "Name coach is mandatory!")]
        public string CoachName { get; set; }

        public string CoachFirstNameName
        {
            get
            {
                return CoachFirstName + " " + CoachName;
            }
        }

        public int ClubID { get; set; }
        public virtual Club Club { get; set; }
    }
}
