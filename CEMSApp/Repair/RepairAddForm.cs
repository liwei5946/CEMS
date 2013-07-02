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

namespace CEMSApp.Repair
{
    public partial class RepairAddForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(RepairAddForm));
        string globalEqId="";
        public RepairAddForm(string eqasset, string eqname, string eqdep, string eqId)
        {
            InitializeComponent();
            text_eqasset.Text = eqasset;
            text_eqname.Text = eqname;
            text_dep.Text = eqdep;
            globalEqId = eqId;
            //
            DataSet ds_department1 = null, ds_department2 = null, ds_level = null;
            AccountAdd aa = new AccountAdd();
            ds_department1 = aa.CreateDataSet_Department();//部门列表
            ds_department2 = aa.CreateDataSet_Department();//部门列表
            ds_level = aa.CreateDataSet_RepairLevel();//维修级别列表
            InitComboBox(combo_targetdep, ds_department1, "id", "departname");
            InitComboBox(combo_sourcedep, ds_department2, "id", "departname");
            InitComboBox(combo_level, ds_level, "id", "level_name");
            
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepairPlanAddForm_Load(object sender, EventArgs e)
        {
            /*
            DataSet ds_department = null, ds_level=null ;
            AccountAdd aa = new AccountAdd();
            ds_department = aa.CreateDataSet_Department();//部门列表
            ds_level = aa.CreateDataSet_RepairLevel();//维修级别列表
            InitComboBox(combo_targetdep, ds_department, "id", "departname");
            InitComboBox(combo_sourcedep, ds_department, "id", "departname");
            InitComboBox(combo_level, ds_level, "id", "level_name");
            */
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
        /// <param name="ValueMember">数据ID</param>
        /// <param name="DisplayMember">数据显示项的列名</param>
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
            Account aa = new Account();
            //float value,power;
            //byte[] img = new byte[] { 0 };
            //byte[] threeD = new byte[] { 0 };
            int overtime,stoptime;
            /*
            if (Util.Tools.IsFloat(maskedText_value.Text))
            {
                log.Debug(maskedText_value.Text);
                value = float.Parse(maskedText_value.Text);
            }
            else
            {
                MessageBox.Show("“设备单价”格式错误！");
                maskedText_value.Focus();
                maskedText_value.Text = "0.00";
                return ;
            }
            if (Util.Tools.IsFloat(maskedText_power.Text))
            {
               power= float.Parse(maskedText_power.Text);
            }
            else
            {
                MessageBox.Show("“总功率”格式错误！");
                maskedText_power.Focus();
                maskedText_power.Text = "0.00";
                return;
            }
             * */


            if (!numeric_repairday.Value.ToString().Equals(""))
            {
                overtime = Convert.ToInt32(numeric_repairday.Value.ToString());
            }
            else
            {
                overtime = 0;
            }
            if (!numeric_stopday.Value.ToString().Equals(""))
            {
                stoptime = Convert.ToInt32(numeric_stopday.Value.ToString());
            }
            else
            {
                stoptime = 0;
            }

            flag = aa.addRepairPlan(text_repairasset.Text, globalEqId, dateTime_plandate.Text, overtime, stoptime,combo_targetdep.SelectedValue.ToString(),combo_sourcedep.SelectedValue.ToString(), text_fuzeren.Text, richText_memo.Text, combo_level.SelectedValue.ToString());
            //flag = aa.addAccount(false, text_asset.Text, text_eqname.Text, text_model.Text, text_specification.Text, Convert.ToInt32(combo_depart.SelectedValue.ToString()), text_weight.Text, text_brand.Text, text_manufacturer.Text, text_supplier.Text, dateTime_manu_date.Text, dateTime_produ_date.Text, dateTime_filing_date.Text, float.Parse(maskedText_value.Text), Convert.ToInt32(numeric_count.Value.ToString()), Convert.ToInt32(numeric_electromotor.Value.ToString()), float.Parse(maskedText_power.Text), Convert.ToInt32(combo_status.SelectedValue.ToString()), Convert.ToInt32(combo_eqType.SelectedValue.ToString()), text_address.Text, aa.getFileBytes(fileDialog_img.FileName), aa.getFileBytes(fileDialog_3d.FileName));
            //flag = aa.addAccount(false, text_eqasset.Text, text_eqname.Text, text_repairasset.Text, text_specification.Text, Convert.ToInt32(combo_sourcedep.SelectedValue.ToString()), text_fuzeren.Text, text_dep.Text, text_manufacturer.Text, text_supplier.Text, dateTime_plandate.Text, dateTime_produ_date.Text, dateTime_filing_date.Text, value, count, electromotor, power, Convert.ToInt32(combo_status.SelectedValue.ToString()), Convert.ToInt32(combo_targetdep.SelectedValue.ToString()), text_address.Text, img, threeD);
            if (flag)
            {
                MessageBox.Show("数据添加成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("数据添加失败，请检查网络连接！");
            }
        }

    }
}
