namespace BambooExcel
{
    partial class DocumentExplorer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tvDocuments = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvDocuments
            // 
            this.tvDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDocuments.Location = new System.Drawing.Point(3, 20);
            this.tvDocuments.Name = "tvDocuments";
            this.tvDocuments.Size = new System.Drawing.Size(173, 272);
            this.tvDocuments.TabIndex = 0;
            // 
            // DocumentExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvDocuments);
            this.Name = "DocumentExplorer";
            this.Size = new System.Drawing.Size(179, 295);
            this.Load += new System.EventHandler(this.DocumentExplorer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvDocuments;
    }
}
