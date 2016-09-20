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

        [Display(Name = "License number"), Required(ErrorMessage = "Licensenumber is mandatory!"), RegularExpression("^[0-9]{1,6}$", ErrorMessage = "License number may only consists of maximum 6 figures!")]
        public string LicenseNumber { get; set; }

        public int ClubID { get; set; }
        public virtual Club Club { get; set; }
    }
}
