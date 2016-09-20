using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.Services
{
    public class ReportServices
    {
        private ApplicationDbContext _context;

        public ReportServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public MemoryStream GetCategoriesAndCompetitors()
        {
            List<Category> categories = _context.Category
                                            .Include(category => category.CompetitorCategories)
                                            .ThenInclude(compcat => compcat.Competitor)
                                            .ThenInclude(competitor => competitor.Club)
                                            .ToList();

            CategoriesCompetitorsReport report = new CategoriesCompetitorsReport();
            report.CreateReport(categories);
            return report.GetWorkbook();
        }

        public MemoryStream GetClubs()
        {
            List<Club> clubs = _context.Club.ToList();

            ClubsInfoReport report = new ClubsInfoReport();
            report.CreateReport(clubs);
            return report.GetWorkbook();
        }

        public MemoryStream GetClubsWithCompetitors()
        {
            List<Club> clubs = _context.Club.Include(club => club.Competitors).ToList();

            ClubsCompetitorsReport report = new ClubsCompetitorsReport();
            report.CreateReport(clubs);
            return report.GetWorkbook();
        }

        public MemoryStream GetClubsWithCoaches()
        {
            List<Club> clubs = _context.Club.Include(club => club.Coaches)
                                            .Include(club => club.Competitors).ToList();

            ClubsCoachesReport report = new ClubsCoachesReport();
            report.CreateReport(clubs);
            return report.GetWorkbook();
        }
    }
}
