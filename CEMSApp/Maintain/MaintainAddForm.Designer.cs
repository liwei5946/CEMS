namespace CEMSApp.Maintain
{
    partial class MaintainAddForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.text_asset = new System.Windows.Forms.TextBox();
            this.text_eqname = new System.Windows.Forms.TextBox();
            this.richTextBox_memo = new System.Windows.Forms.RichTextBox();
            this.text_planAsset = new System.Windows.Forms.TextBox();
            this.maskedText_value = new System.Windows.Forms.NumericUpDown();
            this.dateTime_planDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maskedText_value)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.text_asset, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.text_eqname, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox_memo, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.text_planAsset, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.maskedText_value, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dateTime_planDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 379);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(32, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "资产编号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(32, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "设备名称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Location = new System.Drawing.Point(56, 243);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "备注：";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label21.Location = new System.Drawing.Point(32, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "计划编号：";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_asset
            // 
            this.text_asset.Enabled = false;
            this.text_asset.Location = new System.Drawing.Point(103, 3);
            this.text_asset.Name = "text_asset";
            this.text_asset.Size = new System.Drawing.Size(200, 21);
            this.text_asset.TabIndex = 1;
            // 
            // text_eqname
            // 
            this.text_eqname.Enabled = false;
            this.text_eqname.Location = new System.Drawing.Point(103, 27);
            this.text_eqname.Name = "text_eqname";
            this.text_eqname.Size = new System.Drawing.Size(200, 21);
            this.text_eqname.TabIndex = 1;
            // 
            // richTextBox_memo
            // 
            this.richTextBox_memo.Location = new System.Drawing.Point(103, 123);
            this.richTextBox_memo.Name = "richTextBox_memo";
            this.richTextBox_memo.Size = new System.Drawing.Size(200, 248);
            this.richTextBox_memo.TabIndex = 11;
            this.richTextBox_memo.Text = "";
            // 
            // text_planAsset
            // 
            this.text_planAsset.Location = new System.Drawing.Point(103, 51);
            this.text_planAsset.Name = "text_planAsset";
            this.text_planAsset.Size = new System.Drawing.Size(200, 21);
            this.text_planAsset.TabIndex = 12;
            // 
            // maskedText_value
            // 
            this.maskedText_value.Location = new System.Drawing.Point(103, 99);
            this.maskedText_value.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.maskedText_value.Name = "maskedText_value";
            this.maskedText_value.Size = new System.Drawing.Size(100, 21);
            this.maskedText_value.TabIndex = 10;
            // 
            // dateTime_planDate
            // 
            this.dateTime_planDate.Location = new System.Drawing.Point(103, 75);
            this.dateTime_planDate.Name = "dateTime_planDate";
            this.dateTime_planDate.Size = new System.Drawing.Size(200, 21);
            this.dateTime_planDate.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(32, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "维护天数：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(32, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "维护日期：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.ok, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cancel, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(130, 379);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 30);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(3, 3);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "保存";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(103, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // MaintainAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 409);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintainAddForm";
            this.Text = "新增维护计划";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maskedText_value)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox text_asset;
        private System.Windows.Forms.TextBox text_eqname;
        private System.Windows.Forms.DateTimePicker dateTime_planDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.NumericUpDown maskedText_value;
        private System.Windows.Forms.RichTextBox richTextBox_memo;
        private System.Windows.Forms.TextBox text_planAsset;
    }
}