using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.Linq;

namespace TheDynamicKarateCupV2.Models
{
    public class ClubsCoachesReport: Report
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

            ISheet sheet = workbook.CreateSheet("Clubs with their coaches");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("Clubs with their coaches");
            
            foreach (Club club in _clubs)
            {
                int freeCoaches = amountCoachesForFree(club.Competitors.Count());
                sheet.CreateRow(row++).CreateCell(0).SetCellValue(club.ClubNumber + " " + club.ClubName);
                sheet.CreateRow(row++).CreateCell(0).SetCellValue(club.ClubName + " heeft recht op " + freeCoaches + " gratis coache(s) !");
                int coaches = 0;
                foreach (Coach coach in club.Coaches)
                {
                    sheet.CreateRow(row).CreateCell(1).SetCellValue(coach.CoachFirstName + " " + coach.CoachName);
                    sheet.GetRow(row++).CreateCell(2).SetCellValue(coach.LicenseNumber);
                    coaches++;
                }
                if (coaches > freeCoaches)
                {
                    row++;
                    sheet.CreateRow(row++).CreateCell(1).SetCellValue(club.ClubName + " moet betalen voor " + (coaches - freeCoaches) + " coache(s) !");
                }
            }

            sheet.AutoSizeColumn(0);
            sheet.AutoSizeColumn(1);
            sheet.AutoSizeColumn(2);
        }

        private int amountCoachesForFree(int amountCompetitors)
        {
            int coaches = 0;
            if (amountCompetitors >= 1)
            {
                coaches = 1;
            }
            if (amountCompetitors > 5)
            {
                coaches = (amountCompetitors / 5);
                if (coaches > 5)
                {
                    coaches = 5;
                }
            }
            return coaches;
        }
    }
}

