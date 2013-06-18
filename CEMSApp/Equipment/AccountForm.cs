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
using log4net;

namespace CEMSApp.Equipment
{
    public partial class AccountForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(AccountForm));
        public AccountForm()
        {
            InitializeComponent();
        }
        public struct ComboBoxItem<TKey, TValue>
        {
            private TKey key;
            private TValue value;

            public ComboBoxItem(TKey key, TValue value)
            {
                this.key = key;
                this.value = value;
            }

            public TKey Key
            {
                get { return key; }
            }

            public TValue Value
            {
                get { return value; }
            }

            public override string ToString()
            {
                return Value.ToString();
            }
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
            //InitTree(tree_department, ds1, "所有部门", "id", "departname");
           // InitTree(tree_eqType, ds2, "所有设备类型", "id", "type_name");
            InitComboBox(depart_ComboBox, ds1, "id", "departname");
            InitComboBox(equ_ComboBox, ds2, "id", "type_name");
            //equ_ComboBox.ComboBox.Items.Insert(0, new ComboBoxItem<string, string>("0", "所有"));
            //equ_ComboBox.ComboBox.Items.Add(new ComboBoxItem<string, string>("0", "所有"));
            //sourcegrid试验
            //BindSourceGrid(grid1, ds1.Tables[0]);
            DataSet ds_account = acc.queryAccount();
            BindSourceGrid(grid1, ds_account.Tables[0]);
            //grid1.Selection.ActivePosition.Row
            grid1.Selection.SelectRow(1, true);
            grid1.Selection.FocusFirstCell(true);
        }
        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="ds"></param>
        /// <param name="ValueMember">数据ID</param>
        /// <param name="DisplayMember">数据显示项的列名</param>
        private void InitComboBox(ToolStripComboBox cb, DataSet ds, string ValueMember, string DisplayMember)
        {
            if (ds != null)
            {
                cb.ComboBox.DataSource = ds.Tables[0];
                cb.ComboBox.DisplayMember = DisplayMember;
                cb.ComboBox.ValueMember = ValueMember;
                //cb.ComboBox.Items.Insert(0, new ComboBoxItem<string, string>("0", "所有"));
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            AccountAddForm addForm = new AccountAddForm();
            //addForm.ShowDialog();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                //重新绑定DataGridView;
                Account acc = new Account();
                DataSet ds_account = acc.queryAccount();
                BindSourceGrid(grid1, ds_account.Tables[0]);
                grid1.Selection.SelectRow(1, true);
                grid1.Selection.FocusFirstCell(true);
            }
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
        /// <summary>
        /// 为SourceGrid绑定数据源
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="data"></param>
        public void BindSourceGrid(SourceGrid.Grid grid, DataTable data)
        {
            byte[] imagebytes = null;
            byte[] objBytes = null;
            int[] ColumnWidth = new int[] { 40, 80, 100, 64, 80 };
            PopupMenu menuController = new PopupMenu();
            if (grid.RowsCount > 0)
            {
                grid.Rows.RemoveRange(0, grid.RowsCount);
            }
            //Redim grid
            //grid.Redim(data.Rows.Count + grid.FixedRows, data.Columns.Count);
            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;//选行模式
            grid.Selection.EnableMultiSelection = false; //行不允许多选
            grid.EnableSort = false; //不允许排序
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.ColumnsCount = 5;
            grid.FixedRows = 1;
            BuildGridColumnWidth(grid, ColumnWidth);
            grid.Rows.Insert(0);
            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("序号");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("资产编号");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("设备名称");
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("设备图片");
            grid[0, 4] = new SourceGrid.Cells.ColumnHeader("三维模型");

            grid[0, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            grid[0, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            grid[0, 2].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            grid[0, 3].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            grid[0, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            //grid[0, 3].Column.Grid.EnableSort = false;
            
            for (int i = 1; i < data.Rows.Count + 1; i++)
            {
                //grid[i + grid.FixedRows, j] = new SourceGrid.Cells.Cell(data.Rows[i][j]);
                //grid[i + grid.FixedRows, j].View =SourceGridView.NormalGridView;
                grid.Rows.Insert(i);
                //设置行高
                grid.Rows.SetHeight(i, 48);
                grid[i, 0] = new SourceGrid.Cells.Cell(data.Rows[i - 1][0], typeof(int));
                grid[i, 1] = new SourceGrid.Cells.Cell(data.Rows[i - 1][1], typeof(string));
                grid[i, 2] = new SourceGrid.Cells.Cell(data.Rows[i - 1][2], typeof(string));
                
                //将图片显示在单元格中
                imagebytes = (byte[])data.Rows[i - 1][3];
                MemoryStream ms = new MemoryStream(imagebytes);
                Image img = Image.FromStream(ms);
                //pb.Image = img;
                grid[i, 3] = new SourceGrid.Cells.Image(img);

                //设置obj浏览
                grid[i, 4] = new SourceGrid.Cells.Button("三维预览");
                grid[i, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                grid[i, 4].Controller.AddController(new objButtonClickController()); //单击按钮事件
                //设置单元格不可编辑
                grid[i, 0].Editor.EnableEdit = false;
                grid[i, 1].Editor.EnableEdit = false;
                grid[i, 2].Editor.EnableEdit = false;
                grid[i, 3].Editor.EnableEdit = false;
                //为表单添加右键选项
                //grid[i, 0].AddController(menuController);
                //grid[i, 1].AddController(menuController);
                //grid[i, 2].AddController(menuController);
                //grid[i, 3].AddController(menuController);

            }
            grid.Refresh();
        }
        public void BuildGridColumnWidth(SourceGrid.Grid Grid, int[] ColumnWidth)
        {
            for (int i = 0; i < ColumnWidth.Length; i++)
            {
                Grid.Columns[i].Width = ColumnWidth[i];
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                 MessageBox.Show(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
            }catch(Exception mye){
                log.Error(mye.Message);
            }
               
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Boolean flag = false;
            if (grid1[grid1.Selection.ActivePosition.Row, 0] != null)
            {
                dr = MessageBox.Show("您确认删除序号为" + grid1[grid1.Selection.ActivePosition.Row, 0].ToString() + "的记录？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Account acc = new Account();
                    flag = acc.deleteAccountById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                    if (flag)
                    {
                        MessageBox.Show("删除成功！");
                        DataSet ds_account = acc.queryAccount();
                        BindSourceGrid(grid1, ds_account.Tables[0]);
                        grid1.Selection.SelectRow(1, true);
                        grid1.Selection.FocusFirstCell(true);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void report_Button_Click(object sender, EventArgs e)
        {
            AccountReportForm ar = new AccountReportForm();
            ar.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Account3DViewerForm a3d = new Account3DViewerForm();
            a3d.ShowDialog();
        }

    }
    /// <summary>
    /// 右键控制项
    /// </summary>
    public class PopupMenu : SourceGrid.Cells.Controllers.ControllerBase
    {
        ContextMenu menu = new ContextMenu();
        public PopupMenu()
        {
            menu.MenuItems.Add("修改", new EventHandler(Menu1_Click));
            menu.MenuItems.Add("删除", new EventHandler(Menu2_Click));
        }

        public override void OnMouseUp(SourceGrid.CellContext sender, MouseEventArgs e)
        {
            base.OnMouseUp(sender, e);

            if (e.Button == MouseButtons.Right)
                menu.Show(sender.Grid, new Point(e.X, e.Y));
        }

        private void Menu1_Click(object sender, EventArgs e)
        {
            //TODO Your code here
            //MessageBox.Show("数据添加成功！");
        }
        private void Menu2_Click(object sender, EventArgs e)
        {
            //TODO Your code here
        }
    }
    /// <summary>
    /// 单击单元格中按钮事件
    /// </summary>
    public class objButtonClickController : SourceGrid.Cells.Controllers.ControllerBase
    {
        public override void OnClick(SourceGrid.CellContext sender, EventArgs e)
        {
            base.OnClick(sender, e);
            //object val = sender.Value;
            //object val = sender.Position.Row;
            object val = sender.Grid.GetCell(sender.Position.Row, 0);
            if (val != null)
                MessageBox.Show(sender.Grid, val.ToString());
        }

    }
}
