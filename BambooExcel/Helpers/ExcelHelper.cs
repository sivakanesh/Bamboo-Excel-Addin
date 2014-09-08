using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Office.Interop.Excel;

namespace BambooExcel.Helpers
{
    static class ExcelHelper
    {

        public static Workbook GetActiveWorkbook(bool AddNewIfNone, Microsoft.Office.Interop.Excel.Application excelApp)
        {
            Workbook wb;
            int wbCount = excelApp.Workbooks.Count;
            if (wbCount <= 0 && AddNewIfNone)
            {
                wb = excelApp.Workbooks.Add();
            }
            else
            {
                wb = excelApp.ActiveWorkbook;
            }

            return wb;

        }

        /// <summary>
        /// Checks if cell is in edit mode. Will not rebind unlesss changes commited.
        /// </summary>
        /// <returns>true if in edit mode, else false.</returns>
        private static bool IsSheetInEditMode()
        {
            Microsoft.Office.Core.CommandBarControl menu =
                Globals.ThisAddIn.Application.CommandBars["Worksheet Menu Bar"].FindControl(
                1,
                18,
                System.Type.Missing,
                System.Type.Missing,
                true);

            if (menu != null)
            {
                if (!menu.Enabled)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "WorkSheet is in edit mode. Commit your changes by using Enter key using Ribbon controls.");
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
}
