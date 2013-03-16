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
    public partial class AccountAddForm : ChildForm
    {
        public AccountAddForm()
        {
            InitializeComponent();
        }

        private void AccountAddForm_Load(object sender, EventArgs e)
        {

        }

        private void AccountAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
