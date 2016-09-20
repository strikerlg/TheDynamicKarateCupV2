using Microsoft.AspNetCore.Mvc;
using TheDynamicKarateCupV2.Models;
using TheDynamicKarateCupV2.Services;

namespace TheDynamicKarateCupV2.Controllers
{
    public class ClubController : Controller
    {
        private ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Club/Create
        public IActionResult Create()
        {
            Club club = new Club();
            club.ClubNumber = User.Identity.Name;
            return View(club);
        }

        // POST: Club/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ClubName, ResponsibleName, ResponsibleCellullar, ResponsibleEmail, ClubNumber")] Club club)
        {
            if (ModelState.IsValid)
            {
                ClubServices services = new ClubServices(_context);
                services.SaveClub(club);
                return RedirectToAction("WhatToDoNow", "Verify", new { clubID = club.ClubID });
            }
            return View(club);
        }

        // GET: Club/Edit/5
        public IActionResult Edit(int clubID)
        {
            SecurityServices services = new SecurityServices(_context);
            bool isValid = services.IsClubIDValidToClubNumber(clubID, User.Identity.Name);

            if (isValid == true)
            {
                ClubServices clubServices = new ClubServices(_context);
                Club club = clubServices.GetClub(clubID);
                if (club == null)
                {
                    return NotFound();
                }
                return View(club);
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        // POST: Club/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("ClubID, ClubName, ResponsibleName, ResponsibleCellullar, ResponsibleEmail, ClubNumber")] Club club)
        {
            if (ModelState.IsValid)
            {
                SecurityServices services = new SecurityServices(_context);
                bool isValid = services.IsClubIDValidToClubNumber(club.ClubID, User.Identity.Name);

                if (isValid == true)
                {
                    ClubServices clubServices = new ClubServices(_context);
                    clubServices.UpdateClub(club);
                    return RedirectToAction("WhatToDoNow", "Verify", new { clubID = club.ClubID });
                }
                else
                {
                    return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
                }
            }
            return View(club);
        }
    }
}
