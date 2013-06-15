using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Equipment;
using Microsoft.Reporting.WinForms;

namespace CEMSApp.Equipment
{
    public partial class AccountReportForm : ChildForm
    {
        public AccountReportForm()
        {
            InitializeComponent();
        }

        private void AccountReport_Load(object sender, EventArgs e)
        {
            Account acc = new Account();
            DataSet ds_account = acc.queryAccount();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath ="Equipment/equipment.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds_account.Tables[0])); //ReportDataSource数据源的第一个参数必须与你添加的dataset的名字相同
            this.reportViewer1.RefreshReport();
            
        }
    }
}
