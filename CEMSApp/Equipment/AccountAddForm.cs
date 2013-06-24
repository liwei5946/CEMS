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
    public partial class AccountAddForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(AccountOffForm));
        OpenFileDialog fileDialog_img = new OpenFileDialog();
        OpenFileDialog fileDialog_3d = new OpenFileDialog();
        public AccountAddForm()
        {
            InitializeComponent();
        }

        private void AccountAddForm_Load(object sender, EventArgs e)
        {
            DataSet ds_eqType = null, ds_department = null, ds_Status=null ;
            AccountAdd aa = new AccountAdd();
            ds_eqType = aa.CreateDataSet_EquipmentType();
            ds_department = aa.CreateDataSet_Department();
            ds_Status = aa.CreateDataSet_Status();
            InitComboBox(combo_eqType, ds_eqType, "id", "type_name");
            InitComboBox(combo_depart, ds_department, "id", "departname");
            InitComboBox(combo_status, ds_Status, "id", "status_name");

        }

        private void AccountAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {

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

        private void button_upload3D_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog_3d.InitialDirectory = "d://";       // 默认打开的路径，可更改
            fileDialog_3d.Filter = "三维模型文件 (*.obj)|*.obj";
            fileDialog_3d.FilterIndex = 1;
            fileDialog_3d.RestoreDirectory = true;
            if (fileDialog_3d.ShowDialog() == DialogResult.OK)
            {
                text_upload3D.Text = fileDialog_3d.FileName;
            }
            else
            {
                text_upload3D.Text = "";
            } 

        }

        private void ok_Click(object sender, EventArgs e)
        {
            bool flag = false;
            AccountAdd aa = new AccountAdd();
            float value,power;
            byte[] img = new byte[] { 0 };
            byte[] threeD = new byte[] { 0 };
            int count,electromotor;
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
            if (!maskedText_value.Value.ToString().Equals(""))
            {
                value = (float)maskedText_value.Value;
            }
            else
            {
                value = 0.00F;
            }
            if (!maskedText_power.Value.ToString().Equals(""))
            {
                power = (float)maskedText_power.Value;
            }
            else
            {
                power = 0.00F;
            }

            if (!numeric_count.Value.ToString().Equals(""))
            {
                count = Convert.ToInt32(numeric_count.Value.ToString());
            }
            else
            {
                count = 1;
            }
            if (!numeric_electromotor.Value.ToString().Equals(""))
            {
                electromotor = Convert.ToInt32(numeric_electromotor.Value.ToString());
            }
            else
            {
                electromotor = 0;
            }
            if (!fileDialog_img.FileName.Equals(""))
            {
                img = aa.getFileBytes(fileDialog_img.FileName);
            }
            else
            {
                img = aa.getFileBytes("pic\\no_photo.gif");
            }
            if (!fileDialog_3d.FileName.Equals(""))
            {
                threeD = aa.getFileBytes(fileDialog_3d.FileName);
            }
            //flag = aa.addAccount(false, text_asset.Text, text_eqname.Text, text_model.Text, text_specification.Text, Convert.ToInt32(combo_depart.SelectedValue.ToString()), text_weight.Text, text_brand.Text, text_manufacturer.Text, text_supplier.Text, dateTime_manu_date.Text, dateTime_produ_date.Text, dateTime_filing_date.Text, float.Parse(maskedText_value.Text), Convert.ToInt32(numeric_count.Value.ToString()), Convert.ToInt32(numeric_electromotor.Value.ToString()), float.Parse(maskedText_power.Text), Convert.ToInt32(combo_status.SelectedValue.ToString()), Convert.ToInt32(combo_eqType.SelectedValue.ToString()), text_address.Text, aa.getFileBytes(fileDialog_img.FileName), aa.getFileBytes(fileDialog_3d.FileName));
            flag = aa.addAccount(false, text_asset.Text, text_eqname.Text, text_model.Text, text_specification.Text, Convert.ToInt32(combo_depart.SelectedValue.ToString()), text_weight.Text, text_brand.Text, text_manufacturer.Text, text_supplier.Text, dateTime_manu_date.Text, dateTime_produ_date.Text, dateTime_filing_date.Text, value, count, electromotor, power, Convert.ToInt32(combo_status.SelectedValue.ToString()), Convert.ToInt32(combo_eqType.SelectedValue.ToString()), text_address.Text, img, threeD);
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
