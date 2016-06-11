using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheDynamicKarateCupV2.Models
{
    public class Competitor
    {
        public int CompetitorID { get; set; }
        [Display(Name ="Firstname competitor"), Required(ErrorMessage = "Firstname competitor is mandatory!")]
        public string CompetitorFirstname { get; set; }
        [Display(Name ="Name competitor"), Required(ErrorMessage = "Name competitor is mandatory!")]
        public string CompetitorName { get; set; }
        [Display(Name ="License number"), Required(ErrorMessage = "Licensenumber is mandatory!"), RegularExpression("^[0-9]{1,6}$", ErrorMessage = "License number may only consists of maximum 6 figures!")]
        public string LicenseNumber { get; set; }
        [Display(Name ="Sex"), Required(ErrorMessage = "Sex is mandatory!")]
        public string Sex { get; set; }
        [Display(Name ="Level"), Required(ErrorMessage = "Level is mandatory!")]
        public string Level { get; set; }
        [Display(Name ="Age category"), Required(ErrorMessage = "Age category is mandatory!")]
        public string AgeCategory { get; set; }
        [Display(Name = "Disciplines"), Required(ErrorMessage = "Discipline is mandatory!")]
        public string Disciplines { get; set; }

        public int ClubID { get; set; }
        public virtual Club Club { get; set; }
        public virtual List<CompetitorCategory> CompetitorCategories { get; set; }
    }
}