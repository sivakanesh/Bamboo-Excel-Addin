namespace BambooExcel
{
    partial class AddInRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AddInRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpFileSystem = this.Factory.CreateRibbonGroup();
            this.grpView = this.Factory.CreateRibbonGroup();
            this.grpSecurity = this.Factory.CreateRibbonGroup();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.editBox1 = this.Factory.CreateRibbonEditBox();
            this.sbtn = this.Factory.CreateRibbonSplitButton();
            this.btnImportFileList = this.Factory.CreateRibbonButton();
            this.btnImportDirList = this.Factory.CreateRibbonButton();
            this.btnReplaceTextInFiles = this.Factory.CreateRibbonButton();
            this.btnDocExplorerPane = this.Factory.CreateRibbonToggleButton();
            this.btnUnprotectWB = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpFileSystem.SuspendLayout();
            this.grpView.SuspendLayout();
            this.grpSecurity.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpFileSystem);
            this.tab1.Groups.Add(this.grpView);
            this.tab1.Groups.Add(this.grpSecurity);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "Bamboo";
            this.tab1.Name = "tab1";
            // 
            // grpFileSystem
            // 
            this.grpFileSystem.Items.Add(this.sbtn);
            this.grpFileSystem.Items.Add(this.btnReplaceTextInFiles);
            this.grpFileSystem.Label = "File System";
            this.grpFileSystem.Name = "grpFileSystem";
            // 
            // grpView
            // 
            this.grpView.Items.Add(this.btnDocExplorerPane);
            this.grpView.Label = "View";
            this.grpView.Name = "grpView";
            // 
            // grpSecurity
            // 
            this.grpSecurity.Items.Add(this.btnUnprotectWB);
            this.grpSecurity.Label = "Security";
            this.grpSecurity.Name = "grpSecurity";
            // 
            // group1
            // 
            this.group1.Items.Add(this.editBox1);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // editBox1
            // 
            this.editBox1.Label = "editBox1";
            this.editBox1.Name = "editBox1";
            this.editBox1.Text = null;
            // 
            // sbtn
            // 
            this.sbtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.sbtn.Items.Add(this.btnImportFileList);
            this.sbtn.Items.Add(this.btnImportDirList);
            this.sbtn.ItemSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.sbtn.Label = "Import";
            this.sbtn.Name = "sbtn";
            this.sbtn.OfficeImageId = "ImportSavedImports";
            // 
            // btnImportFileList
            // 
            this.btnImportFileList.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnImportFileList.Label = "List of Files";
            this.btnImportFileList.Name = "btnImportFileList";
            this.btnImportFileList.OfficeImageId = "ReadingViewShowPrintedPage";
            this.btnImportFileList.ShowImage = true;
            this.btnImportFileList.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnImportFileList_Click);
            // 
            // btnImportDirList
            // 
            this.btnImportDirList.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnImportDirList.Label = "List of Directories";
            this.btnImportDirList.Name = "btnImportDirList";
            this.btnImportDirList.OfficeImageId = "ReadingViewShowPrintedPage";
            this.btnImportDirList.ShowImage = true;
            this.btnImportDirList.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnImportDirList_Click);
            // 
            // btnReplaceTextInFiles
            // 
            this.btnReplaceTextInFiles.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnReplaceTextInFiles.Description = "Replace text in files";
            this.btnReplaceTextInFiles.Label = "Replace text in files";
            this.btnReplaceTextInFiles.Name = "btnReplaceTextInFiles";
            this.btnReplaceTextInFiles.OfficeImageId = "ReplaceDialog";
            this.btnReplaceTextInFiles.ShowImage = true;
            this.btnReplaceTextInFiles.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnReplaceTextInFiles_Click);
            // 
            // btnDocExplorerPane
            // 
            this.btnDocExplorerPane.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDocExplorerPane.Label = "Document Explorer";
            this.btnDocExplorerPane.Name = "btnDocExplorerPane";
            this.btnDocExplorerPane.ShowImage = true;
            this.btnDocExplorerPane.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDocExplorerPane_Click_1);
            // 
            // btnUnprotectWB
            // 
            this.btnUnprotectWB.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnUnprotectWB.Label = "Unprotect Workbook";
            this.btnUnprotectWB.Name = "btnUnprotectWB";
            this.btnUnprotectWB.OfficeImageId = "ReviewProtectWorkbookMenu";
            this.btnUnprotectWB.ShowImage = true;
            this.btnUnprotectWB.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUnprotectWB_Click);
            // 
            // AddInRibbon
            // 
            this.Name = "AddInRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.AddInRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpFileSystem.ResumeLayout(false);
            this.grpFileSystem.PerformLayout();
            this.grpView.ResumeLayout(false);
            this.grpView.PerformLayout();
            this.grpSecurity.ResumeLayout(false);
            this.grpSecurity.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpFileSystem;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton sbtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportFileList;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpView;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton btnDocExplorerPane;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnReplaceTextInFiles;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpSecurity;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUnprotectWB;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportDirList;
    }

    partial class ThisRibbonCollection
    {
        internal AddInRibbon AddInRibbon
        {
            get { return this.GetRibbon<AddInRibbon>(); }
        }
    }
}
