using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDynamicKarateCupV2.Models
{
    public class CategoriesCompetitorsReport : Report
    {
        private List<Category> _categories;

        public void CreateReport(List<Category> categories)
        {
            _categories = categories;
            OpenWorkbook();
            Generate();
        }

        protected override void Generate()
        {
            int row = 3;

            ISheet sheet = workbook.CreateSheet("Categories with competitors");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("Categories with competitors");
            sheet.CreateRow(1).CreateCell(0).SetCellValue("Discipline");
            sheet.GetRow(1).CreateCell(1).SetCellValue("Competitor name");
            sheet.GetRow(1).CreateCell(2).SetCellValue("Competitor license number");
            sheet.GetRow(1).CreateCell(3).SetCellValue("Competitor club name");

            foreach (Category category in _categories)
            {
                sheet.CreateRow(row++).CreateCell(0).SetCellValue(category.Discipline);
                List<Competitor> competitors = GetCompetitors(category.CompetitorCategories.ToList());         
                foreach(Competitor competitor in competitors)
                {
                    sheet.CreateRow(row).CreateCell(1).SetCellValue(competitor.CompetitorFirstname + " " + competitor.CompetitorName);
                    sheet.GetRow(row).CreateCell(2).SetCellValue(competitor.LicenseNumber);
                    sheet.GetRow(row++).CreateCell(3).SetCellValue(competitor.Club.ClubName);
                }
            }

            sheet.AutoSizeColumn(0);
            sheet.AutoSizeColumn(1);
            sheet.AutoSizeColumn(2);
            sheet.AutoSizeColumn(3);
        }

        private List<Competitor> GetCompetitors(List<CompetitorCategory> competitorCategories)
        {
            List<Competitor> competitors = new List<Competitor>();
            foreach(CompetitorCategory competitorCategory in competitorCategories)
            {
                competitors.Add(competitorCategory.Competitor);
            }

            return competitors;
        }
    }
}
