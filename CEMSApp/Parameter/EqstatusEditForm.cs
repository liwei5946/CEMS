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

namespace CEMSApp.Parameter
{
    public partial class EqstatusEditForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(EqstatusEditForm));
        string globleId = "";
        public EqstatusEditForm(string id)
        {
            InitializeComponent();
            globleId = id;
        }
 
        private void ok_Click(object sender, EventArgs e)
        {
            bool flag = false;
            Account acc = new Account();

            flag = acc.updateInfomation(globleId, "eq_status", "status_name", text_name.Text);
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

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
