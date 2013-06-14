namespace CEMSApp.Equipment
{
    partial class AccountForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.delButton = new System.Windows.Forms.ToolStripButton();
            this.closeButton = new System.Windows.Forms.ToolStripButton();
            this.bigContainer = new System.Windows.Forms.SplitContainer();
            this.leftContainer = new System.Windows.Forms.SplitContainer();
            this.tree_department = new System.Windows.Forms.TreeView();
            this.tree_eqType = new System.Windows.Forms.TreeView();
            this.grid1 = new SourceGrid.Grid();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bigContainer)).BeginInit();
            this.bigContainer.Panel1.SuspendLayout();
            this.bigContainer.Panel2.SuspendLayout();
            this.bigContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftContainer)).BeginInit();
            this.leftContainer.Panel1.SuspendLayout();
            this.leftContainer.Panel2.SuspendLayout();
            this.leftContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.editButton,
            this.toolStripSeparator1,
            this.delButton,
            this.closeButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(630, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addButton
            // 
            this.addButton.Image = global::CEMSApp.Properties.Resources.add;
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(36, 37);
            this.addButton.Text = "增加";
            this.addButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Image = global::CEMSApp.Properties.Resources.pencil;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(36, 37);
            this.editButton.Text = "修改";
            this.editButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // delButton
            // 
            this.delButton.Image = global::CEMSApp.Properties.Resources.delete1;
            this.delButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(36, 37);
            this.delButton.Text = "删除";
            this.delButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Image = global::CEMSApp.Properties.Resources.door_in;
            this.closeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(36, 37);
            this.closeButton.Text = "关闭";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bigContainer
            // 
            this.bigContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.bigContainer.Location = new System.Drawing.Point(0, 40);
            this.bigContainer.Name = "bigContainer";
            // 
            // bigContainer.Panel1
            // 
            this.bigContainer.Panel1.Controls.Add(this.leftContainer);
            // 
            // bigContainer.Panel2
            // 
            this.bigContainer.Panel2.Controls.Add(this.grid1);
            this.bigContainer.Size = new System.Drawing.Size(630, 404);
            this.bigContainer.SplitterDistance = 150;
            this.bigContainer.TabIndex = 1;
            // 
            // leftContainer
            // 
            this.leftContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftContainer.Location = new System.Drawing.Point(0, 0);
            this.leftContainer.Name = "leftContainer";
            this.leftContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // leftContainer.Panel1
            // 
            this.leftContainer.Panel1.Controls.Add(this.tree_department);
            // 
            // leftContainer.Panel2
            // 
            this.leftContainer.Panel2.Controls.Add(this.tree_eqType);
            this.leftContainer.Size = new System.Drawing.Size(150, 404);
            this.leftContainer.SplitterDistance = 203;
            this.leftContainer.TabIndex = 0;
            // 
            // tree_department
            // 
            this.tree_department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_department.Location = new System.Drawing.Point(0, 0);
            this.tree_department.Name = "tree_department";
            this.tree_department.Size = new System.Drawing.Size(150, 203);
            this.tree_department.TabIndex = 0;
            // 
            // tree_eqType
            // 
            this.tree_eqType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_eqType.Location = new System.Drawing.Point(0, 0);
            this.tree_eqType.Name = "tree_eqType";
            this.tree_eqType.Size = new System.Drawing.Size(150, 197);
            this.tree_eqType.TabIndex = 0;
            // 
            // grid1
            // 
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(0, 0);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(476, 404);
            this.grid1.TabIndex = 0;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 444);
            this.Controls.Add(this.bigContainer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AccountForm";
            this.Text = "设备台帐管理";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.bigContainer.Panel1.ResumeLayout(false);
            this.bigContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bigContainer)).EndInit();
            this.bigContainer.ResumeLayout(false);
            this.leftContainer.Panel1.ResumeLayout(false);
            this.leftContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftContainer)).EndInit();
            this.leftContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripButton delButton;
        private System.Windows.Forms.ToolStripButton editButton;
        private System.Windows.Forms.SplitContainer bigContainer;
        private System.Windows.Forms.SplitContainer leftContainer;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton closeButton;
        private System.Windows.Forms.TreeView tree_department;
        private System.Windows.Forms.TreeView tree_eqType;
    }
}