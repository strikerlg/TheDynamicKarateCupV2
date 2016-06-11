using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using TheDynamicKarateCupV2.Models;

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
        public IActionResult Index()
        {
            var applicationDbContext = _context.Coach.Include(c => c.Club);
            return View(applicationDbContext.ToList());
        }

        // GET: Coaches/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Coach coach = _context.Coach.Single(m => m.CoachID == id);
            if (coach == null)
            {
                return HttpNotFound();
            }

            return View(coach);
        }

        // GET: Coaches/Create
        public IActionResult Create()
        {
            ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "Club");
            return View();
        }

        // POST: Coaches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Coach.Add(coach);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "Club", coach.ClubID);
            return View(coach);
        }

        // GET: Coaches/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Coach coach = _context.Coach.Single(m => m.CoachID == id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "Club", coach.ClubID);
            return View(coach);
        }

        // POST: Coaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Update(coach);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ClubID"] = new SelectList(_context.Club, "ClubID", "Club", coach.ClubID);
            return View(coach);
        }

        // GET: Coaches/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Coach coach = _context.Coach.Single(m => m.CoachID == id);
            if (coach == null)
            {
                return HttpNotFound();
            }

            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Coach coach = _context.Coach.Single(m => m.CoachID == id);
            _context.Coach.Remove(coach);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
