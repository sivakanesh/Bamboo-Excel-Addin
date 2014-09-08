using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;


namespace BambooExcel.Helpers
{
    static class SecurityHelper
    {


        //Breaks worksheet and workbook structure passwords.
        //Reveals hashed passwords NOT original passwords
        //http://www.mcgimpsey.com/excel/removepwords.html
        public static void UnprotectWorkbook(){

            string DBLSPACE = Environment.NewLine + Environment.NewLine;
            string HEADER = "AllInternalPasswords User Message";
            string ALLCLEAR = DBLSPACE + "The workbook should now be free of all password protection.";
            string MSGNOPWORDS1 = "There were no passwords on sheets, or workbook structure or windows.";
            string MSGNOPWORDS2 = "There was no protection to workbook structure or windows. Proceeding to unprotect sheets.";
            string MSGTAKETIME = "Ready to proceed.  This may take some time.  Press OK when ready.";
            string MSGPWORDFOUND1 = "There was a Worksheet Structure or Windows Password set." + DBLSPACE + "The password found was: " + "$$";
            string MSGPWORDFOUND2 = "There was a Worksheet password set." + DBLSPACE + "The password found was: " + "$$";
            string MSGONLYONE = "Only structure / windows was protected." + ALLCLEAR;

            //Worksheet w1;
            //Worksheet w2;
            //int i, j, k, l, m, n, i1, i2, i3, i4, i5, i6;
            string PWord1 = "";
            string pass = string.Empty;
            bool ShTag, WinTag;

            Microsoft.Office.Interop.Excel.Application excelApp = Globals.ThisAddIn.Application;

            //Application.ScreenUpdating = False
            Workbook wb = BambooExcel.Helpers.ExcelHelper.GetActiveWorkbook(true, excelApp);
            WinTag = wb.ProtectStructure || wb.ProtectWindows;
           
            ShTag = false;
            foreach (Worksheet w1 in wb.Worksheets){
                ShTag = ShTag || w1.ProtectContents;
            }

            if (!ShTag && !WinTag){
                System.Windows.Forms.MessageBox.Show(MSGNOPWORDS1, HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            System.Windows.Forms.MessageBox.Show(MSGTAKETIME, HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            if (!WinTag)
            {
                System.Windows.Forms.MessageBox.Show(MSGNOPWORDS2, HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                do
                {
                    for (int i = 65; i <= 66; i++)
                    {
                        for (int j = 65; j <= 66; j++)
                        {
                            for (int k = 65; k <= 66; k++)
                            {
                                for (int l = 65; l <= 66; l++)
                                {
                                    for (int m = 65; m <= 66; m++)
                                    {
                                        for (int i1 = 65; i1 <= 66; i1++)
                                        {
                                            for (int i2 = 65; i2 <= 66; i2++)
                                            {
                                                for (int i3 = 65; i3 <= 66; i3++)
                                                {
                                                    for (int i4 = 65; i4 <= 66; i4++)
                                                    {
                                                        for (int i5 = 65; i5 <= 66; i5++)
                                                        {
                                                            for (int i6 = 65; i6 <= 66; i6++)
                                                            {
                                                                for (int n = 32; n <= 126; n++)
                                                                {
                                                                    try
                                                                    {
                                                                        PWord1 = IOHelper.i2s(i) + IOHelper.i2s(j) + IOHelper.i2s(k) + IOHelper.i2s(l) + IOHelper.i2s(m) + IOHelper.i2s(i1) + IOHelper.i2s(i2) + IOHelper.i2s(i3) + IOHelper.i2s(i4) + IOHelper.i2s(i5) + IOHelper.i2s(i6) + IOHelper.i2s(n);
                                                                        wb.Unprotect(PWord1);
                                                                        if (!wb.ProtectStructure && !wb.ProtectWindows)
                                                                        {
                                                                            System.Windows.Forms.MessageBox.Show(MSGPWORDFOUND1.Replace("$$", PWord1), HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                                                                            return;
                                                                        }
                                                                        else
                                                                        {
                                                                            PWord1 = "";
                                                                        }
                                                                    }
                                                                    catch (Exception ex) { }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                } while (!WinTag && !ShTag);
            }

            if (WinTag && !ShTag){
                System.Windows.Forms.MessageBox.Show(MSGONLYONE, HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            foreach (Worksheet w1 in wb.Worksheets){
                try
                {
                    w1.Unprotect(PWord1);
                }
                catch (Exception ex) { }
            }
            
            ShTag = false;
            foreach (Worksheet w1 in wb.Worksheets){
                try{
                w1.Unprotect(PWord1);
                }
                catch (Exception ex) { }
                ShTag = ShTag || w1.ProtectContents;
            }
            
            if (ShTag){
                foreach (Worksheet w1 in wb.Worksheets){
                    if (w1.ProtectContents){
                        do
                {
                    for (int i = 65; i <= 66; i++)
                    {
                        for (int j = 65; j <= 66; j++)
                        {
                            for (int k = 65; k <= 66; k++)
                            {
                                for (int l = 65; l <= 66; l++)
                                {
                                    for (int m = 65; m <= 66; m++)
                                    {
                                        for (int i1 = 65; i1 <= 66; i1++)
                                        {
                                            for (int i2 = 65; i2 <= 66; i2++)
                                            {
                                                for (int i3 = 65; i3 <= 66; i3++)
                                                {
                                                    for (int i4 = 65; i4 <= 66; i4++)
                                                    {
                                                        for (int i5 = 65; i5 <= 66; i5++)
                                                        {
                                                            for (int i6 = 65; i6 <= 66; i6++)
                                                            {
                                                                for (int n = 32; n <= 126; n++)
                                                                {
                                                                    try{
                                                                        PWord1 = IOHelper.i2s(i) + IOHelper.i2s(j) + IOHelper.i2s(k) + IOHelper.i2s(l) + IOHelper.i2s(m) + IOHelper.i2s(i1) + IOHelper.i2s(i2) + IOHelper.i2s(i3) + IOHelper.i2s(i4) + IOHelper.i2s(i5) + IOHelper.i2s(i6) + IOHelper.i2s(n);
                                                                        w1.Unprotect(PWord1);
                                                                        if (!w1.ProtectContents)
                                                                        {
                                                                            foreach (Worksheet w2 in wb.Worksheets)
                                                                            {
                                                                                w2.Unprotect(PWord1);
                                                                            }
                                                                            System.Windows.Forms.MessageBox.Show(MSGPWORDFOUND2.Replace("$$", PWord1), HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                                                                            return;
                                                                        }
                                                                        else
                                                                        {
                                                                            PWord1 = "";
                                                                        }
                                                                    }
                                                                    catch (Exception ex) { }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                } while (!ShTag);
                    }
                }
            }

            System.Windows.Forms.MessageBox.Show(ALLCLEAR, HEADER, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
    }
}
