using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.ViewModels.Competitors
{
    public class CompetitorsClubIDViewModel
    {
        public List<Competitor> Competitors { get; set; }
        public int ClubID { get; set; }
    }
}
