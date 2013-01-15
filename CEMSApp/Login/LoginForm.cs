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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            flag = login.isLogin(textBox1.Text, textBox2.Text);
            if (flag)
            {
                MessageBox.Show("登录成功！");
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }

    }
}
