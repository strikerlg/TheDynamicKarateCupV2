using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.Services
{
    public class ClubServices
    {
        private ApplicationDbContext _context;

        public ClubServices(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public Club CheckRegistration(string clubNumber)
        {
            //AsNoTracking is used to counter dependency injection problem
            return _context.Set<Club>().AsNoTracking().SingleOrDefault(club => club.ClubNumber == clubNumber);
        }

        public Club GetClub(int clubID)
        {
            //AsNoTracking is used to counter dependency injection problem
            return _context.Club.AsNoTracking().Single(m => m.ClubID == clubID);
        }
            
        public void SaveClub(Club club)
        {
            _context.Club.Add(club);
            _context.SaveChanges();
        }

        public void UpdateClub(Club club)
        {
            //Hack to counter dependency injection problem
            Club origClub = _context.Club.AsNoTracking<Club>().SingleOrDefault(c => c.ClubID == club.ClubID);
            _context.Entry<Club>(origClub).Context.Update<Club>(club);
            _context.SaveChanges();  
        }
    }
}
