using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Equipment;

namespace CEMSApp.Equipment
{
    public partial class AccountAddForm : ChildForm
    {
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
    }
}
