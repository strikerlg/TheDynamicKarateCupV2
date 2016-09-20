using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TheDynamicKarateCupV2.Models;
using TheDynamicKarateCupV2.ViewModels.Coaches;

namespace TheDynamicKarateCupV2.Services
{
    public class CoachServices { 
    
        private ApplicationDbContext _context;

        public CoachServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SaveCoach(Coach coach)
        {
            _context.Coach.Add(coach);
            _context.SaveChanges();
        }

        public void UpdateCoach(Coach coach)
        {
            //Hack to counter dependency injection problem
            try
            {
                Coach origCoach = _context.Coach.AsNoTracking<Coach>().SingleOrDefault(c => c.CoachID == coach.CoachID);
                _context.Entry<Coach>(origCoach).Context.Update<Coach>(coach);
                _context.SaveChanges();
            }
            catch (Exception err)
            {
                err.Message.ToString();
            }
        }

        public void DeleteCoach(Coach coach)
        {
            _context.Coach.Remove(coach);
            _context.SaveChanges();
        }

        public Coach GetCoach(int coachID)
        {
            return _context.Coach.Where(c => c.CoachID == coachID).SingleOrDefault();
        }

        public CoachesViewModel CreateCoachesViewModel(int clubID)
        {
            int amountAcceptedCoaches = DefineAmountAcceptedCoaches(clubID);
            int amountSubscribedCoaches = GetAmountSubscribedCoaches(clubID);

            string infoHowManyCoaches = DefineInfoHowManyCoaches(amountAcceptedCoaches, amountSubscribedCoaches);

            CoachesViewModel coachesViewModel = new CoachesViewModel();
            coachesViewModel.InfoHowManyCoaches = infoHowManyCoaches;
            coachesViewModel.Coaches = GetSubscribedCoaches(clubID);
            coachesViewModel.ClubID = clubID;

            return coachesViewModel;
	    }

        private string DefineInfoHowManyCoaches(int amountAcceptedCoaches, int amountSubscribedCoaches)
        {
            if(amountAcceptedCoaches == 0)
            {
                return "Gelieve eerst uw deelnemers in te geven! \n D'abord remplir la liste des compétiteurs!";
            }

            if (amountSubscribedCoaches == (amountAcceptedCoaches - 1))
            {
                return "U kan nog 1 coach gratis toevoegen! \n Vous pouvez encore introduire 1 coach gratuit!";
            }

            if (amountSubscribedCoaches >= amountAcceptedCoaches)
            {
                return "Per coach dat u toevoegt gaat u 5€ moeten bijbetalen! \n Par coach extra vous devez payer 5€!";
            }
            else { 
                return "U kan nog " + (amountAcceptedCoaches - amountSubscribedCoaches) + " coach(es) gratis toevoegen! \n Vous pouvez encore introduire " + (amountAcceptedCoaches - amountSubscribedCoaches) + " coaches gratuit!";
            }       
        }

        private int DefineAmountAcceptedCoaches(int clubID)
        {
            CompetitorServices competitorServices = new CompetitorServices(_context);
            int amountAcceptedCoaches = 0;

            int amountSubscribedCompetitors = competitorServices.GetAmountSubscribedCompetitors(clubID);
            
            if(amountSubscribedCompetitors == 0)
            {
                amountAcceptedCoaches = 0;
            }
            else if (amountSubscribedCompetitors < 5)
            {
                amountAcceptedCoaches = 1;
            }
            else
            {
                amountAcceptedCoaches = (amountSubscribedCompetitors / 5);
                if (amountAcceptedCoaches > 5)
                {
                    amountAcceptedCoaches = 5;
                }
            }
            return amountAcceptedCoaches;
        }

        private int GetAmountSubscribedCoaches(int clubID)
        {
            return _context.Coach.FromSql("SELECT CoachID FROM Coach WHERE ClubID = " + clubID + " ").Count();
        }

        private List<Coach> GetSubscribedCoaches(int clubID)
        {
            return _context.Set<Coach>().Where(co => co.ClubID == clubID).ToList();
        }
    }
}
