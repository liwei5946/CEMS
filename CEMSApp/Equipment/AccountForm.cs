using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CEMSApp.Equipment
{
    public partial class AccountForm : ChildForm
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //数据格
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 3;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("String");
            grid1[0, 1] = new SourceGrid.Cells.ColumnHeader("DateTime");
            grid1[0, 2] = new SourceGrid.Cells.ColumnHeader("CheckBox");
            for (int r = 1; r < 10; r++)
            {
                grid1.Rows.Insert(r);
                grid1[r, 0] = new SourceGrid.Cells.Cell("Hello " + r.ToString(), typeof(string));
                grid1[r, 1] = new SourceGrid.Cells.Cell(DateTime.Today, typeof(DateTime));
                grid1[r, 2] = new SourceGrid.Cells.CheckBox(null, true);
            }

            grid1.AutoSizeCells();
             

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            /*
            foreach (Form childrenForm in this.MdiChildren)
            {
                if (childrenForm.Name == "AccountAddForm")
                {
                    childrenForm.Visible = true;
                    childrenForm.Activate();
                    return;
                }
            }
            */
            AccountAddForm addForm = new AccountAddForm();
            addForm.ShowDialog();
        }
    }
}
