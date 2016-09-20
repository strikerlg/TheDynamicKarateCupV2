using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheDynamicKarateCupV2.Models;
using TheDynamicKarateCupV2.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheDynamicKarateCupV2.Controllers
{
    public class VerifyController : Controller
    {
        private ApplicationDbContext _context;

        public VerifyController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public IActionResult CheckRegistration()
        {
            ClubServices service = new ClubServices(_context);
            Club club = service.CheckRegistration(User.Identity.Name);
            //Console.WriteLine(User.Identity.Name);
            
            if(club == null)
            {
                return RedirectToAction("Create", "Club");
            }
            else
            {
                return RedirectToAction("WhatToDoNow", new { clubID = club.ClubID });
            }
        }

        public IActionResult WhatToDoNow(int clubID)
        {
            SecurityServices services = new SecurityServices(_context);
            bool isValid = services.IsClubIDValidToClubNumber(clubID, User.Identity.Name);
            if (isValid == true)
            {
                return View("WhatToDoNow", clubID);
            }
            else
            {
                return View("YouCanOnlyLookUpYourOwnData");
            }
        }
    }
}
