using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDynamicKarateCupV2.Models
{
    public class ClubsCompetitorsReport: Report
    {
        private List<Club> _clubs;

        public void CreateReport(List<Club> clubs)
        {
            _clubs = clubs;
            OpenWorkbook();
            Generate();
        }

        protected override void Generate()
        {
            int row = 2;

            ISheet sheet = workbook.CreateSheet("Clubs with their competitors");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("Clubs with their competitors");
            
            foreach (Club club in _clubs)
            {
                sheet.CreateRow(row++).CreateCell(0).SetCellValue(club.ClubNumber + " " + club.ClubName);
                foreach (Competitor competitor in club.Competitors)
                {
                    sheet.CreateRow(row).CreateCell(1).SetCellValue(competitor.CompetitorFirstname + " " + competitor.CompetitorName);
                    sheet.GetRow(row++).CreateCell(2).SetCellValue(competitor.Disciplines);
                }
            }

            sheet.AutoSizeColumn(0);
            sheet.AutoSizeColumn(1);
            sheet.AutoSizeColumn(2);
        }
    }
}

