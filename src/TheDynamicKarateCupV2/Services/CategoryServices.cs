using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.Services
{
    public class CategoryServices
    {
        private ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DefineCategories(Competitor competitor)
        {
            DeleteExistingCategoriesForCompetitor(competitor);
            DefineCategoriesOnAge(competitor);
            DefineCategoriesOnGrade(competitor); 
        }

        public void DeleteExistingCategoriesForCompetitor(Competitor competitor)
        {
            List<CompetitorCategory> cclist = _context.Set<CompetitorCategory>().Where(cc => cc.CompetitorID == competitor.CompetitorID).ToList<CompetitorCategory>();
            _context.Set<CompetitorCategory>().RemoveRange(cclist);
        }

        #region Private methods
        private void DefineCategoriesOnAge(Competitor competitor)
        {
            if (competitor.AgeCategory == "Pupillen")
            {
                DefinePupilCategories(competitor);
            }

            if (competitor.AgeCategory == "Preminiemen")
            {
                DefinePreminimCategories(competitor);
            }

            if (competitor.AgeCategory == "Miniemen")
            {
                DefineMinimeCategories(competitor);
            }

            if (competitor.AgeCategory == "Kadetten")
            {
                DefineCadetCategories(competitor);
            }

            if (competitor.AgeCategory == "Scholieren")
            {
                DefineStudentCategories(competitor);
            }

            if (competitor.AgeCategory == "Junioren")
            {
                DefineJuniorCategories(competitor);
            }

            if (competitor.AgeCategory == "Senioren")
            {
                DefineSeniorCategories(competitor);
            }
        }

        private void DefinePupilCategories(Competitor competitor)
        {
            #region Kata Mixed & Kumite Mixed
            if (competitor.Disciplines == "Kata & Kumite")
            {
                #region Pupils Kata & Kumite -> Kata
                //check of de kata discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "PupilsKataMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "PupilsKataMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor          
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                #endregion

                #region Pupils Kata & Kumite -> Kumite
                //check of de kumite discipline bestaat 
                category = _context.Category.AsNoTracking().Single(c => c.Discipline == "PupilsKumiteMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "PupilsKumiteMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                #endregion
            }
            #endregion

            #region Kata Mixed
            if (competitor.Disciplines == "Kata")
            {
                //check of de kata discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "PupilsKataMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "PupilsKataMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion

            #region Kumite Mixed
            if (competitor.Disciplines == "Kumite")
            {
                //check of de kumite discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "PupilsKumiteMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "PupilsKumiteMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion
        }

        private void DefinePreminimCategories(Competitor competitor)
        {
            #region Kata Mixed & Kumite Mixed
            if (competitor.Disciplines == "Kata & Kumite")
            {
                #region Preminims Kata & Kumite -> Kata
                //check of de kata discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "PreminimsKataMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "PreminimsKataMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                #endregion

                #region Preminims Kata & Kumite -> Kumite
                //check of de kumite discipline bestaat 
                category = _context.Category.AsNoTracking().Single(c => c.Discipline == "PreminimsKumiteMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "PreminimsKumiteMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                #endregion
            }
            #endregion

            #region Kata Mixed
            if (competitor.Disciplines == "Kata")
            {
                //check of de kata discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "PreminimsKataMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "PreminimsKataMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion

            #region Kumite Mixed
            if (competitor.Disciplines == "Kumite")
            {
                //check of de kumite discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "PreminimsKumiteMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "PreminimsKumiteMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion
        }

        private void DefineMinimeCategories(Competitor competitor)
        {
            #region Kata Mixed & Kumite Mixed
            if (competitor.Disciplines == "Kata & Kumite")
            {
                #region Minims Kata & Kumite -> Kata
                //check of de kata discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "MinimsKataMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "MinimsKataMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                #endregion

                #region Minims Kata & Kumite -> Kumite
                //check of de kumite discipline bestaat 
                category = _context.Category.AsNoTracking().Single(c => c.Discipline == "MinimsKumiteMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "MinimsKumiteMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                #endregion
            }
            #endregion

            #region Kata Mixed
            if (competitor.Disciplines == "Kata")
            {
                //check of de kata discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "MinimsKataMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "MinimsKataMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion

            #region Kumite Mixed
            if (competitor.Disciplines == "Kumite")
            {
                //check of de kumite discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "MinimsKumiteMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "MinimsKumiteMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion
        }

        private void DefineCadetCategories(Competitor competitor)
        {
            #region Kata Mixed & Kumite Men & Kumite Ladies
            if (competitor.Disciplines == "Kata & Kumite")
            {
                #region Cadets Kata Mixed & Kumite Men & Kumite Ladies -> Kata Mixed
                //check of de kata discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "CadetsKataMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "CadetsKataMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                #endregion

                #region Cadets Kata Mixed & Kumite Men & Kumite Ladies -> Kumite Men
                if(competitor.Sex == "Male")
                {
                    //check of de kumite discipline bestaat 
                    category = _context.Category.AsNoTracking().Single(c => c.Discipline == "CadetsKumiteMen");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "CadetsKumiteMen" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
                #endregion

                #region Cadets Kata Mixed & Kumite Men & Kumite Ladies -> Kumite Ladies
                if (competitor.Sex == "Female")
                {
                    //check of de kumite discipline bestaat 
                    category = _context.Category.AsNoTracking().Single(c => c.Discipline == "CadetsKumiteLadies");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "CadetsKumiteLadies" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
                #endregion
            }
            #endregion
            
            #region Kata Mixed
            if (competitor.Disciplines == "Kata")
            {
                //check of de kata discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "CadetsKataMixed");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "CadetsKataMixed" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion

            #region Kumite Men
            if (competitor.Disciplines == "Kumite" && competitor.Sex == "Male")
            {
                //check of de kumite discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "CadetsKumiteMen");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "CadetsKumiteMen" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion

            #region Kumite Ladies
            if (competitor.Disciplines == "Kumite" && competitor.Sex == "Female")
            {
                //check of de kumite discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "CadetsKumiteLadies");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "CadetsKumiteLadies" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion
        }

        private void DefineStudentCategories(Competitor competitor)
        {
            #region Grade Kata & Kumite Men & Kumite Ladies
            if (competitor.Disciplines == "Kata & Kumite")
            {
                #region Grade Kata & Kumite Men & Kumite Ladies -> Grade Kata
                //Kata categorie zal toegevoegd worden volgens de graad van de deelnemer
                #endregion

                #region Grade Kata & Kumite Men & Kumite Ladies -> Kumite Men
                if (competitor.Sex == "Male")
                {
                    //check of de kumite discipline bestaat 
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "StudentsKumiteMen");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "StudentsKumiteMen" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
                #endregion

                #region Grade Kata & Kumite Men & Kumite Ladies -> Kumite Ladies
                if (competitor.Sex == "Female")
                {
                    //check of de kumite discipline bestaat 
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "StudentsKumiteLadies");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "StudentsKumiteLadies" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
                #endregion
           }
            #endregion

            #region Kumite Men
            if(competitor.Disciplines == "Kumite" && competitor.Sex == "Male")
            {
                //check of de kumite discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "StudentsKumiteMen");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "StudentsKumiteMen" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion

            #region Kumite Ladies
            if (competitor.Disciplines == "Kumite" && competitor.Sex == "Female")
            {
                //check of de kumite discipline bestaat 
                var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "StudentsKumiteLadies");
                //als de discipline niet bestaat voeg ze toe
                if (category == null)
                {
                    category = new Category { Discipline = "StudentsKumiteLadies" };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                }
                //voeg de categorie toe aan de competitor
                competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
            }
            #endregion
        }

        private void DefineJuniorCategories(Competitor competitor)
        {
            if (competitor.Level != "Dan" && competitor.Level != "1e Kyu")
            {
                #region Grade Kata & Kumite Men & Kumite Ladies
                if (competitor.Disciplines == "Kata & Kumite")
                {
                    #region Grade Kata & Kumite Men & Kumite Ladies -> Grade Kata
                    //Kata categorie zal toegevoegd worden volgens de graad van de deelnemer
                    #endregion

                    #region Grade Kata & Kumite Men & Kumite Ladies -> Kumite Men
                    if (competitor.Sex == "Male")
                    {
                        //check of de kumite discipline bestaat 
                        var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "JuniorsKumiteMen");
                        //als de discipline niet bestaat voeg ze toe
                        if (category == null)
                        {
                            category = new Category { Discipline = "JuniorsKumiteMen" };
                            _context.Category.Add(category);
                            _context.SaveChanges();
                        }
                        //voeg de categorie toe aan de competitor
                        competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                    }
                    #endregion

                    #region Grade Kata & Kumite Men & Kumite Ladies -> Kumite Ladies
                    if (competitor.Sex == "Female")
                    {
                        //check of de kumite discipline bestaat 
                        var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "JuniorsKumiteLadies");
                        //als de discipline niet bestaat voeg ze toe
                        if (category == null)
                        {
                            category = new Category { Discipline = "JuniorsKumiteLadies" };
                            _context.Category.Add(category);
                            _context.SaveChanges();
                        }
                        //voeg de categorie toe aan de competitor
                        competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                    }
                    #endregion
                }
                #endregion

                #region Kumite Men
                if (competitor.Disciplines == "Kumite" && competitor.Sex == "Male")
                {
                    //check of de kumite discipline bestaat 
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "JuniorsKumiteMen");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "JuniorsKumiteMen" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
                #endregion

                #region Kumite Ladies
                if (competitor.Disciplines == "Kumite" && competitor.Sex == "Female")
                {
                    //check of de kumite discipline bestaat 
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "JuniorsKumiteLadies");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "JuniorsKumiteLadies" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
                #endregion
            }
        }
        
        private void DefineSeniorCategories(Competitor competitor)
        {
            if (competitor.Level != "Dan" && competitor.Level != "1e Kyu")
            {
                #region Grade Kata & Kumite Men & Kumite Ladies
                if (competitor.Disciplines == "Kata & Kumite")
                {
                    #region Grade Kata & Kumite Men & Kumite Ladies -> Grade Kata
                    //Kata categorie zal toegevoegd worden volgens de graad van de deelnemer
                    #endregion

                    #region Grade Kata & Kumite Men & Kumite Ladies -> Kumite Men
                    if (competitor.Sex == "Male")
                    {
                        //check of de kumite discipline bestaat 
                        var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "SeniorsKumiteMen");
                        //als de discipline niet bestaat voeg ze toe
                        if (category == null)
                        {
                            category = new Category { Discipline = "SeniorsKumiteMen" };
                            _context.Category.Add(category);
                            _context.SaveChanges();
                        }
                        //voeg de categorie toe aan de competitor
                        competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                    }
                    #endregion

                    #region Grade Kata & Kumite Men & Kumite Ladies -> Kumite Ladies
                    if (competitor.Sex == "Female")
                    {
                        //check of de kumite discipline bestaat 
                        var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "SeniorsKumiteLadies");
                        //als de discipline niet bestaat voeg ze toe
                        if (category == null)
                        {
                            category = new Category { Discipline = "SeniorsKumiteLadies" };
                            _context.Category.Add(category);
                            _context.SaveChanges();
                        }
                        //voeg de categorie toe aan de competitor
                        competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                    }
                    #endregion
                }
                #endregion

                #region Kumite Men
                if (competitor.Disciplines == "Kumite" && competitor.Sex == "Male")
                {
                    //check of de kumite discipline bestaat 
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "SeniorsKumiteMen");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "SeniorsKumiteMen" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
                #endregion

                #region Kumite Ladies
                if (competitor.Disciplines == "Kumite" && competitor.Sex == "Female")
                {
                    //check of de kumite discipline bestaat 
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "SeniorsKumiteLadies");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "SeniorsKumiteLadies" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
                #endregion
            }
        }

        private void DefineCategoriesOnGrade(Competitor competitor)
        {
            #region Blue belts Kata
            //blauwe gordels kata
            if (competitor.Level == "5e Kyu" || competitor.Level == "4e Kyu")
            {
                if (competitor.Disciplines == "Kata & Kumite" || competitor.Disciplines == "Kata")
                {
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "BlueKataMixed");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "BlueKataMixed" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
            }
            #endregion

            #region Brown belts Kata
            //bruine gordels kata
            if (competitor.Level == "3e Kyu" || competitor.Level == "2e Kyu")
            {
                if (competitor.Disciplines == "Kata & Kumite" || competitor.Disciplines == "Kata")
                {
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "BrownKataMixed");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "BrownKataMixed" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
            }
            #endregion

            #region Open Kata
            //open gordels kata dames
            if ((competitor.Level == "1e Kyu" || competitor.Level == "Dan") && competitor.Sex == "Female")
            {
                if (competitor.Disciplines == "Kata & Kumite" || competitor.Disciplines == "Kata")
                {
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "OpenKataLadies");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "OpenKataLadies" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
            }

            //open gordels kata heren
            if ((competitor.Level == "1e Kyu" || competitor.Level == "Dan") && competitor.Sex == "Male")
            {
                if (competitor.Disciplines == "Kata & Kumite" || competitor.Disciplines == "Kata")
                {
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "OpenKataMen");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "OpenKataMen" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
            }
            #endregion

            #region Open Kumite
            //open gordels kumite dames
            if ((competitor.Level == "1e Kyu" || competitor.Level == "Dan") && competitor.Sex == "Female")
            {
                if (competitor.Disciplines == "Kata & Kumite" || competitor.Disciplines == "Kumite")
                {
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "OpenKumiteLadies");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "OpenKumiteLadies" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
            }

            //open gordels kumite heren
            if ((competitor.Level == "1e Kyu" || competitor.Level == "Dan") && competitor.Sex == "Male")
            {
                if (competitor.Disciplines == "Kata & Kumite" || competitor.Disciplines == "Kumite")
                {
                    var category = _context.Category.AsNoTracking().Single(c => c.Discipline == "OpenKumiteMen");
                    //als de discipline niet bestaat voeg ze toe
                    if (category == null)
                    {
                        category = new Category { Discipline = "OpenKumiteMen" };
                        _context.Category.Add(category);
                        _context.SaveChanges();
                    }
                    //voeg de categorie toe aan de competitor
                    competitor.CompetitorCategories.Add(AddCompetitorCategorieToJoinClass(competitor, category));
                }
            }
            #endregion

        }

        private CompetitorCategory AddCompetitorCategorieToJoinClass(Competitor competitor, Category category)
        {
            var cc = new CompetitorCategory();
            cc.Competitor = competitor;
            cc.CompetitorID = competitor.CompetitorID;
            cc.Category = category;
            cc.CategoryID = category.CategoryID;
            return cc;
        }
        #endregion
    }
}
