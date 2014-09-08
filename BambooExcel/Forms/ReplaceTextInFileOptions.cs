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
using System.Text;
using System.Windows.Forms;

namespace BambooExcel.Forms
{
    public partial class frmReplaceTextInFileOptions : Form
    {
        public frmReplaceTextInFileOptions()
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
            //FileInfo[] files = IOUtil.GetFileList(path, "*.*", System.IO.SearchOption.AllDirectories); 
            IEnumerable<FileSystemInfo> fileEnum = IOUtil.GetFileList(path, "*.*", System.IO.SearchOption.AllDirectories); 
            //TODO: extention option, 
            //TODO: Subfolder option

            Microsoft.Office.Interop.Excel.Application excelApp = Globals.ThisAddIn.Application;

            Workbook wb = ExcelHelper.GetActiveWorkbook(true, excelApp);
            Worksheet ws = wb.Worksheets.Add(Type.Missing);
            //TODO:// ws.Name = "List of files";

            IList<FileSystemInfo> fileIList = fileEnum.ToList();

            int cols = 3;
            int rows = fileIList.Count() + 2;
            string[,] fileArray = new string[rows, cols]; //filename, count, path

            //column headings
            fileArray[0, 0] = string.Format("{0} '{1}' to '{2}'", "Files that were replaced with string from", txtFindString.Text, txtReplacewithString.Text);
            fileArray[0, 1] = "";
            fileArray[0, 2] = "";
            fileArray[1, 0] = "File Name";
            fileArray[1, 1] = "Match Count";
            fileArray[1, 2] = "Path";

            int i = 2;
            foreach (FileInfo f in fileIList)
            {
                int match = IOHelper.ReplaceText(f, txtFindString.Text, txtReplacewithString.Text, cbCaseSensitive.Checked, cbSpoof.Checked);
                if (match > 0)
                {
                    fileArray[i, 0] = f.Name;
                    fileArray[i, 1] = match.ToString();
                    fileArray[i, 2] = f.DirectoryName;
                    i++;
                }
            }

            Range rng = ws.get_Range("A1", Type.Missing);
            rng = rng.get_Resize(rows, cols);
            rng.Value2 = fileArray;

            this.Close();
        }

        private void frmReplaceTextInFileOptions_Load(object sender, EventArgs e)
        {
            //Globals.ThisAddIn.Application.Interactive = false;
        }

        private void frmReplaceTextInFileOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Globals.ThisAddIn.Application.Interactive = true;
        }
    }
}
