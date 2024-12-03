using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeControlWinForms.EPPlus
{
    internal static class ExcelExport
    {
        //SIMPLE EXPORT
        internal static void SimpleGridExport(DataGridView dataGridView1, string pageName)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(sfd.FileName);
                    using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                        var headerRange = worksheet.Cells[1, 1, 1, dataGridView1.Columns.Count - 1];
                        headerRange.Merge = true;
                        headerRange.Value = pageName;

                        headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        headerRange.Style.Font.Bold = true;

                        headerRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        headerRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        headerRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        headerRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                        // Копируем заголовки
                        for (int j = 1; j < dataGridView1.Columns.Count; j++)
                        {
                            worksheet.Cells[2, j].Value = dataGridView1.Columns[j].HeaderText;
                            // Устанавливаем рамки для заголовков
                            worksheet.Cells[2, j].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[2, j].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[2, j].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[2, j].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                var cellValue = dataGridView1.Rows[i].Cells[j].Value;
                                worksheet.Cells[i + 3, j].Value = cellValue;

                                worksheet.Cells[i + 3, j].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[i + 3, j].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[i + 3, j].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[i + 3, j].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            }
                        }

                        worksheet.Cells.AutoFitColumns();

                        excelPackage.Save(); // Сохранение файла
                    }
                }
            }
        }
    }
}
