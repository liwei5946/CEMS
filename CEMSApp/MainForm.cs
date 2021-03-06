﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CEMSApp.Equipment;
using CEMSApp.Maintain;
using CEMSApp.Repair;
using CEMSApp.Fault;
using CEMSApp.Parameter;
using CEMSApp.Login;
using System.Threading;
using BusinessLogicLayer;
using Util;

namespace CEMSApp
{
    public partial class MainForm : Form
    {
        private string username;
        private int userRight;

        public int UserRight
        {
            get { return userRight; }
            set { userRight = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //点击窗体关闭按钮，主窗口关闭，程序终止退出
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //点击退出按钮，主窗口关闭，程序终止退出
            Application.Exit();

        }

        /// <summary>
        /// 使打开的子窗体不影响父窗体的菜单栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text.Length == 0)
            {
                e.Item.Visible = false;
            }
        }

        /// <summary>
        /// 打开子窗体，判断是否重复打开
        /// 在使用MDI子窗体时，如果仅仅是使用 from.show() 代码，
        /// 那么我们单击几次菜单，就会打开几个同样的子窗体。
        /// 可以用这段代码防止这种情况。
        /// 首先添加一个函数，这个函数用于检测指定的子窗体是否已经打开，
        /// 如果打开则激活这个子窗体，否则返回false值。
        /// </summary>
        /// <param name="p_ChildrenFormText"></param>
        /// <returns></returns>
        private bool showChildrenForm(string p_ChildrenFormName)
        {
            int i;
            //依次检测当前窗体的子窗体
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                //判断当前子窗体的name属性值是否与传入的字符串值相同
                if (this.MdiChildren[i].Name == p_ChildrenFormName)
                {
                    //如果值相同则表示此子窗体为想要调用的子窗体，激活此子窗体并返回true值
                    this.MdiChildren[i].Activate();
                    return true;
                }
            }
            //如果没有相同的值则表示要调用的子窗体还没有被打开，返回false值
            return false;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //在状态栏中显示当前系统时间
            //systemTime.Text += DateTime.Now.Date.ToShortDateString();
            System.DateTime currentTime = new System.DateTime();
            currentTime=System.DateTime.Now;
            //systemTime.Text += currentTime.Year + "年" + currentTime.Month + "月" + currentTime.Day + "日";
            systemTime.Text += currentTime.ToLongDateString();
            usernameLabel.Text += username;
            if (userRight == 0)
            {
                //普通用户，不显示“系统设置”菜单
                //MainMenu.Items[6].Visible = false;
                canshushezhi.Visible = false;//参数设置菜单不可见
                yonghuguanli.Visible = false;//用户管理菜单不可见
                shujukushezhi.Visible = false;//数据库设置菜单不可见
                
                userrightLabel.Text += "普通用户";
            }
            else
            {
                userrightLabel.Text += "管理员";
                shujukuhuifu.Visible = false;//暂不提供数据库恢复功能
            }
            
        }
        /// <summary>
        /// 设备台帐管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eqAccountMenuItem_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("AccountForm"))
            {
                AccountForm eq_account = new AccountForm();
                eq_account.MdiParent = this;
                eq_account.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("AccountForm"))
            {
                AccountForm eq_account = new AccountForm();
                eq_account.MdiParent = this;
                eq_account.Show();
            }
        }

        private void OffAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("OffForm"))
            {
                OffForm eq_offaccount = new OffForm();
                eq_offaccount.MdiParent = this;
                eq_offaccount.Show();
            }
        }

        private void weihujihua_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("MaintainPlanForm"))
            {
                MaintainPlanForm eq_MaintainPlan = new MaintainPlanForm();
                eq_MaintainPlan.MdiParent = this;
                eq_MaintainPlan.Show();
            }
        }

        private void toolStripButton_maintainplan_Click(object sender, EventArgs e)
        {
            /*
            if (!showChildrenForm("MaintainPlanForm"))
            {
                MaintainPlanForm eq_MaintainPlan = new MaintainPlanForm();
                eq_MaintainPlan.MdiParent = this;
                eq_MaintainPlan.Show();
            }
             */
            if (!showChildrenForm("MaintainForm"))
            {
                MaintainForm eq_Maintain = new MaintainForm();
                eq_Maintain.MdiParent = this;
                eq_Maintain.Show();
            }
        }

        private void weihujilu_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("MaintainForm"))
            {
                MaintainForm eq_Maintain = new MaintainForm();
                eq_Maintain.MdiParent = this;
                eq_Maintain.Show();
            }
        }

        private void weixiujihua_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("RepairPlanForm"))
            {
                RepairPlanForm eq_RepairPlanForm = new RepairPlanForm();
                eq_RepairPlanForm.MdiParent = this;
                eq_RepairPlanForm.Show();
            }
        }

        private void weixiujilu_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("RepairForm"))
            {
                RepairForm eq_RepairForm = new RepairForm();
                eq_RepairForm.MdiParent = this;
                eq_RepairForm.Show();
            }
        }

        private void toolStrip_repair_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("RepairForm"))
            {
                RepairForm eq_RepairForm = new RepairForm();
                eq_RepairForm.MdiParent = this;
                eq_RepairForm.Show();
            }
        }
        //配件管理
        private void toolStripButton_peijianguanli_Click(object sender, EventArgs e)
        {

            if (!showChildrenForm("PartForm"))
            {
                PartForm eq_PartForm = new PartForm();
                eq_PartForm.MdiParent = this;
                eq_PartForm.Show();
            }
        }

        private void peijianguanli_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("PartForm"))
            {
                PartForm eq_PartForm = new PartForm();
                eq_PartForm.MdiParent = this;
                eq_PartForm.Show();
            }
        }
        /// <summary>
        /// 故障管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_fault_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("FaultForm"))
            {
                FaultForm eq_FaultForm = new FaultForm();
                eq_FaultForm.MdiParent = this;
                eq_FaultForm.Show();
            }
        }

        private void ToolStripMenuItem_fault_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("FaultForm"))
            {
                FaultForm eq_FaultForm = new FaultForm();
                eq_FaultForm.MdiParent = this;
                eq_FaultForm.Show();
            }
        }

        private void guzhangzhishiku_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("KnowledgeForm"))
            {
                KnowledgeForm eq_KnowledgeForm = new KnowledgeForm();
                eq_KnowledgeForm.MdiParent = this;
                eq_KnowledgeForm.Show();
            }
        }

        private void toolStripButton_trouble_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("TroubleForm"))
            {
                TroubleForm eq_TroubleForm = new TroubleForm();
                eq_TroubleForm.MdiParent = this;
                eq_TroubleForm.Show();
            }
        }

        private void shiguguanli_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("TroubleForm"))
            {
                TroubleForm eq_TroubleForm = new TroubleForm();
                eq_TroubleForm.MdiParent = this;
                eq_TroubleForm.Show();
            }
        }

        private void bumenguanli_Click(object sender, EventArgs e)
        {
            
            
        }

        private void shebeizhuangtai_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("EqstatusForm"))
            {
                EqstatusForm eq_form = new EqstatusForm();
                eq_form.MdiParent = this;
                eq_form.Show();
            }
            
        }

        private void shebeileixing_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("EqtypeForm"))
            {
                EqtypeForm eq_form = new EqtypeForm();
                eq_form.MdiParent = this;
                eq_form.Show();
            }
            
        }

        private void guzhangmoshi_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("FaultLevelForm"))
            {
                FaultLevelForm eq_form = new FaultLevelForm();
                eq_form.MdiParent = this;
                eq_form.Show();
            }
            
        }

        private void weixiudengji_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("RepairLevelForm"))
            {
                RepairLevelForm eq_form = new RepairLevelForm();
                eq_form.MdiParent = this;
                eq_form.Show();
            }
            
        }

        private void xiugaimima_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("ChangePasswordForm"))
            {
                ChangePasswordForm cpf = new ChangePasswordForm(username);
                cpf.MdiParent = this;
                cpf.Show();
            }
        }

        private void yonghuguanli_Click(object sender, EventArgs e)
        {
            if (!showChildrenForm("UserForm"))
            {
                UserForm cpf = new UserForm();
                cpf.MdiParent = this;
                cpf.Show();
            }
        }
        /// <summary>
        /// 数据库备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shujukubeifen_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.Login.Login login = new BusinessLogicLayer.Login.Login();
            //login.BackupDataBase();
            //"d:\\cemsdb\\cems.mdf"
            string path = "", filename = "";
            DialogResult dr;
            Boolean flag = false;
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "请选择备份文件存放路径";
            string date = DateTime.Now.ToString("yyyyMMdd");
            dr = MessageBox.Show("您确认备份数据库吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    Cursor cr = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;//将光标置为等待状态

                    path = fb.SelectedPath;
                    filename = "\\cems-" + date+"-" + Util.Tools.Number(6)+".mdf";
                    flag = login.BackupDataBase(path, filename);

                    Cursor.Current = cr;//将光标置回原来状态 

                    if (flag)
                    {
                        MessageBox.Show("数据库已成功备份至" + path + filename, "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("数据库备份失败！", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void shujukuhuifu_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.Login.Login login = new BusinessLogicLayer.Login.Login();
            DialogResult dr;
            Boolean flag = false;
            string filename = "";
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择数据库备份文件";
            open.InitialDirectory = "d://";       // 默认打开的路径，可更改
            open.Filter = "MDF数据库文件 (*.mdf)|*.mdf";
            open.FilterIndex = 1;
            open.RestoreDirectory = true;
            open.Multiselect = false;

            dr = MessageBox.Show("您确认恢复数据库吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    filename = open.FileName;
                    Cursor cr = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;//将光标置为等待状态
                    flag = login.ReplaceDataBase(filename);
                    Cursor.Current = cr;//将光标置回原来状态 

                    if (flag)
                    {
                        MessageBox.Show("数据库已成功还原", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("数据库还原失败！", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



    }
}
