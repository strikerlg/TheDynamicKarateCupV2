using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDynamicKarateCupV2.Models
{ 
    //class especially created to do the many to many join between Competitors and Categories
    //feature is for the moment not build in in the framework
    public class CompetitorCategory
    {
        public int CompetitorID { get; set; }
        public Competitor Competitor { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
