using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.Services
{
    public class CompetitorServices
    {
        private ApplicationDbContext _context;

        public CompetitorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SaveCompetitor(Competitor competitor)
        {
            _context.Competitor.Add(competitor);
            _context.SaveChanges();
        }

        public void UpdateCompetitor(Competitor competitor)
        {
            //Hack to counter dependency injection problem
            Competitor origCompetitor = _context.Competitor.AsNoTracking<Competitor>().SingleOrDefault(c => c.CompetitorID == competitor.CompetitorID);
            _context.Entry<Competitor>(origCompetitor).Context.Update<Competitor>(competitor);
            _context.SaveChanges();
        }

        public void DeleteCompetitor(Competitor competitor)
        {
            CategoryServices categoryService = new CategoryServices(_context);
            categoryService.DeleteExistingCategoriesForCompetitor(competitor);
            _context.Competitor.Remove(competitor);
            _context.SaveChanges();
        }

        public Competitor GetCompetitor(int competitorID)
        {
            return _context.Competitor.Single(m => m.CompetitorID == competitorID);
        }

        public List<Competitor> GetSubscribedCompetitors(int clubID)
        {
            return _context.Set<Competitor>().Where(co => co.ClubID == clubID).ToList();
        }
    }
}
