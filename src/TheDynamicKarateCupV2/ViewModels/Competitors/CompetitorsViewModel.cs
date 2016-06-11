using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.ViewModels.Competitors
{
    public class CompetitorsViewModel
    {
        public Competitor Competitor { get; set; }

        public List<SelectListItem> GetSex()
        {
            return new List<SelectListItem>{
                                            new SelectListItem { Text = "Male", Value = "Male" },
                                            new SelectListItem { Text = "Female", Value = "Female" }
                                           };
        }

        public List<SelectListItem> GetLevelList()
        {
            return new List<SelectListItem>{
                                            new SelectListItem { Text = "Other", Value = "Other"},
                                            new SelectListItem { Text = "5e Kyu", Value = "5e Kyu"},
                                            new SelectListItem { Text = "4e Kyu", Value = "4e Kyu"},
                                            new SelectListItem { Text = "3e Kyu", Value = "3e Kyu"},
                                            new SelectListItem { Text = "2e Kyu", Value = "2e Kyu"},
                                            new SelectListItem { Text = "1e Kyu", Value = "1e Kyu"},
                                            new SelectListItem { Text = "Dan", Value = "Dan"}
                                           };
        }

        public List<SelectListItem> GetAgeCategoryList()
        {
            return new List<SelectListItem>{
                                            new SelectListItem { Text = "2006 - 2007", Value = "Pupillen"},
                                            new SelectListItem { Text = "2004 - 2005", Value = "Preminiemen"},
                                            new SelectListItem { Text = "2002 - 2003", Value = "Miniemen"},
                                            new SelectListItem { Text = "2000 - 2001", Value = "Kadetten"},
                                            new SelectListItem { Text = "1998 - 1999", Value = "Scholieren"},
                                            new SelectListItem { Text = "1995 - 1996 - 1997", Value = "Junioren"},
                                            new SelectListItem { Text = "1994 and before", Value = "Senioren"}
                                           };
        }

        public List<SelectListItem> GetSelectedDisciplines()
        {
            return new List<SelectListItem>{
                                            new SelectListItem { Text = "Kata & Kumite", Value = "Kata & Kumite"},
                                            new SelectListItem { Text = "Kata", Value = "Kata"},
                                            new SelectListItem { Text = "Kumite", Value = "Kumite"}
                                           };

        }
    }
}
