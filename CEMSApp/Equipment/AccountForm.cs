using System;
using System.IO;
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
            /*
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
             * */

            //处理department treeview显示
            DataSet ds1 = null, ds2 = null;
            Account acc = new Account();
            ds1 = acc.CreateDataSet_Department();
            ds2 = acc.CreateDataSet_EquipmentType();
            InitTree(tree_department, ds1, "所有部门", "id", "departname");
            InitTree(tree_eqType, ds2, "所有设备类型", "id", "type_name");

            //sourcegrid试验
            //BindSourceGrid(grid1, ds1.Tables[0]);
            DataSet ds_account = acc.queryAccount();
            BindSourceGrid(grid1, ds_account.Tables[0], pictureBox1);
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
        /// <summary>
        /// 初始化TreeView控件
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="ds"></param>
        /// <param name="rootText"></param>
        /// <param name="tnName"></param>
        /// <param name="tnText"></param>
        private void InitTree(TreeView tv, DataSet ds, string rootText, string tnName, string tnText)
        {
            tv.Nodes.Clear();
            TreeNode tn = new TreeNode(rootText);
            tv.Nodes.Add(tn);
            DataView dv = new DataView(ds.Tables[0]);//将DataTable存到DataView中，以便于筛选数据
            foreach (DataRowView drv in dv)
            {
                tn = new TreeNode();
                tn.Name = drv[tnName].ToString();//节点的name值，一般为数据库的id值
                tn.Text = drv[tnText].ToString();//节点的Text，节点的文本显示
                tv.Nodes[0].Nodes.Add(tn);
            }
            tv.ExpandAll();
        }
        /*
        public static void BindSourceGrid(SourceGrid.Grid grid, DataTable data)
        {
            //Redim grid
            grid.Redim(data.Rows.Count + grid.FixedRows, data.Columns.Count);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    grid[i + grid.FixedRows, j] = new SourceGrid.Cells.Cell(data.Rows[i][j]);
                    //grid[i + grid.FixedRows, j].View =SourceGridView.NormalGridView;
                }
            }
            grid.Refresh();
        }
         */
        public static void BindSourceGrid(SourceGrid.Grid grid, DataTable data, PictureBox pb)
        {
            byte[] imagebytes = null;
            //Redim grid
            //grid.Redim(data.Rows.Count + grid.FixedRows, data.Columns.Count);
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.ColumnsCount = 4;
            grid.FixedRows = 1;
            grid.Rows.Insert(0);
            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("序号 ");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("资产编号");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("设备名称");
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("设备图片");
            
            for (int i = 0; i < data.Rows.Count; i++)
            {
                //grid[i + grid.FixedRows, j] = new SourceGrid.Cells.Cell(data.Rows[i][j]);
                //grid[i + grid.FixedRows, j].View =SourceGridView.NormalGridView;
                grid.Rows.Insert(i);
                grid[i, 0] = new SourceGrid.Cells.Cell(data.Rows[i][0], typeof(int));
                grid[i, 1] = new SourceGrid.Cells.Cell(data.Rows[i][1], typeof(string));
                grid[i, 2] = new SourceGrid.Cells.Cell(data.Rows[i][2], typeof(string));
                using (DataTableReader reader = data.CreateDataReader())
                {
                    reader.Read();
                    imagebytes = (byte[])reader.GetValue(3);
                    
                }
                MemoryStream ms = new MemoryStream(imagebytes);
                Image img = Image.FromStream(ms);
                pb.Image = img;
                //((SourceGrid.Cells.Link)gridColumn.DataCell).Image = img;
                grid[i, 3] = new SourceGrid.Cells.Image(img);
                //grid[i, 3].Image = img;
            }
            grid.Refresh();
        }

    }
}
