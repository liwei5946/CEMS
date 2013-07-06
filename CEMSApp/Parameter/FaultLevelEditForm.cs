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
    public partial class FaultLevelEditForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(FaultLevelEditForm));
        string globleId = "";
        public FaultLevelEditForm(string id)
        {
            InitializeComponent();
            globleId = id;
        }
 
        private void ok_Click(object sender, EventArgs e)
        {
            bool flag = false;
            Account acc = new Account();

            flag = acc.updateInfomation(globleId, "fault_level", "level_name", text_name.Text);
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
