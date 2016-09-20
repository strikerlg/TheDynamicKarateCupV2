using Microsoft.AspNetCore.Mvc;
using TheDynamicKarateCupV2.Models;
using TheDynamicKarateCupV2.Services;
using TheDynamicKarateCupV2.ViewModels.Coaches;

namespace TheDynamicKarateCupV2.Controllers
{
    public class CoachesController : Controller
    {
        private ApplicationDbContext _context;

        public CoachesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Coaches
        public IActionResult Index(int clubID)
        {
            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(clubID, User.Identity.Name);

            if (isValid == true)
            {
                CoachServices coachServices = new CoachServices(_context);
                CoachesViewModel coachesViewModel = coachServices.CreateCoachesViewModel(clubID);
                return View(coachesViewModel);
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        // GET: Coaches/Create
        public IActionResult Create(int clubID)
        {
            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(clubID, User.Identity.Name);

            if (isValid == true)
            {
                Coach coach = new Coach();
                coach.ClubID = clubID;
                return View(coach);
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        // POST: Coaches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CoachFirstName, CoachName, LicenseNumber, ClubID")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                SecurityServices secServices = new SecurityServices(_context);
                bool isValid = secServices.IsClubIDValidToClubNumber(coach.ClubID, User.Identity.Name);

                if (isValid == true)
                {
                    CoachServices coachServices = new CoachServices(_context);
                    coachServices.SaveCoach(coach);
                    return RedirectToAction("Index", new { clubID = coach.ClubID });
                }
                else
                {
                    return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
                }
            }
            return View(coach);
        }

        // GET: Coaches/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoachServices services = new CoachServices(_context);
            Coach coach = services.GetCoach((int)id);
            if (coach == null)
            {
                return NotFound();
            }

            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(coach.ClubID, User.Identity.Name);

            if (isValid == true)
            {
                return View(coach);
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        // POST: Coaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("CoachID, CoachFirstName, CoachName, LicenseNumber, ClubID")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                SecurityServices secServices = new SecurityServices(_context);
                bool isValid = secServices.IsClubIDValidToClubNumber(coach.ClubID, User.Identity.Name);

                if (isValid == true)
                {
                    CoachServices services = new CoachServices(_context);
                    services.UpdateCoach(coach);
                    return RedirectToAction("Index", new { clubID = coach.ClubID });
                }
                else
                {
                    return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
                }
            }
            return View(coach);
        }

        // GET: Coaches/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CoachServices coachServices = new CoachServices(_context);
            Coach coach = coachServices.GetCoach((int)id);
            if (coach == null)
            {
                return NotFound();
            }

            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(coach.ClubID, User.Identity.Name);

            if (isValid == true)
            {
                return View(coach);
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        // POST: Coaches/Delete/Coach
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("CoachID, CoachFirstName, CoachName, LicenseNumber, ClubID")] Coach coach)
        {
            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(coach.ClubID, User.Identity.Name);

            if (isValid == true)
            {
                int clubID = coach.ClubID;
                CoachServices services = new CoachServices(_context);
                services.DeleteCoach(coach);
                return RedirectToAction("Index", new { clubID = clubID });
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        // GET: Coaches/Submit
        public IActionResult Submit()
        {
            return View();
        }
    }
}
