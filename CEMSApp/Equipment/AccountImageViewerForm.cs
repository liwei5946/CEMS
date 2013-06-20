using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CEMSApp.Equipment
{
    public partial class AccountImageViewerForm : ChildForm
    {
        public AccountImageViewerForm(byte[] imgBytes)
        {
            InitializeComponent();
            MemoryStream ms = new MemoryStream(imgBytes);
            Image img = Image.FromStream(ms);
            pictureBox1.Image = img;
            ms.Close();
        }
    }
}
