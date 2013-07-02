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
    public partial class RepairEditForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(RepairEditForm));
        string globalRepairId="";
        public RepairEditForm(string eqasset, string eqname, string eqdep, string repairId)
        {
            InitializeComponent();
            text_eqasset.Text = eqasset;
            text_eqname.Text = eqname;
            text_dep.Text = eqdep;
            globalRepairId = repairId;
            //
            DataSet ds_department1 = null, ds_department2 = null, ds_level = null, ds = null;
            AccountAdd aa = new AccountAdd();
            Account ads = new Account();
            ds_department1 = aa.CreateDataSet_Department();//部门列表
            ds_department2 = aa.CreateDataSet_Department();//部门列表
            ds_level = aa.CreateDataSet_RepairLevel();//维修级别列表
            ds = ads.queryRepairById(repairId);
            //
            InitComboBox(combo_targetdep, ds_department1, "id", "departname", ds, "target_department");
            InitComboBox(combo_sourcedep, ds_department2, "id", "departname", ds, "source_department");
            InitComboBox(combo_level, ds_level, "id", "level_name", ds, "repair_level");
            //表头塞值
            text_repairasset.DataBindings.Add(new Binding("Text", ds.Tables[0], "repair_asset"));
            dateTime_startdate.DataBindings.Add(new Binding("Value", ds.Tables[0], "start_date"));
            dateTime_enddate.DataBindings.Add(new Binding("Value", ds.Tables[0], "end_date"));
            numeric_stopday.DataBindings.Add(new Binding("Value", ds.Tables[0], "stop_time"));
            text_group.DataBindings.Add(new Binding("Text", ds.Tables[0], "repair_group"));
            text_fuzeren.DataBindings.Add(new Binding("Text", ds.Tables[0], "principal"));
            richText_before.DataBindings.Add(new Binding("Text", ds.Tables[0], "memo_before"));
            richText_record.DataBindings.Add(new Binding("Text", ds.Tables[0], "memo_record"));
            richText_after.DataBindings.Add(new Binding("Text", ds.Tables[0], "memo_after"));
        }
        
        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="ValueMember"></param>
        /// <param name="DisplayMember"></param>
        /// <param name="ds1">所有列表内容</param>
        /// <param name="ds2">默认被选中的行</param>
        private void InitComboBox(ComboBox cb, DataSet ds1, string ValueMember, string DisplayMember, DataSet ds2, string ComboType)
        {
            if (ds1 != null && ds2 != null)
            {
                cb.DataSource = ds1.Tables[0];
                cb.DisplayMember = DisplayMember;
                cb.ValueMember = ValueMember;
                cb.DataBindings.Add(new Binding("SelectedValue", ds2.Tables[0], ComboType));//设置下拉框的默认值
            }
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            bool flag = false;
            Account aa = new Account();
            //float value,power;
            //byte[] img = new byte[] { 0 };
            //byte[] threeD = new byte[] { 0 };
            int stoptime;
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
            

            if (!numeric_stopday.Value.ToString().Equals(""))
            {
                stoptime = Convert.ToInt32(numeric_stopday.Value.ToString());
            }
            else
            {
                stoptime = 0;
            }
            if (dateTime_startdate.Value <= dateTime_enddate.Value)
            {
                flag = aa.updateRepair(globalRepairId, text_repairasset.Text, dateTime_startdate.Text, dateTime_enddate.Text, numeric_stopday.Value.ToString(), combo_targetdep.SelectedValue.ToString(), combo_sourcedep.SelectedValue.ToString(), text_group.Text, text_fuzeren.Text, richText_before.Text, richText_after.Text, richText_record.Text, combo_level.SelectedValue.ToString());
                //flag = aa.addRepair(text_repairasset.Text, globalPlanId, dateTime_startdate.Text, dateTime_enddate.Text, numeric_stopday.Value.ToString(), combo_targetdep.SelectedValue.ToString(), combo_sourcedep.SelectedValue.ToString(), text_group.Text, text_fuzeren.Text, richText_before.Text, richText_after.Text, richText_record.Text,combo_level.SelectedValue.ToString());
                //flag = aa.addRepairPlan(text_repairasset.Text, globalEqId, dateTime_startdate.Text, overtime, stoptime,combo_targetdep.SelectedValue.ToString(),combo_sourcedep.SelectedValue.ToString(), text_fuzeren.Text, richText_before.Text, combo_level.SelectedValue.ToString());
                //flag = aa.addAccount(false, text_asset.Text, text_eqname.Text, text_model.Text, text_specification.Text, Convert.ToInt32(combo_depart.SelectedValue.ToString()), text_weight.Text, text_brand.Text, text_manufacturer.Text, text_supplier.Text, dateTime_manu_date.Text, dateTime_produ_date.Text, dateTime_filing_date.Text, float.Parse(maskedText_value.Text), Convert.ToInt32(numeric_count.Value.ToString()), Convert.ToInt32(numeric_electromotor.Value.ToString()), float.Parse(maskedText_power.Text), Convert.ToInt32(combo_status.SelectedValue.ToString()), Convert.ToInt32(combo_eqType.SelectedValue.ToString()), text_address.Text, aa.getFileBytes(fileDialog_img.FileName), aa.getFileBytes(fileDialog_3d.FileName));
                //flag = aa.addAccount(false, text_eqasset.Text, text_eqname.Text, text_repairasset.Text, text_specification.Text, Convert.ToInt32(combo_sourcedep.SelectedValue.ToString()), text_fuzeren.Text, text_dep.Text, text_manufacturer.Text, text_supplier.Text, dateTime_plandate.Text, dateTime_produ_date.Text, dateTime_filing_date.Text, value, count, electromotor, power, Convert.ToInt32(combo_status.SelectedValue.ToString()), Convert.ToInt32(combo_targetdep.SelectedValue.ToString()), text_address.Text, img, threeD);
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
            else
            {
                MessageBox.Show("起始日期不可大于结束日期！");
            }
        }

    }
}
