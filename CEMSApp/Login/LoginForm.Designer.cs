namespace CEMSApp.Login
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.loginbutton = new System.Windows.Forms.Button();
            this.link_set = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uname = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dbpwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dbuser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dbname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ipadd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(132, 95);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(133, 21);
            this.username.TabIndex = 0;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(132, 131);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(133, 21);
            this.password.TabIndex = 1;
            // 
            // loginbutton
            // 
            this.loginbutton.Location = new System.Drawing.Point(157, 179);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(75, 23);
            this.loginbutton.TabIndex = 2;
            this.loginbutton.Text = "登录";
            this.loginbutton.UseVisualStyleBackColor = true;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // link_set
            // 
            this.link_set.AutoSize = true;
            this.link_set.Location = new System.Drawing.Point(12, 184);
            this.link_set.Name = "link_set";
            this.link_set.Size = new System.Drawing.Size(29, 12);
            this.link_set.TabIndex = 3;
            this.link_set.TabStop = true;
            this.link_set.Text = "设置";
            this.link_set.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::CEMSApp.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(354, 218);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // uname
            // 
            this.uname.AutoSize = true;
            this.uname.Location = new System.Drawing.Point(76, 98);
            this.uname.Name = "uname";
            this.uname.Size = new System.Drawing.Size(41, 12);
            this.uname.TabIndex = 6;
            this.uname.Text = "用户名";
            // 
            // pwd
            // 
            this.pwd.AutoSize = true;
            this.pwd.Location = new System.Drawing.Point(76, 134);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(41, 12);
            this.pwd.TabIndex = 7;
            this.pwd.Text = "密  码";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dbpwd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dbuser);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dbname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ipadd);
            this.groupBox1.Location = new System.Drawing.Point(8, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 137);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库服务器设置";
            // 
            // dbpwd
            // 
            this.dbpwd.Location = new System.Drawing.Point(149, 99);
            this.dbpwd.Name = "dbpwd";
            this.dbpwd.PasswordChar = '*';
            this.dbpwd.Size = new System.Drawing.Size(156, 21);
            this.dbpwd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据库登录密码";
            // 
            // dbuser
            // 
            this.dbuser.Location = new System.Drawing.Point(149, 72);
            this.dbuser.Name = "dbuser";
            this.dbuser.Size = new System.Drawing.Size(156, 21);
            this.dbuser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据库登录用户名";
            // 
            // dbname
            // 
            this.dbname.Location = new System.Drawing.Point(149, 45);
            this.dbname.Name = "dbname";
            this.dbname.Size = new System.Drawing.Size(156, 21);
            this.dbname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库库名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库服务器IP地址";
            // 
            // ipadd
            // 
            this.ipadd.Location = new System.Drawing.Point(149, 18);
            this.ipadd.Name = "ipadd";
            this.ipadd.Size = new System.Drawing.Size(156, 21);
            this.ipadd.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 218);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.uname);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.link_set);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "化工企业设备维护维修管理系统";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button loginbutton;
        private System.Windows.Forms.LinkLabel link_set;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label uname;
        private System.Windows.Forms.Label pwd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipadd;
        private System.Windows.Forms.TextBox dbname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dbpwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dbuser;
        private System.Windows.Forms.Label label3;
    }
}