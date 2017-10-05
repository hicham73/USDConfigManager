namespace USDManager
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relationshipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvConnections = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDiffRecords = new System.Windows.Forms.TabPage();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusFirstConn = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSecondConn = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressbarDi = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDiffRecords = new System.Windows.Forms.TreeView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnViewRecords = new System.Windows.Forms.ToolStripButton();
            this.tabLeftRecord = new System.Windows.Forms.TabPage();
            this.wbLeftRecord = new System.Windows.Forms.WebBrowser();
            this.tabRightRecord = new System.Windows.Forms.TabPage();
            this.wbRightRecord = new System.Windows.Forms.WebBrowser();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.progressbarMain = new System.Windows.Forms.ToolStripProgressBar();
            this.tabDiffAssociations = new System.Windows.Forms.TabPage();
            this.tvDiffAssociations = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDiffRecords.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabLeftRecord.SuspendLayout();
            this.tabRightRecord.SuspendLayout();
            this.toolStripContainer2.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.tabDiffAssociations.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connexionToolStripMenuItem,
            this.diffToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1297, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connexionToolStripMenuItem
            // 
            this.connexionToolStripMenuItem.Name = "connexionToolStripMenuItem";
            this.connexionToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.connexionToolStripMenuItem.Text = "Connexion";
            // 
            // diffToolStripMenuItem
            // 
            this.diffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem,
            this.relationshipsToolStripMenuItem});
            this.diffToolStripMenuItem.Name = "diffToolStripMenuItem";
            this.diffToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.diffToolStripMenuItem.Text = "Diff";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // relationshipsToolStripMenuItem
            // 
            this.relationshipsToolStripMenuItem.Name = "relationshipsToolStripMenuItem";
            this.relationshipsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.relationshipsToolStripMenuItem.Text = "Relationships";
            this.relationshipsToolStripMenuItem.Click += new System.EventHandler(this.relationshipsToolStripMenuItem_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tabControl2);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.tabControl1);
            this.scMain.Size = new System.Drawing.Size(1297, 677);
            this.scMain.SplitterDistance = 228;
            this.scMain.TabIndex = 1;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(228, 677);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvConnections);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(220, 651);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Connection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvConnections
            // 
            this.tvConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvConnections.Location = new System.Drawing.Point(3, 3);
            this.tvConnections.Name = "tvConnections";
            this.tvConnections.Size = new System.Drawing.Size(214, 645);
            this.tvConnections.TabIndex = 0;
            this.tvConnections.DoubleClick += new System.EventHandler(this.tvConnections_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDiffRecords);
            this.tabControl1.Controls.Add(this.tabDiffAssociations);
            this.tabControl1.Controls.Add(this.tabLeftRecord);
            this.tabControl1.Controls.Add(this.tabRightRecord);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1065, 677);
            this.tabControl1.TabIndex = 1;
            // 
            // tabDiffRecords
            // 
            this.tabDiffRecords.Controls.Add(this.toolStripContainer1);
            this.tabDiffRecords.Location = new System.Drawing.Point(4, 22);
            this.tabDiffRecords.Name = "tabDiffRecords";
            this.tabDiffRecords.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabDiffRecords.Size = new System.Drawing.Size(1057, 651);
            this.tabDiffRecords.TabIndex = 0;
            this.tabDiffRecords.Text = "Diff. Records";
            this.tabDiffRecords.UseVisualStyleBackColor = true;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1051, 598);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 3);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1051, 645);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusFirstConn,
            this.statusSecondConn,
            this.progressbarDi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1051, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // statusFirstConn
            // 
            this.statusFirstConn.Name = "statusFirstConn";
            this.statusFirstConn.Size = new System.Drawing.Size(158, 17);
            this.statusFirstConn.Text = "Main Connect - Hicham Dev";
            // 
            // statusSecondConn
            // 
            this.statusSecondConn.Name = "statusSecondConn";
            this.statusSecondConn.Size = new System.Drawing.Size(118, 17);
            this.statusSecondConn.Text = "toolStripStatusLabel2";
            // 
            // progressbarDi
            // 
            this.progressbarDi.Name = "progressbarDi";
            this.progressbarDi.Size = new System.Drawing.Size(100, 16);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDiffRecords);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(1051, 598);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvDiffRecords
            // 
            this.tvDiffRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDiffRecords.Location = new System.Drawing.Point(0, 0);
            this.tvDiffRecords.Name = "tvDiffRecords";
            this.tvDiffRecords.Size = new System.Drawing.Size(226, 598);
            this.tvDiffRecords.TabIndex = 0;
            this.tvDiffRecords.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.tvDiffRecords.DoubleClick += new System.EventHandler(this.DiffTreeNodeDoubleClickHandler);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(821, 598);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Atrribute";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Left Value";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Right Value";
            this.columnHeader3.Width = 200;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewRecords});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(48, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // btnViewRecords
            // 
            this.btnViewRecords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewRecords.Image = ((System.Drawing.Image)(resources.GetObject("btnViewRecords.Image")));
            this.btnViewRecords.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewRecords.Name = "btnViewRecords";
            this.btnViewRecords.Size = new System.Drawing.Size(36, 22);
            this.btnViewRecords.Text = "View";
            this.btnViewRecords.Click += new System.EventHandler(this.btnViewRecords_Click);
            // 
            // tabLeftRecord
            // 
            this.tabLeftRecord.Controls.Add(this.wbLeftRecord);
            this.tabLeftRecord.Location = new System.Drawing.Point(4, 22);
            this.tabLeftRecord.Name = "tabLeftRecord";
            this.tabLeftRecord.Size = new System.Drawing.Size(1057, 651);
            this.tabLeftRecord.TabIndex = 1;
            this.tabLeftRecord.Text = "Left Record";
            this.tabLeftRecord.UseVisualStyleBackColor = true;
            // 
            // wbLeftRecord
            // 
            this.wbLeftRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbLeftRecord.Location = new System.Drawing.Point(0, 0);
            this.wbLeftRecord.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbLeftRecord.Name = "wbLeftRecord";
            this.wbLeftRecord.Size = new System.Drawing.Size(1057, 651);
            this.wbLeftRecord.TabIndex = 0;
            // 
            // tabRightRecord
            // 
            this.tabRightRecord.Controls.Add(this.wbRightRecord);
            this.tabRightRecord.Location = new System.Drawing.Point(4, 22);
            this.tabRightRecord.Name = "tabRightRecord";
            this.tabRightRecord.Size = new System.Drawing.Size(1057, 651);
            this.tabRightRecord.TabIndex = 2;
            this.tabRightRecord.Text = "Right Record";
            this.tabRightRecord.UseVisualStyleBackColor = true;
            // 
            // wbRightRecord
            // 
            this.wbRightRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbRightRecord.Location = new System.Drawing.Point(0, 0);
            this.wbRightRecord.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbRightRecord.Name = "wbRightRecord";
            this.wbRightRecord.Size = new System.Drawing.Size(1057, 651);
            this.wbRightRecord.TabIndex = 0;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.BottomToolStripPanel
            // 
            this.toolStripContainer2.BottomToolStripPanel.Controls.Add(this.statusStrip2);
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.scMain);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(1297, 677);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(1297, 723);
            this.toolStripContainer2.TabIndex = 2;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressbarMain});
            this.statusStrip2.Location = new System.Drawing.Point(0, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1297, 22);
            this.statusStrip2.TabIndex = 0;
            // 
            // progressbarMain
            // 
            this.progressbarMain.Name = "progressbarMain";
            this.progressbarMain.Size = new System.Drawing.Size(200, 16);
            // 
            // tabDiffAssociations
            // 
            this.tabDiffAssociations.Controls.Add(this.tvDiffAssociations);
            this.tabDiffAssociations.Location = new System.Drawing.Point(4, 22);
            this.tabDiffAssociations.Name = "tabDiffAssociations";
            this.tabDiffAssociations.Size = new System.Drawing.Size(1057, 651);
            this.tabDiffAssociations.TabIndex = 3;
            this.tabDiffAssociations.Text = "Diff. Associations";
            this.tabDiffAssociations.UseVisualStyleBackColor = true;
            // 
            // tvDiffAssociations
            // 
            this.tvDiffAssociations.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvDiffAssociations.Location = new System.Drawing.Point(0, 0);
            this.tvDiffAssociations.Name = "tvDiffAssociations";
            this.tvDiffAssociations.Size = new System.Drawing.Size(264, 651);
            this.tvDiffAssociations.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 723);
            this.Controls.Add(this.toolStripContainer2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDiffRecords.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabLeftRecord.ResumeLayout(false);
            this.tabRightRecord.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tabDiffAssociations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connexionToolStripMenuItem;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TreeView tvDiffRecords;
        private System.Windows.Forms.ToolStripMenuItem diffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDiffRecords;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView tvConnections;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusFirstConn;
        private System.Windows.Forms.ToolStripStatusLabel statusSecondConn;
        private System.Windows.Forms.ToolStripProgressBar progressbarDi;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripProgressBar progressbarMain;
        private System.Windows.Forms.TabPage tabLeftRecord;
        private System.Windows.Forms.TabPage tabRightRecord;
        private System.Windows.Forms.ToolStripButton btnViewRecords;
        private System.Windows.Forms.WebBrowser wbLeftRecord;
        private System.Windows.Forms.WebBrowser wbRightRecord;
        private System.Windows.Forms.ToolStripMenuItem relationshipsToolStripMenuItem;
        private System.Windows.Forms.TabPage tabDiffAssociations;
        private System.Windows.Forms.TreeView tvDiffAssociations;
    }
}