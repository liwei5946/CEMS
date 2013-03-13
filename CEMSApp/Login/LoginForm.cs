using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using BusinessLogicLayer.Login;
using Util;

//注意下面的语句一定要加上，指定log4net使用.config文件来读取配置信息  
//如果是WinForm（假定程序为MyDemo.exe，则需要一个MyDemo.exe.config文件）  
//如果是WebForm，则从web.config中读取相关信息  
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace CEMSApp.Login
{
    public partial class LoginForm : Form
    {
        BusinessLogicLayer.Login.Login login = new BusinessLogicLayer.Login.Login();
        ILog log = log4net.LogManager.GetLogger(typeof(Program));
        private string baseip = ConfigAppSettings.GetValue("ipaddress");
        private string basename = ConfigAppSettings.GetValue("basename");
        private string baseuser = ConfigAppSettings.GetValue("user");
        private string basepwd = ConfigAppSettings.GetValue("password");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            bool flag = false;
            //如果判断数据库接口信息有更改，则将新信息写入配置文件
            if(!(ipadd.Text == baseip && dbname.Text == basename && dbuser.Text == baseuser && dbpwd.Text == basepwd)){
                ConfigAppSettings.SetValue("ipaddress", ipadd.Text);
                ConfigAppSettings.SetValue("basename", dbname.Text);
                ConfigAppSettings.SetValue("user", dbuser.Text);
                ConfigAppSettings.SetValue("password", dbpwd.Text);
                MessageBox.Show("您修改了数据库服务器连接参数，请重新启动程序！");
                Application.Exit();
            }
            flag = login.isLogin(username.Text, password.Text);
            if (flag)
            {
                int userRight = 0;
                userRight = login.getUserRight(username.Text);
                MainForm mainForm = new MainForm();
                mainForm.Username = username.Text;
                mainForm.UserRight = userRight;
                mainForm.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int height = this.Height;
            //int width = this.Width;
            if (height == 250)
            {
                this.Height = 400;
            }
            else if (height == 400)
            {
                this.Height = 250;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //以下代码设置登录页面标签背景透明
            pictureBox1.SendToBack();//pictureBox1是背景图片控件
            uname.BackColor = Color.Transparent;
            uname.Parent = pictureBox1;
            uname.BringToFront();
            pwd.BackColor = Color.Transparent;
            pwd.Parent = pictureBox1;
            pwd.BringToFront();
            link_set.BackColor = Color.Transparent;
            link_set.Parent = pictureBox1;
            link_set.BringToFront();
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Parent = pictureBox1;
            groupBox1.BringToFront();
            loginbutton.BackColor = Color.Transparent;
            loginbutton.Parent = pictureBox1;
            loginbutton.BringToFront();
            button2.BackColor = Color.Transparent;
            button2.Parent = pictureBox1;
            button2.BringToFront();
            
            //以下 在登录页面打开时，加载数据库信息
            ipadd.Text = baseip;
            dbname.Text = basename;
            dbuser.Text = baseuser;
            dbpwd.Text = basepwd;

        }


    }
}
