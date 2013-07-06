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
    public partial class TroubleAddForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(TroubleAddForm));
        string globalEqId="";
        OpenFileDialog fileDialog_img = new OpenFileDialog();
        public TroubleAddForm(string eqId,string eqName)
        {
            InitializeComponent();
            globalEqId = eqId;
            text_eqname.Text = eqName;
            
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
            AccountAdd aa = new AccountAdd();
            //Account acc = new Account();
            //float value,power;
            byte[] img = new byte[] { 0 };
            try
                {
                    if (!fileDialog_img.FileName.Equals(""))
                    {
                        img = aa.getFileBytes(fileDialog_img.FileName);
                    }
                    else
                    {
                        img = aa.getFileBytes("pic\\no_photo.jpg");
                    }
                }
                catch (Exception mye)
                {
                    MessageBox.Show("图像读取失败，请取消文件的只读属性！", "文件读取错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error(mye.Message);
                    return;
                }
            flag = aa.addTrouble(globalEqId, dateTime_troubletime.Text, richText_process.Text, richText_reason.Text, richText_lose.Text, richText_todo.Text, img);
            //flag = aa.addKnowledge(text_eqname.Text, text_partname.Text, combo_level.SelectedValue.ToString(), richText_process.Text, richText_lose.Text, richText_reason.Text);
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

        private void button_uploadImg_Click(object sender, EventArgs e)
        {
            fileDialog_img.InitialDirectory = "d://";       // 默认打开的路径，可更改
            fileDialog_img.Filter = "图像文件 (*.jpg)|*.jpg";
            fileDialog_img.FilterIndex = 1;
            fileDialog_img.RestoreDirectory = true;
            if (fileDialog_img.ShowDialog() == DialogResult.OK)
            {
                text_uploadImg.Text = fileDialog_img.FileName;
            }
            else
            {
                text_uploadImg.Text = "";
            } 
        }

    }
}
