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

namespace CEMSApp.Fault
{
    public partial class KnowledgeEditForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(KnowledgeEditForm));
        string globalId="";
        OpenFileDialog fileDialog_img = new OpenFileDialog();
        public KnowledgeEditForm(string id)
        {
            InitializeComponent();
            globalId = id;
            DataSet ds_level = null, ds = null;
            AccountAdd aa = new AccountAdd();
            Account acc = new Account();
            ds_level = aa.CreateDataSet_FaultLevel();//故障模式列表
            ds = acc.queryKnowledgeByIdForEdit(id);
            //InitComboBox(combo_level, ds_level, "id", "level_name");
            text_eqname.DataBindings.Add(new Binding("Text", ds.Tables[0], "eq_name"));
            text_partname.DataBindings.Add(new Binding("Text", ds.Tables[0], "part_name"));
            richText_fault_process.DataBindings.Add(new Binding("Text", ds.Tables[0], "fault_process"));
            richText_fault_reason.DataBindings.Add(new Binding("Text", ds.Tables[0], "fault_reason"));
            richText_countermeasure.DataBindings.Add(new Binding("Text", ds.Tables[0], "countermeasure"));
            InitComboBox(combo_level, ds_level, "id", "level_name", ds, "fault_level");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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





        private void ok_Click(object sender, EventArgs e)
        {
            bool flag = false;
            AccountAdd aa = new AccountAdd();
            //Account acc = new Account();
            //float value,power;
            //byte[] threeD = new byte[] { 0 };
            flag = aa.updateKnowledge(text_eqname.Text, text_partname.Text, combo_level.SelectedValue.ToString(), richText_fault_process.Text, richText_fault_reason.Text, richText_countermeasure.Text, globalId);
            //flag = aa.addKnowledge(text_eqname.Text, text_partname.Text, combo_level.SelectedValue.ToString(), richText_fault_process.Text, richText_fault_reason.Text, richText_countermeasure.Text);
                //flag = aa.addFault(globalEqId, text_partname.Text, combo_level.SelectedValue.ToString(), dateTime_fault.Text, dateTime_begin.Text, dateTime_end.Text, richText_fault_process.Text, richText_fault_reason.Text, richText_countermeasure.Text, img);
                //flag = aa.addRepair(text_partname.Text, globalPlanId, dateTime_fault.Text, dateTime_begin.Text, numeric_stopday.Value.ToString(), combo_targetdep.SelectedValue.ToString(), combo_sourcedep.SelectedValue.ToString(), text_group.Text, text_fuzeren.Text, richText_.Text, richText_after.Text, richText_record.Text,combo_level.SelectedValue.ToString());
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

    }
}
