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
using System.IO;
using log4net;

namespace CEMSApp.Fault
{
    public partial class FaultViewForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(FaultViewForm));
        //string globalEqId="";
        OpenFileDialog fileDialog_img = new OpenFileDialog();
        public FaultViewForm(string faultId)
        {
            InitializeComponent();
            //
            DataSet ds = null;
            Account aa = new Account();
            ds = aa.queryFaultByIdIncludeImage(faultId);
            //InitComboBox(combo_level, ds_level, "id", "level_name");
            sbbh.DataBindings.Add(new Binding("Text", ds.Tables[0], "asset"));
            sbmc.DataBindings.Add(new Binding("Text", ds.Tables[0], "eqname"));
            szbm.DataBindings.Add(new Binding("Text", ds.Tables[0], "departname"));
            lbjmc.DataBindings.Add(new Binding("Text", ds.Tables[0], "part_name"));
            gzms.DataBindings.Add(new Binding("Text", ds.Tables[0], "level_name"));
            dateTimePicker1.DataBindings.Add(new Binding("Value", ds.Tables[0], "fault_date"));
            dateTimePicker2.DataBindings.Add(new Binding("Value", ds.Tables[0], "repair_date"));
            dateTimePicker3.DataBindings.Add(new Binding("Value", ds.Tables[0], "repairover_date"));
            gzxx.DataBindings.Add(new Binding("Text", ds.Tables[0], "fault_process"));
            gzyy.DataBindings.Add(new Binding("Text", ds.Tables[0], "fault_reason"));
            jjff.DataBindings.Add(new Binding("Text", ds.Tables[0], "countermeasure"));
            //加载图片
            MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0][12]);
            Image img = Image.FromStream(ms);
            pictureBox1.Image = img;
            ms.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
