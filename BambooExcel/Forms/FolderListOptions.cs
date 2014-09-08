using BambooExcel.Helpers;
using BambooExcel.IO;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BambooExcel.Forms
{
    public partial class frmFolderListOptions : Form
    {
        public frmFolderListOptions()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult dr = folderDlg.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string path = folderDlg.SelectedPath;
                txtFolder.Text = path;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string path = txtFolder.Text; //TODO: check path

            //////////////////////////////////
            //ToDO make this so that the list of these propteries are from the UI

            //List of file based dates from UI
            int FileCount = 1;
            int ReportLatestFileAccessDateWithinFolder = 0;

            if  (cbReportLastAccessDate.Checked){
                ReportLatestFileAccessDateWithinFolder = 1; 
            }

            int totalAdditionalColumns = ReportLatestFileAccessDateWithinFolder + FileCount;

            //////////////////////////////////


            IEnumerable<DirectoryInfo> dirEnum = IOUtil.GetDirList(path, "*.*", System.IO.SearchOption.AllDirectories);

            Microsoft.Office.Interop.Excel.Application excelApp = Globals.ThisAddIn.Application;
            Workbook wb = ExcelHelper.GetActiveWorkbook(true, excelApp);
            Worksheet ws = wb.Worksheets.Add(Type.Missing);

            IList<DirectoryInfo> dirIList = dirEnum.ToList();


            //int rows = files.Count() + 1;
            int rows = dirIList.Count() + 1;

            Type t = typeof(DirectoryInfo);
            int cols = t.GetProperties(BindingFlags.Public | BindingFlags.Instance).Length + totalAdditionalColumns;

            string[,] fileArray = new string[rows, cols];
            int i = 0;
            int j = 0;
            string[] errors = new string[rows];

            //columns
            foreach (var p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                fileArray[0, j] = p.Name;
                j++;
            }

            //Add additional column titles
            //Always shpw file count
            //-----------------------------------------------------------------------
            fileArray[0, j] = "File count";
            j++;

            if (cbReportLastAccessDate.Checked)
            {
                fileArray[0, j] = "Latest file access date within folder";
                j++;
            }

            errors[0] = "Error Message";
            //-----------------------------------------------------------------------

            //rows
            i = 1;
            foreach (var d in dirIList)
            {
                    j = 0;
                    foreach (var attr in d.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        fileArray[i, j] = attr.GetValue(d, null).ToString();
                        j++;
                    }
                
                    //TODO: Use BambooDirectoryInfo
                    //get dates from files and assign to Dir
                    //var directory = new DirectoryInfo(this.DirectoryInfo.Name);

                    try
                    {

                        //File count
                        fileArray[i, j] = d.GetFiles().Length.ToString();
                        j++;

                        //LastAccessTime---------------------------------
                        FileInfo fl = d.GetFiles().OrderByDescending(f => f.LastAccessTime).FirstOrDefault();
                        if (fl != null)
                        {
                            fileArray[i, j] = fl.LastAccessTime.ToString("dd/MM/yyyy HH:mm:ss");
                            j++;
                        }
                    }
                    catch (UnauthorizedAccessException uauthe)
                    {
                        errors[i] = uauthe.Message;
                        //PathException.Add(string.Format("{0} - {1}", "Unauthorised Access", uauthe.Message));
                        //todo yield break;
                    }
                    catch (PathTooLongException ptle)
                    {
                        errors[i] = ptle.Message;
                        //PathException.Add(string.Format("{0} - {1}", "Path too long", ptle.Message));
                        //todo  yield break;
                    }
                    //------------------------------------------------
                    
                    i++;
            }


            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        intsArray[i, j] = i;
            //    }
            //}

            //merge error messag column to the fileArray
            IOHelper.Append1DArrayToMultiDArray(ref fileArray, errors);

            Range rng = ws.get_Range("A1", Type.Missing);
            rng = rng.get_Resize(rows, fileArray.GetLength(1));
            rng.Value2 = fileArray;

            this.Close();
        }
    }
}
