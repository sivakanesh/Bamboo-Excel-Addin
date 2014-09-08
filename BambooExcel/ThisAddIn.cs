using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Tools;

namespace BambooExcel
{
    public partial class ThisAddIn
    {
        private DocumentExplorer de;
        private CustomTaskPane ctp;

        public Microsoft.Office.Tools.CustomTaskPane TaskPane
        {
            get
            {
                return ctp;
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Document Explorer---------------------------------------------------------
            de = new DocumentExplorer();
            ctp = this.CustomTaskPanes.Add(de, "Document Explorer");
            ctp.VisibleChanged += new EventHandler(ctp_VisibleChanged);
            //--------------------------------------------------------------------------
        }

        private void ctp_VisibleChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.AddInRibbon.btnDocExplorerPane.Checked = ctp.Visible;
            //Globals.Ribbons.AddInRibbon.PerformLayout();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }



        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
