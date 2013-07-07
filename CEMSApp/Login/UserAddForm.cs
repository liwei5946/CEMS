﻿using System;
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
    public partial class UserAddForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(UserAddForm));
        int globleUserRight = 0;

        public UserAddForm()
        {
            InitializeComponent();
            InitCheckBox(globleUserRight);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            bool flag = false, flag_same = false;
            Account acc = new Account();
            if (text_username.Text.Trim() != "")
            {
                flag_same = acc.hasSameUsername(text_username.Text);
                if (!flag_same)
                {
                    flag = acc.addUser(text_username.Text, label_psd.Text, text_realname.Text, globleUserRight);
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
                    MessageBox.Show("已经存在同名用户！", "禁止操作", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    text_username.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("用户名不能为空！", "禁止操作", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                text_username.Focus();
                return;
            }

            

        }

        private void radio_yes_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_yes.Checked)
            {
                radio_no.Checked = false;
                globleUserRight = 1;//管理员
            }
        }

        private void radio_no_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_no.Checked)
            {
                radio_yes.Checked = false;
                globleUserRight = 0;//普通用户
            }
        }
        /// <summary>
        /// 初始化单选框
        /// </summary>
        /// <param name="standard"></param>
        private void InitCheckBox(int standard)
        {
            if (standard==1)
            {
                radio_yes.Checked = true;
                radio_no.Checked = false;
            }
            else
            {
                radio_yes.Checked = false;
                radio_no.Checked = true;
            }
        }

    }
}
