using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDynamicKarateCupV2.Models
{
    public class ClubsInfoReport: Report
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
            int row = 3;

            ISheet sheet = workbook.CreateSheet("Info Subscribed clubs");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("Info Subscribed clubs");
            sheet.CreateRow(1).CreateCell(0).SetCellValue("Club number");
            sheet.GetRow(1).CreateCell(1).SetCellValue("Club name");
            sheet.GetRow(1).CreateCell(2).SetCellValue("Responsible name");
            sheet.GetRow(1).CreateCell(3).SetCellValue("Responsible GSM number");
            sheet.GetRow(1).CreateCell(4).SetCellValue("Responsible E-mail");

            foreach (Club club in _clubs)
            {
                sheet.CreateRow(row).CreateCell(0).SetCellValue(club.ClubNumber);
                sheet.GetRow(row).CreateCell(1).SetCellValue(club.ClubName);
                sheet.GetRow(row).CreateCell(2).SetCellValue(club.ResponsibleName);
                sheet.GetRow(row).CreateCell(3).SetCellValue(club.ResponsibleCellullar);
                sheet.GetRow(row++).CreateCell(4).SetCellValue(club.ResponsibleEmail);
            }

            sheet.AutoSizeColumn(0);
            sheet.AutoSizeColumn(1);
            sheet.AutoSizeColumn(2);
            sheet.AutoSizeColumn(3);
            sheet.AutoSizeColumn(4);
        }
    }
}

