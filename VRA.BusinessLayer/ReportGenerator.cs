using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using VRA.Dto;
using System.Windows.Forms;
using CheckManager;

namespace VRA.BusinessLayer
{
    class ReportGenerator : IReportGenerator
    {
        public void fillExcelTableByType(IEnumerable<object> grid, string currentTable, FileInfo xlsxFile)
        {
            if (grid != null)
            {
                ExcelPackage pck = new ExcelPackage(xlsxFile);
                var excel = pck.Workbook.Worksheets.Add(currentTable);
                int x = 1;
                int y = 1;
                // Устанавливает фиксированный десятичный разделитель (нужно для верногораспознавания типа данных Excel'ем).
                CultureInfo cultureInfo = new
                CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                // Первая строка (шапка таблицы) – жирным стилем.
                excel.Cells["A1: Z1"].Style.Font.Bold = true;
                // Выравнивание текста в ячейках – по левому краю.
                excel.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                // Устанавливает формат ячеек.
                excel.Cells.Style.Numberformat.Format = "General";
                // Пустой объект для получения списка property.
                Object dtObj = new Object();
                switch (currentTable)
                {
                    case "Worker":
                        dtObj = new WorkerDto();
                        break;
                    case "Division":
                        dtObj = new DivisionDto();
                        break;
                    case "ExpenseByWorker":
                        dtObj = new ExpenseDto();
                        break;
                    case "TypeExpense":
                        dtObj = new TypeExpenseDto();
                        break;
                }
                // Генерация шапки таблицы.
                foreach (var prop in dtObj.GetType().GetProperties())
                {
                    excel.Cells[y, x].Value = prop.Name.Trim();
                    x++;
                }
                // Генерация строк-записей таблицы.
                foreach (var item in grid)
                {
                    y++;
                    // Объект-контейнер для текущего читаемого элемента.
                    Object itemObj = item;
                    x = 1;
                    foreach (var prop in itemObj.GetType().GetProperties())
                    {
                        object t = prop.GetValue(itemObj, null);
                        object val;
                        if (t == null)
                            val = "";
                        else
                        {
                            val = t.ToString();
                            // Если тип сложный, то вытаскиваем нужное поле.
                            if (t is WorkerDto)
                                val = ((WorkerDto)t).Name;
                            if (t is DivisionDto)
                                val = ((DivisionDto)t).Title;
                            if (t is ExpenseDto)
                                val = ((ExpenseDto)t).Description;
                            if (t is TypeExpenseDto)
                                val = ((TypeExpenseDto)t).Title;
                        }
                        excel.Cells[y, x].Value = val;
                        x++;
                    }
                }
                // Устанавливаем размер колонок по ширине содержимого.
                excel.Cells.AutoFitColumns();
                // Сохраняем файл.
                pck.Save();
            }
            else MessageBox.Show("Данные не загружены!");
        }

    }
}
