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

namespace CEMSApp.Maintain
{
    public partial class MaintainAddForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MaintainAddForm));
        string globleplanId = "";
        public MaintainAddForm(string planId, string plan_asset, string eq_name,string eq_asset)
        {
            InitializeComponent();
            text_planAsset.Text = plan_asset;
            text_eqname.Text = eq_name;
            text_eqAsset.Text = eq_asset;
            globleplanId = planId;
            //DataSet ds_offType = null;
            //Account acc = new Account();
            //ds_offType = acc.queryOffType();
            //InitComboBox(combo_offType, ds_offType, "id", "off_typename");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="ds"></param>
        /// <param name="ValueMember">数据主键的字段名</param>
        /// <param name="DisplayMember">数据显示项的字段名</param>
        private void InitComboBox(ComboBox cb, DataSet ds, string ValueMember, string DisplayMember)
        {
            if (ds != null)
            {
                cb.DataSource = ds.Tables[0];
                cb.DisplayMember = DisplayMember;
                cb.ValueMember = ValueMember;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (dateTime_startDate.Value <= dateTime_endDate.Value)
            {
                Account acc = new Account();
                flag = acc.addMaintain(globleplanId, text_status.Text, dateTime_startDate.Text, dateTime_endDate.Text, richTextBox_memo.Text, text_principal.Text);
                if (flag)
                {
                    MessageBox.Show("新增维护记录成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("新增维护记录失败，请检查网络连接！");
                }
            }
            else
            {
                MessageBox.Show("起始日期不可大于结束日期！");
            }
        }

    }
}
