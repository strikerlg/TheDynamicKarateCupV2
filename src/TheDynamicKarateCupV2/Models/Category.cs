using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDynamicKarateCupV2.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Discipline { get; set; }

        public virtual List<CompetitorCategory> CompetitorCategories { get; set; }
    }
}
