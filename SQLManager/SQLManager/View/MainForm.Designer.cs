namespace SQLManager.View
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            tsbSelect = new ToolStripButton();
            tsbSave = new ToolStripButton();
            tvServer = new TreeView();
            tbContent = new TextBox();
            btnExecute = new Button();
            tbSuccess = new TextBox();
            tbFailure = new TextBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbSelect, tsbSave });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbSelect
            // 
            tsbSelect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSelect.Image = (Image)resources.GetObject("tsbSelect.Image");
            tsbSelect.ImageTransparentColor = Color.Magenta;
            tsbSelect.Name = "tsbSelect";
            tsbSelect.Size = new Size(23, 22);
            tsbSelect.Text = "Select";
            tsbSelect.Click += TsbSelect_Click;
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSave.Image = (Image)resources.GetObject("tsbSave.Image");
            tsbSave.ImageTransparentColor = Color.Magenta;
            tsbSave.Name = "tsbSave";
            tsbSave.Size = new Size(23, 22);
            tsbSave.Text = "Save";
            tsbSave.Click += TsbSave_Click;
            // 
            // tvServer
            // 
            tvServer.Location = new Point(12, 41);
            tvServer.Name = "tvServer";
            tvServer.Size = new Size(248, 397);
            tvServer.TabIndex = 1;
            tvServer.AfterCollapse += TvServer_AfterCollapse;
            tvServer.BeforeExpand += TvServer_BeforeExpand;
            // 
            // tbContent
            // 
            tbContent.Location = new Point(266, 41);
            tbContent.Multiline = true;
            tbContent.Name = "tbContent";
            tbContent.ScrollBars = ScrollBars.Vertical;
            tbContent.Size = new Size(441, 236);
            tbContent.TabIndex = 2;
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(713, 137);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(75, 52);
            btnExecute.TabIndex = 3;
            btnExecute.Text = "Execute";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += BtnExecute_Click;
            // 
            // tbSuccess
            // 
            tbSuccess.Location = new Point(266, 293);
            tbSuccess.Multiline = true;
            tbSuccess.Name = "tbSuccess";
            tbSuccess.ScrollBars = ScrollBars.Vertical;
            tbSuccess.Size = new Size(212, 145);
            tbSuccess.TabIndex = 4;
            // 
            // tbFailure
            // 
            tbFailure.Location = new Point(500, 293);
            tbFailure.Multiline = true;
            tbFailure.Name = "tbFailure";
            tbFailure.ScrollBars = ScrollBars.Vertical;
            tbFailure.Size = new Size(207, 145);
            tbFailure.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbFailure);
            Controls.Add(tbSuccess);
            Controls.Add(btnExecute);
            Controls.Add(tbContent);
            Controls.Add(tvServer);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SSMS";
            FormClosed += MainForm_FormClosed;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbSelect;
        private ToolStripButton tsbSave;
        private TreeView tvServer;
        private TextBox tbContent;
        private Button btnExecute;
        private TextBox tbSuccess;
        private TextBox tbFailure;
    }
}