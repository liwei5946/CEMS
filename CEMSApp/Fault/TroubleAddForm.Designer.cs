namespace CEMSApp.Fault
{
    partial class TroubleAddForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.text_eqname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTime_troubletime = new System.Windows.Forms.DateTimePicker();
            this.text_uploadImg = new System.Windows.Forms.TextBox();
            this.button_uploadImg = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.richText_process = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.richText_lose = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richText_reason = new System.Windows.Forms.RichTextBox();
            this.richText_todo = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.text_eqname, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTime_troubletime, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.text_uploadImg, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_uploadImg, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(630, 52);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(32, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "设备名称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_eqname
            // 
            this.text_eqname.Enabled = false;
            this.text_eqname.Location = new System.Drawing.Point(103, 3);
            this.text_eqname.Name = "text_eqname";
            this.text_eqname.Size = new System.Drawing.Size(199, 21);
            this.text_eqname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(336, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "事故时间：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(32, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "事故照片：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTime_troubletime
            // 
            this.dateTime_troubletime.Location = new System.Drawing.Point(407, 3);
            this.dateTime_troubletime.Name = "dateTime_troubletime";
            this.dateTime_troubletime.Size = new System.Drawing.Size(200, 21);
            this.dateTime_troubletime.TabIndex = 3;
            // 
            // text_uploadImg
            // 
            this.text_uploadImg.BackColor = System.Drawing.Color.White;
            this.text_uploadImg.Location = new System.Drawing.Point(103, 27);
            this.text_uploadImg.Name = "text_uploadImg";
            this.text_uploadImg.ReadOnly = true;
            this.text_uploadImg.Size = new System.Drawing.Size(199, 21);
            this.text_uploadImg.TabIndex = 8;
            // 
            // button_uploadImg
            // 
            this.button_uploadImg.Location = new System.Drawing.Point(308, 27);
            this.button_uploadImg.Name = "button_uploadImg";
            this.button_uploadImg.Size = new System.Drawing.Size(65, 20);
            this.button_uploadImg.TabIndex = 7;
            this.button_uploadImg.Text = "浏览...";
            this.button_uploadImg.UseVisualStyleBackColor = true;
            this.button_uploadImg.Click += new System.EventHandler(this.button_uploadImg_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label19.AutoSize = true;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Location = new System.Drawing.Point(131, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 36);
            this.label19.TabIndex = 0;
            this.label19.Text = "事故经过：";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richText_process
            // 
            this.richText_process.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richText_process.Location = new System.Drawing.Point(17, 39);
            this.richText_process.Name = "richText_process";
            this.richText_process.Size = new System.Drawing.Size(294, 141);
            this.richText_process.TabIndex = 7;
            this.richText_process.Text = "";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.ok, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cancel, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(430, 421);
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableLayoutPanel2.Controls.Add(this.richText_process, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.richText_lose, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label19, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.richText_reason, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.richText_todo, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(630, 363);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // richText_lose
            // 
            this.richText_lose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richText_lose.Location = new System.Drawing.Point(325, 39);
            this.richText_lose.Name = "richText_lose";
            this.richText_lose.Size = new System.Drawing.Size(302, 141);
            this.richText_lose.TabIndex = 7;
            this.richText_lose.Text = "";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label12.AutoSize = true;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(443, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 36);
            this.label12.TabIndex = 0;
            this.label12.Text = "事故损失：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(443, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "对策措施：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // richText_reason
            // 
            this.richText_reason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richText_reason.Location = new System.Drawing.Point(17, 211);
            this.richText_reason.Name = "richText_reason";
            this.richText_reason.Size = new System.Drawing.Size(294, 149);
            this.richText_reason.TabIndex = 7;
            this.richText_reason.Text = "";
            // 
            // richText_todo
            // 
            this.richText_todo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richText_todo.Location = new System.Drawing.Point(325, 211);
            this.richText_todo.Name = "richText_todo";
            this.richText_todo.Size = new System.Drawing.Size(302, 149);
            this.richText_todo.TabIndex = 7;
            this.richText_todo.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(131, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "事故原因：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TroubleAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 448);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TroubleAddForm";
            this.Text = "添加事故记录";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_eqname;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richText_process;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox richText_lose;
        private System.Windows.Forms.RichTextBox richText_reason;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTime_troubletime;
        private System.Windows.Forms.TextBox text_uploadImg;
        private System.Windows.Forms.Button button_uploadImg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richText_todo;
        private System.Windows.Forms.Label label5;
    }
}