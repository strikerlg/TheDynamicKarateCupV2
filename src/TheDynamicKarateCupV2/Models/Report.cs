using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace TheDynamicKarateCupV2.Models
{
    public abstract class Report
    {
        protected IWorkbook workbook;

        protected void OpenWorkbook()
        {
            workbook = new XSSFWorkbook();
        }

        protected abstract void Generate();

        public MemoryStream GetWorkbook()
        {
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            return ms;
        }
    }
}
