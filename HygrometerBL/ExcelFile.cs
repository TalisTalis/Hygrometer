using Excel;
using System.Runtime.InteropServices;

namespace HygrometerBL;

public class ExcelFile
{
    public bool Test(double dryThermometer, double f)
    {
        //string fileName = @"C:\Users\tsariginsv\source\repos\Hygrometer\HygrometerBL\bin\Debug\net6.0\Журнал_регистрации_температуры_и_влажности1.xls";
        string fileName = @"G:\sources\repos\Hygrometer\HygrometerBL\bin\Debug\net6.0\Журнал_регистрации_температуры_и_влажности.xls";
        if (!File.Exists(fileName))
        {
            return false;
        }

        Application excel = new Application();
        try
        {
            using (var fs = File.Open(fileName, FileMode.Open))
            {
                fs.Close();
                int offset = 4;
                string monthString = DateTime.Now.ToString("MMMM");
                int day = DateTime.Now.Day;
                string yearString = DateTime.Now.Year.ToString();
                Workbooks wb = excel.Workbooks;
    
                wb.Open(fileName);
                // Количество листов в книге
                var numberSheets = excel.Sheets.Count;
                // Сохранение изменений документа без уведомления
                excel.DisplayAlerts = false;

                // Активный лист
                Worksheet sheet = excel.Sheets[numberSheets];
                // Последний лист в книге
                Worksheet newSheet = excel.Sheets[numberSheets];
                var nameSheet = sheet.Name;

                if (nameSheet == (monthString + yearString))
                {
                    int col = 3;

                    if (DateTime.Now.Hour > 12)
                    {
                        col = 4;
                    }

                    sheet.Cells[day + offset, col] = dryThermometer;
                    sheet.Cells[day + offset, col + 2] = f;
                }
                else
                {
                    // Копирование последнего листа
                    sheet.Copy(Type.Missing, sheet);
                    // Задание имени скопированому листу
                    newSheet = excel.Sheets[numberSheets + 1];

                    // При проверке названия текущего листа и необходимости добавления нового указывается имя текущего месяца и года
                    newSheet.Name = monthString + yearString;
                    // В ячейку "Месяц" указывается текущий месяц и текущий год
                    newSheet.Cells[1, 9] = monthString + " " + yearString + "г.";

                    ClearNewExcelSheet(newSheet);

                    int col = 3;

                    if (DateTime.Now.Hour > 12)
                    {
                        col = 4;
                    }

                    newSheet.Cells[day + offset, col] = dryThermometer;
                    newSheet.Cells[day + offset, col + 2] = f;
                }                

                SaveExcelFile(excel);
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            CloseExcelFile(excel);
        }

    }
        
    /// <summary>
    /// Очистить новый лист от старых данных.
    /// </summary>
    /// <param name="newSheet">Новый скопированный лист.</param>
    private static void ClearNewExcelSheet(Worksheet newSheet)
    {
        // Очищение скопированного листа от старых данных
        newSheet.Cells.Range["C5", "I37"].ClearContents();
    }
    /// <summary>
    /// Сохранение рабочего пространства Excel-файла.
    /// </summary>
    /// <param name="excel">Экземпляр программы Excel.</param>
    private static void SaveExcelFile(Application excel)
    {
        excel.SaveWorkspace();
    }
    /// <summary>
    /// Сохранить изменения и закрыть программу и процесс
    /// </summary>
    /// <param name="excel">Запущенный экземпляр программы Excel</param>
    private static void CloseExcelFile(Application excel)
    {
        KillExcel(excel);
    }

    /// <summary>
    /// Магия по убийству Excel-процесса
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="ProcessId"></param>
    /// <returns></returns>
    [DllImport("User32.dll")]
    static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);
    static void KillExcel(Application theApp)
    {
        int id = 0;
        IntPtr intptr = new IntPtr(theApp.Hwnd);
        System.Diagnostics.Process p = null;
        try
        {
            GetWindowThreadProcessId(intptr, out id);
            p = System.Diagnostics.Process.GetProcessById(id);
            if (p != null)
            {
                p.Kill();
                p.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
