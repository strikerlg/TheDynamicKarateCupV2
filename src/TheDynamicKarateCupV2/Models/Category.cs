using System.Collections.Generic;

namespace TheDynamicKarateCupV2.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Discipline { get; set; }

        public virtual List<CompetitorCategory> CompetitorCategories { get; set; }
    }
}
