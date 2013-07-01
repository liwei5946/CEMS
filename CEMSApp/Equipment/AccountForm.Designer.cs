﻿namespace CEMSApp.Equipment
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
            this.delButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MaintainPlanButton = new System.Windows.Forms.ToolStripButton();
            this.MaintainButton = new System.Windows.Forms.ToolStripButton();
            this.report_Button = new System.Windows.Forms.ToolStripButton();
            this.writeoffButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.depart_ComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.equ_ComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grid1 = new SourceGrid.Grid();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.editButton,
            this.delButton,
            this.toolStripSeparator1,
            this.MaintainPlanButton,
            this.MaintainButton,
            this.report_Button,
            this.writeoffButton,
            this.toolStripSeparator3,
            this.closeButton,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.toolStripLabel1,
            this.depart_ComboBox,
            this.toolStripLabel2,
            this.equ_ComboBox,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(975, 40);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // MaintainPlanButton
            // 
            this.MaintainPlanButton.Image = global::CEMSApp.Properties.Resources.cog_edit;
            this.MaintainPlanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MaintainPlanButton.Name = "MaintainPlanButton";
            this.MaintainPlanButton.Size = new System.Drawing.Size(60, 37);
            this.MaintainPlanButton.Text = "维护计划";
            this.MaintainPlanButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MaintainPlanButton.Click += new System.EventHandler(this.MaintainPlanButton_Click);
            // 
            // MaintainButton
            // 
            this.MaintainButton.Image = global::CEMSApp.Properties.Resources.settings;
            this.MaintainButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MaintainButton.Name = "MaintainButton";
            this.MaintainButton.Size = new System.Drawing.Size(60, 37);
            this.MaintainButton.Text = "维修计划";
            this.MaintainButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MaintainButton.Click += new System.EventHandler(this.MaintainButton_Click);
            // 
            // report_Button
            // 
            this.report_Button.Image = global::CEMSApp.Properties.Resources.chart_line;
            this.report_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.report_Button.Name = "report_Button";
            this.report_Button.Size = new System.Drawing.Size(60, 37);
            this.report_Button.Text = "台帐报表";
            this.report_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.report_Button.Click += new System.EventHandler(this.report_Button_Click);
            // 
            // writeoffButton
            // 
            this.writeoffButton.Image = global::CEMSApp.Properties.Resources.book_delete;
            this.writeoffButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.writeoffButton.Name = "writeoffButton";
            this.writeoffButton.Size = new System.Drawing.Size(36, 37);
            this.writeoffButton.Text = "销帐";
            this.writeoffButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.writeoffButton.Click += new System.EventHandler(this.writeoffButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // closeButton
            // 
            this.closeButton.Image = global::CEMSApp.Properties.Resources.door_in;
            this.closeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(36, 37);
            this.closeButton.Text = "关闭";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(48, 37);
            this.toolStripLabel3.Text = "          ";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 37);
            this.toolStripLabel1.Text = "部门：";
            // 
            // depart_ComboBox
            // 
            this.depart_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depart_ComboBox.Items.AddRange(new object[] {
            "所有"});
            this.depart_ComboBox.Name = "depart_ComboBox";
            this.depart_ComboBox.Size = new System.Drawing.Size(121, 40);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(68, 37);
            this.toolStripLabel2.Text = "设备类型：";
            // 
            // equ_ComboBox
            // 
            this.equ_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equ_ComboBox.Items.AddRange(new object[] {
            "所有"});
            this.equ_ComboBox.Name = "equ_ComboBox";
            this.equ_ComboBox.Size = new System.Drawing.Size(121, 40);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::CEMSApp.Properties.Resources.magnifier;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 37);
            this.toolStripButton1.Text = "查询";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel1.Size = new System.Drawing.Size(975, 404);
            this.panel1.TabIndex = 1;
            // 
            // grid1
            // 
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(10, 0);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(955, 404);
            this.grid1.TabIndex = 2;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(863, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "所有设备";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 444);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AccountForm";
            this.Text = "设备台帐管理";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripButton delButton;
        private System.Windows.Forms.ToolStripButton editButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton closeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox depart_ComboBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox equ_ComboBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.Panel panel1;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripButton report_Button;
        private System.Windows.Forms.ToolStripButton writeoffButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton MaintainPlanButton;
        private System.Windows.Forms.ToolStripButton MaintainButton;
    }
}