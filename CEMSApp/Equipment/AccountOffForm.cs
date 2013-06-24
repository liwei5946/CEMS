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

namespace CEMSApp.Equipment
{
    public partial class AccountOffForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(AccountOffForm));
        string globleId = "";
        public AccountOffForm(string id, string eq_asset, string eq_name)
        {
            InitializeComponent();
            text_asset.Text = eq_asset;
            text_eqname.Text = eq_name;
            globleId = id;
            DataSet ds_offType = null;
            Account acc = new Account();
            ds_offType = acc.queryOffType();
            InitComboBox(combo_offType, ds_offType, "id", "off_typename");
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
            //AccountAdd aa = new AccountAdd();
            Account acc = new Account();
            float value;
            if (!maskedText_value.Value.ToString().Equals(""))
            {
                value = (float)maskedText_value.Value;
            }
            else
            {
                value = 0.00F;
            }
            flag = acc.writeOffAccount(true, dateTime_offDate.Text, Convert.ToInt32(combo_offType.SelectedValue.ToString()), value, richTextBox_memo.Text, globleId);

            //flag = aa.addAccount(false, text_asset.Text, text_eqname.Text, text_model.Text, text_specification.Text, Convert.ToInt32(combo_depart.SelectedValue.ToString()), text_weight.Text, text_brand.Text, text_manufacturer.Text, text_supplier.Text, dateTime_manu_date.Text, dateTime_produ_date.Text, dateTime_filing_date.Text, float.Parse(maskedText_value.Text), Convert.ToInt32(numeric_count.Value.ToString()), Convert.ToInt32(numeric_electromotor.Value.ToString()), float.Parse(maskedText_power.Text), Convert.ToInt32(combo_status.SelectedValue.ToString()), Convert.ToInt32(combo_eqType.SelectedValue.ToString()), text_address.Text, aa.getFileBytes(fileDialog_img.FileName), aa.getFileBytes(fileDialog_3d.FileName));
            //flag = aa.addAccount(false, text_asset.Text, text_eqname.Text, text_model.Text, text_specification.Text, Convert.ToInt32(combo_depart.SelectedValue.ToString()), text_weight.Text, text_brand.Text, text_manufacturer.Text, text_supplier.Text, dateTime_offDate.Text, dateTime_produ_date.Text, dateTime_filing_date.Text, value, count, electromotor, power, Convert.ToInt32(combo_status.SelectedValue.ToString()), Convert.ToInt32(combo_offType.SelectedValue.ToString()), text_address.Text, img, threeD);
            if (flag)
            {
                MessageBox.Show("销帐成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("销帐失败，请检查网络连接！");
            }
        }

    }
}
