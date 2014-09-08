using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Microsoft.Office.Tools;
using BambooExcel.Forms;



namespace BambooExcel
{
    public partial class AddInRibbon
    {

        //TODO:  Need to unload all COM

        private void AddInRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnImportFileList_Click(object sender, RibbonControlEventArgs e)
        {
            frmFileListOptions frm = new frmFileListOptions();
            frm.Show();
            

        }

        private void btnDocExplorerPane_Click_1(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.TaskPane.Visible = ((RibbonToggleButton)sender).Checked;
        }

        private void btnReplaceTextInFiles_Click(object sender, RibbonControlEventArgs e)
        {
            frmReplaceTextInFileOptions frm = new frmReplaceTextInFileOptions();
            frm.Show();
        }

        private void btnUnprotectWB_Click(object sender, RibbonControlEventArgs e)
        {
            Helpers.SecurityHelper.UnprotectWorkbook();
        }

        private void btnImportDirList_Click(object sender, RibbonControlEventArgs e)
        {
            frmFolderListOptions frm = new frmFolderListOptions();
            frm.Show();
        }


    }
}
