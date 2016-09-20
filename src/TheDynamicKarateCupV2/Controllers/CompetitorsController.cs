using Microsoft.AspNetCore.Mvc;
using TheDynamicKarateCupV2.Models;
using TheDynamicKarateCupV2.Services;
using TheDynamicKarateCupV2.ViewModels.Competitors;

namespace TheDynamicKarateCupV2.Controllers
{
    public class CompetitorsController : Controller
    {
        private ApplicationDbContext _context;

        public CompetitorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Competitors
        public IActionResult Index(int clubID)
        {
            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(clubID, User.Identity.Name);

            if (isValid == true)
            {
                CompetitorServices services = new CompetitorServices(_context);
                CompetitorsClubIDViewModel competitorsClubIDViewModel = new CompetitorsClubIDViewModel();
                competitorsClubIDViewModel.Competitors = services.GetSubscribedCompetitors(clubID);
                competitorsClubIDViewModel.ClubID = clubID;
                return View(competitorsClubIDViewModel);
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        // GET: Competitors/Create
        public IActionResult Create(int clubID)
        {
            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(clubID, User.Identity.Name);

            if (isValid == true)
            {
                CompetitorsViewModel competitorsVM = new CompetitorsViewModel();
                competitorsVM.Competitor = new Competitor();
                competitorsVM.Competitor.ClubID = clubID;
                return View(competitorsVM);
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        // POST: Competitors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Competitor")] CompetitorsViewModel competitorsVM)
        {
            if (ModelState.IsValid)
            {
                SecurityServices secServices = new SecurityServices(_context);
                bool isValid = secServices.IsClubIDValidToClubNumber(competitorsVM.Competitor.ClubID, User.Identity.Name);

                if (isValid == true)
                {
                    CompetitorServices competitorServices = new CompetitorServices(_context);
                    competitorServices.SaveCompetitor(competitorsVM.Competitor);
                    CategoryServices categoryServices = new CategoryServices(_context);
                    categoryServices.DefineCategories(competitorsVM.Competitor);
                    return RedirectToAction("Index", new {clubID = competitorsVM.Competitor.ClubID});
                }
                else
                {
                    return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
                }    
            }
            return View(competitorsVM);
        }

        // GET: Competitors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompetitorServices services = new CompetitorServices(_context);
            Competitor competitor = services.GetCompetitor((int) id);
            if (competitor == null)
            {
                return NotFound();
            }

            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(competitor.ClubID, User.Identity.Name);

            if (isValid == true)
            {
                CompetitorsViewModel competitorsVM = new CompetitorsViewModel();
                competitorsVM.Competitor = competitor;
                return View(competitorsVM);
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        // POST: Competitors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Competitor")] CompetitorsViewModel competitorVM)
        {
            if (ModelState.IsValid)
            {
                SecurityServices secServices = new SecurityServices(_context);
                bool isValid = secServices.IsClubIDValidToClubNumber(competitorVM.Competitor.ClubID, User.Identity.Name);

                if (isValid == true)
                {
                    CompetitorServices services = new CompetitorServices(_context);
                    services.UpdateCompetitor(competitorVM.Competitor);
                    CategoryServices categoryServices = new CategoryServices(_context);
                    categoryServices.DefineCategories(competitorVM.Competitor);
                    return RedirectToAction("Index", new {clubID = competitorVM.Competitor.ClubID});
                }
                else
                {
                    return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
                }               
            }
            return View(competitorVM);
        }

        // GET: Competitors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CompetitorServices competitorServices = new CompetitorServices(_context);
            Competitor competitor = competitorServices.GetCompetitor((int) id);
            if (competitor == null)
            {
                return NotFound();
            }

            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(competitor.ClubID, User.Identity.Name);

            if (isValid == true)
            {
                return View(competitor);
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            } 
        }

        // POST: Competitors/Delete/Competitor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("CompetitorID, CompetitorFirstname, CompetitorName, LicenseNumber, Sex, Level, AgeCategory, Disciplines, ClubID")] Competitor competitor)
        {
            SecurityServices secServices = new SecurityServices(_context);
            bool isValid = secServices.IsClubIDValidToClubNumber(competitor.ClubID, User.Identity.Name);

            if (isValid == true)
            {
                int clubID = competitor.ClubID;
                CompetitorServices competitorServices = new CompetitorServices(_context);
                competitorServices.DeleteCompetitor(competitor);
                return RedirectToAction("Index", new { clubID = clubID });
            }
            else
            {
                return RedirectToAction("YouCanOnlyLookUpYourOwnData", "Verify");
            }
        }

        //Get Competitors/Submit
        // GET: Coaches/Submit
        public IActionResult Submit()
        {
            return View();
        }
    }
}
