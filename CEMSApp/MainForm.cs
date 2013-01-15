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
            //主窗口关闭，程序终止退出
            Application.Exit();
        }

        private void 查询报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
