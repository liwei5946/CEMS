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
    public partial class MaintainEditForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MaintainEditForm));
        string globleMaintainId = "";
        public MaintainEditForm(string maintainId, string plan_asset, string eq_name, string eq_asset, string startDate, string endDate, string principal,string status,string memo)
        {
            InitializeComponent();
            text_planAsset.Text = plan_asset;
            text_eqname.Text = eq_name;
            text_eqAsset.Text = eq_asset;
            globleMaintainId = maintainId;
            dateTime_startDate.Text = startDate;
            dateTime_endDate.Text = endDate;
            text_principal.Text = principal;
            text_status.Text = status;
            richTextBox_memo.Text = memo;
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
                /*
                 text_planAsset.Text = plan_asset;
            text_eqname.Text = eq_name;
            text_eqAsset.Text = eq_asset;
            globleMaintainId = maintainId;
            dateTime_startDate.Text = startDate;
            dateTime_endDate.Text = endDate;
            text_principal.Text = principal;
            text_status.Text = status;
            richTextBox_memo.Text = memo;
                 */
                Account acc = new Account();
                flag = acc.updateMaintainById(dateTime_startDate.Text, dateTime_endDate.Text, text_principal.Text, text_status.Text, richTextBox_memo.Text, globleMaintainId);
                //flag = acc.addMaintain(globleplanId, text_status.Text, dateTime_startDate.Text, dateTime_endDate.Text, richTextBox_memo.Text, text_principal.Text);
                if (flag)
                {
                    MessageBox.Show("修改维护记录成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改维护记录失败，请检查网络连接！");
                }
            }
            else
            {
                MessageBox.Show("起始日期不可大于结束日期！");
            }
        }

    }
}
