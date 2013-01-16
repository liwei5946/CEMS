using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                menuStrip1.Items[6].Visible = false;
                userrightLabel.Text += "普通用户";
            }
            else
            {
                userrightLabel.Text += "管理员";
            }
            
        }

    }
}
