using System.Collections.Generic;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.ViewModels.Coaches
{
    public class CoachesViewModel
    {
        public string InfoHowManyCoaches { get; set; }

        public int ClubID { get; set; }

        public List<Coach> Coaches { get; set; }

    }
}
