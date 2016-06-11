using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheDynamicKarateCupV2.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Clubnumber must exists of 4 digits")]
        public string ClubNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
