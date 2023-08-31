using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;

public class ExcelDataReader
{
    public int GetFilteredNumber()
    {
        string filePath = "G:/Dhaulagiri/Tableau Data Source/Control Room (NO touch)/Forecast impact productivity/Inbound Shop start WIP history.xlsx";
        int targetNumber = 0;

        using (var excelPackage = new ExcelPackage(new FileInfo(filePath)))
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();

            if (worksheet != null)
            {
                int rowCount = worksheet.Dimension.Rows;

                DateTime today = DateTime.Today;

                for (int row = 2; row <= rowCount; row++)
                {
                    DateTime currentDate = Convert.ToDateTime(worksheet.Cells[row, 1].Value);

                    if (currentDate.Date == today)
                    {
                        int currentNumber = Convert.ToInt32(worksheet.Cells[row, 3].Value);

                        if (currentNumber > targetNumber)
                        {
                            targetNumber = currentNumber;
                        }
                    }
                }
            }
        }

        return targetNumber;
    }
}
