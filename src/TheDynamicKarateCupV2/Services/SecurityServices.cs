using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.Services
{
    public class SecurityServices
    {
        private ApplicationDbContext _context;

        public SecurityServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsClubIDValidToClubNumber(int clubID, string clubNumber)
        {
            ClubServices service = new ClubServices(_context);
            Club club = service.CheckRegistration(clubNumber);
            if (clubID == club.ClubID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
