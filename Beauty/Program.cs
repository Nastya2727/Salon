using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beauty
{
    public class Assist
    {
        
        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
        
        public void WriteExcel(DataGridView dataGrid)
        {
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            
            for (int j = 0; j < dataGrid.ColumnCount; j++)
                ExcelApp.Cells[1, j + 1] = dataGrid.Columns[j].HeaderText;

            for (int i = 1; i <= dataGrid.Rows.Count; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGrid.Rows[i-1].Cells[j].Value;
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }



    public static class Data
    {
        public static int Logged = 0;
        public static string ConnectionString = @"data source=LAPTOP-5B5LI774\SQLEXPRESS;initial catalog=Beauty;Integrated Security =true";
        static public string ComputeHash(string input,HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch
            {

            }
        }
    }
}
