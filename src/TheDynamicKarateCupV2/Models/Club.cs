using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.Models
{
    public class Club
    {
        public int ClubID { get; set; }
        [Display(Name ="Club name"), Required(ErrorMessage = "Club name is mandatory!")]
        public string ClubName { get; set; }
        [Display(Name ="Club number"), Required(ErrorMessage = "Club number is mandatory!"), RegularExpression("^[0-9]{4}$", ErrorMessage = "Club number must consist of 4 numbers!")]
        public string ClubNumber { get; set; }
        [Display(Name ="Name responsible"), Required(ErrorMessage = "Name responsible is mandatory!")]
        public string ResponsibleName { get; set; }
        [Display(Name ="Email responsible"), Required(ErrorMessage = "Email responsible is mandatory!"), DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "Email responsible is not a valid email address!")]
        public string ResponsibleEmail { get; set; }
        [Display(Name ="GSM number responsible"), Required(ErrorMessage = "GSM number responsible is mandatory!"), RegularExpression("^0[0-9]{9}$", ErrorMessage = "GSM number must consists of 10 numbers and it must start with a 0!")]
        public string ResponsibleCellullar { get; set; }

        public virtual List<Competitor> Competitors { get; set; }
        public virtual List<Coach> Coaches { get; set; }
    }
}
