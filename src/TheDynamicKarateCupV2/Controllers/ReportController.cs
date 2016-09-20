using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDynamicKarateCupV2.Models;
using Microsoft.EntityFrameworkCore;
using TheDynamicKarateCupV2.Services;

namespace TheDynamicKarateCupV2.Controllers
{
    public class ReportController: Controller
    {
        private ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetCategoriesCompetitors()
        {
            ReportServices report = new ReportServices(_context);
            return File(report.GetCategoriesAndCompetitors().ToArray(), "application/vnd.ms-excel", "CategoriesWithCompetitors.xls");
        }

        public IActionResult GetClubs()
        {
            ReportServices report = new ReportServices(_context);
            return File(report.GetClubs().ToArray(), "application/vnd.ms.excel", "InfoSubscribedClubs.xls");
        }

        public IActionResult GetClubsWithCompetitors()
        {
            ReportServices report = new ReportServices(_context);
            return File(report.GetClubsWithCompetitors().ToArray(), "application/vnd.ms.excel", "ClubsWithCompetitors.xls");
        }

        public IActionResult GetClubsWithCoaches()
        {
            ReportServices report = new ReportServices(_context);
            return File(report.GetClubsWithCoaches().ToArray(), "application/vnd.ms.excel", "ClubsWithCoaches.xls");
        }
    }
}
