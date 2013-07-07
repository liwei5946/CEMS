using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BusinessLogicLayer.Equipment;
using log4net;

namespace CEMSApp.Login
{
    public partial class ChangePasswordForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(ChangePasswordForm));
        //string globalEqId="";
        OpenFileDialog fileDialog_img = new OpenFileDialog();
        public ChangePasswordForm(string username)
        {
            InitializeComponent();
            text_name.Text = username;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            bool flag = false, flag_login = false;
            //AccountAdd aa = new AccountAdd();
            BusinessLogicLayer.Login.Login login = new BusinessLogicLayer.Login.Login();
            flag_login = login.isLogin(text_name.Text, text_oldpsd.Text);//判断旧密码是否正确
            if (flag_login)
            {
                if (text_newpsd1.Text == text_newpsd2.Text)
                {
                    flag = login.updatePasswordByUsername(text_name.Text, text_newpsd1.Text);
                    if (flag)
                    {
                        MessageBox.Show("数据保存成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("数据保存失败，请检查网络连接！");
                    } 
                }
                else
                {
                    MessageBox.Show("新密码两次输入不一致！", "禁止操作", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    text_newpsd1.SelectAll();
                    return;
                }
            }
            else
            {
                MessageBox.Show("原密码不正确！", "禁止操作", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                text_oldpsd.SelectAll();
                return;
            }
            

        }

    }
}
