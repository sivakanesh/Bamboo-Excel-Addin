using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Microsoft.Office.Interop.Excel;
using BambooExcel.Helpers;
using System.Reflection;
using BambooExcel.IO;

namespace BambooExcel.Forms
{
    public partial class frmFileListOptions : Form
    {
        public frmFileListOptions()
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

            IEnumerable<FileSystemInfo> fileEnum = IOUtil.GetFileList(path, "*.*", System.IO.SearchOption.AllDirectories);
            //FileInfo[] files = IOUtil.GetFileList(path, "*.*", System.IO.SearchOption.AllDirectories);

            Microsoft.Office.Interop.Excel.Application excelApp = Globals.ThisAddIn.Application;


            Workbook wb = ExcelHelper.GetActiveWorkbook(true, excelApp);
            Worksheet ws = wb.Worksheets.Add(Type.Missing);
            //TODO:// ws.Name = "List of files";


            IList<FileSystemInfo> fileIList = fileEnum.ToList();


            //int rows = files.Count() + 1;
            int rows = fileIList.Count() + 1;

            Type t = typeof(FileInfo);
            int cols = t.GetProperties(BindingFlags.Public | BindingFlags.Instance).Length;

            string[,] fileArray = new string[rows, cols];
            int i = 0;
            int j = 0;

            //columns
            foreach (var p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                fileArray[0, j] = p.Name;
                j++;
            }


            //rows
            i = 1;
            //foreach (FileInfo f in files)
            foreach (var f in fileIList)
            {
                //Write files only
                if (f.GetType() == typeof(FileInfo))
                {
                    j = 0;
                    foreach (var attr in f.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        fileArray[i, j] = attr.GetValue(f, null).ToString();
                        j++;
                    }
                    i++;
                }
            }


            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        intsArray[i, j] = i;
            //    }
            //}

            Range rng = ws.get_Range("A1", Type.Missing);
            rng = rng.get_Resize(rows, cols);
            rng.Value2 = fileArray;

            this.Close();
        }

        private void frmFileListOptions_Load(object sender, EventArgs e)
        {
            //Globals.ThisAddIn.Application.Interactive = false;
        }

        private void frmFileListOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Globals.ThisAddIn.Application.Interactive = true;
        }
    }
}
