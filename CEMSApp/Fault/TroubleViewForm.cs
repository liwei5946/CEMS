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
    public partial class TroubleViewForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(TroubleViewForm));
        //byte[] img = new byte[] { 0 };
        public TroubleViewForm(string troubleId, string eqName)
        {
            InitializeComponent();
            text_eqname.Text = eqName;

            DataSet ds = null;
            Account acc = new Account();
            ds = acc.queryTroubleByIdIncludeImage(troubleId);

            dateTime_troubletime.DataBindings.Add(new Binding("Value", ds.Tables[0], "trouble_date"));
            richText_process.DataBindings.Add(new Binding("Text", ds.Tables[0], "process"));
            richText_reason.DataBindings.Add(new Binding("Text", ds.Tables[0], "reason"));
            richText_lose.DataBindings.Add(new Binding("Text", ds.Tables[0], "lose"));
            richText_todo.DataBindings.Add(new Binding("Text", ds.Tables[0], "solve"));
            //img = (byte[])(ds.Tables[0]).Rows[0][6];
            //加载图片
            MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0][6]);
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
