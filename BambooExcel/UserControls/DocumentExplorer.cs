using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BambooExcel
{
    public partial class DocumentExplorer : UserControl
    {
        public DocumentExplorer()
        {
            InitializeComponent();
        }

        private void DocumentExplorer_Load(object sender, EventArgs e)
        {
            RefreshDocumentTree();
        }

        private void RefreshDocumentTree()
        {
            Microsoft.Office.Interop.Excel.Application excelApp = Globals.ThisAddIn.Application;
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.ActiveWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet ws;

            TreeNode[] nodeArray = new TreeNode[wb.Worksheets.Count];

            for (int i = 0; i < wb.Worksheets.Count; i++)
            {
                ws = wb.Worksheets[i+1];
                nodeArray[i] = new TreeNode(ws.Name);
                nodeArray[i].Text = ws.Name;
                nodeArray[i].Tag = "Child";
            }

            TreeNode treeNode = new TreeNode(wb.Name, nodeArray);
            tvDocuments.Nodes.Add(treeNode);
        }

    }
}
