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
        DataSet ds_report = null;
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
        //窗体初始化
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
            ds_report = ds_account;//公共DS，用于报表输出
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

            int[] ColumnWidth = new int[] { 40, 80, 100, 64, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80 };
            PopupMenu menuController = new PopupMenu();
            if (grid.RowsCount > 0)
            {
                //清除原表格内容
                grid.Rows.RemoveRange(0, grid.RowsCount);
            }
            //Redim grid
            //grid.Redim(data.Rows.Count + grid.FixedRows, data.Columns.Count);
            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;//选行模式
            grid.Selection.EnableMultiSelection = false; //行不允许多选
            grid.EnableSort = false; //不允许排序
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.ColumnsCount = 23;
            grid.FixedRows = 1;
            BuildGridColumnWidth(grid, ColumnWidth);
            grid.Rows.Insert(0);
            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("序号");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("资产编号");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("设备名称");
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("设备图片");
            grid[0, 4] = new SourceGrid.Cells.ColumnHeader("三维模型");
            grid[0, 5] = new SourceGrid.Cells.ColumnHeader("是否销帐");
            grid[0, 6] = new SourceGrid.Cells.ColumnHeader("设备型号");
            grid[0, 7] = new SourceGrid.Cells.ColumnHeader("设备规格");
            grid[0, 8] = new SourceGrid.Cells.ColumnHeader("所属部门");
            grid[0, 9] = new SourceGrid.Cells.ColumnHeader("设备重量");
            grid[0, 10] = new SourceGrid.Cells.ColumnHeader("品牌");
            grid[0, 11] = new SourceGrid.Cells.ColumnHeader("制造商");
            grid[0, 12] = new SourceGrid.Cells.ColumnHeader("供应商");
            grid[0, 13] = new SourceGrid.Cells.ColumnHeader("制造日期");
            grid[0, 14] = new SourceGrid.Cells.ColumnHeader("投产日期");
            grid[0, 15] = new SourceGrid.Cells.ColumnHeader("建档日期");
            grid[0, 16] = new SourceGrid.Cells.ColumnHeader("设备价值");
            grid[0, 17] = new SourceGrid.Cells.ColumnHeader("设备数量");
            grid[0, 18] = new SourceGrid.Cells.ColumnHeader("电机数量");
            grid[0, 19] = new SourceGrid.Cells.ColumnHeader("总功率");
            grid[0, 20] = new SourceGrid.Cells.ColumnHeader("设备状态");
            grid[0, 21] = new SourceGrid.Cells.ColumnHeader("设备分类");
            grid[0, 22] = new SourceGrid.Cells.ColumnHeader("安装地点");

            grid[0, 1].View.Font = new Font("宋体", 10, FontStyle.Bold);

            //隐藏列
            grid[0, 0].Column.Visible = false;
            grid[0, 5].Column.Visible = false;

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

                #region 表体塞值

                //表体塞值
                grid[i, 0] = new SourceGrid.Cells.Cell(data.Rows[i - 1][0], typeof(int)); //id
                grid[i, 1] = new SourceGrid.Cells.Cell(data.Rows[i - 1][1], typeof(string));//设备编号
                grid[i, 2] = new SourceGrid.Cells.Cell(data.Rows[i - 1][2], typeof(string));//设备名称

                //将图片显示在单元格中
                imagebytes = (byte[])data.Rows[i - 1][3];
                MemoryStream ms = new MemoryStream(imagebytes);
                Image img = Image.FromStream(ms);
                //pb.Image = img;
                grid[i, 3] = new SourceGrid.Cells.Image(img);
                grid[i, 3].AddController(new imageDoubleClickController()); //双击图片放大查看
                ms.Close();

                //设置obj浏览
                grid[i, 4] = new SourceGrid.Cells.Button("三维预览");
                grid[i, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                grid[i, 4].AddController(new objButtonClickController()); //单击按钮事件 

                grid[i, 5] = new SourceGrid.Cells.Cell(data.Rows[i - 1][4], typeof(int)); //是否销帐
                grid[i, 6] = new SourceGrid.Cells.Cell(data.Rows[i - 1][5], typeof(string));//设备型号
                grid[i, 7] = new SourceGrid.Cells.Cell(data.Rows[i - 1][6], typeof(string));//设备规格
                grid[i, 8] = new SourceGrid.Cells.Cell(data.Rows[i - 1][7], typeof(string));//部门id
                grid[i, 9] = new SourceGrid.Cells.Cell(data.Rows[i - 1][8], typeof(string));//设备重量
                grid[i, 10] = new SourceGrid.Cells.Cell(data.Rows[i - 1][9], typeof(string));//品牌
                grid[i, 11] = new SourceGrid.Cells.Cell(data.Rows[i - 1][10], typeof(string));//制造商
                grid[i, 12] = new SourceGrid.Cells.Cell(data.Rows[i - 1][11], typeof(string));//供应商
                grid[i, 13] = new SourceGrid.Cells.Cell(data.Rows[i - 1][12], typeof(DateTime));//制造日期
                grid[i, 14] = new SourceGrid.Cells.Cell(data.Rows[i - 1][13], typeof(DateTime));//投产年月
                grid[i, 15] = new SourceGrid.Cells.Cell(data.Rows[i - 1][14], typeof(DateTime));//建档日期
                grid[i, 16] = new SourceGrid.Cells.Cell(string.Format("{0:#.00}", data.Rows[i - 1][15]), typeof(string));//设备价值
                grid[i, 17] = new SourceGrid.Cells.Cell(data.Rows[i - 1][16], typeof(int));//设备数量
                grid[i, 18] = new SourceGrid.Cells.Cell(data.Rows[i - 1][17], typeof(int));//电机数量
                grid[i, 19] = new SourceGrid.Cells.Cell(string.Format("{0:#.00}", data.Rows[i - 1][18]), typeof(string));//总功率
                grid[i, 20] = new SourceGrid.Cells.Cell(data.Rows[i - 1][19], typeof(string));//设备状态
                grid[i, 21] = new SourceGrid.Cells.Cell(data.Rows[i - 1][20], typeof(string));//设备分类
                grid[i, 22] = new SourceGrid.Cells.Cell(data.Rows[i - 1][21], typeof(string));//安装地点

                grid[i, 5] = new SourceGrid.Cells.Cell(data.Rows[i - 1][4], typeof(int));
                #endregion

                //设置单元格不可编辑
                grid[i, 0].Editor.EnableEdit = false;
                grid[i, 1].Editor.EnableEdit = false;
                grid[i, 2].Editor.EnableEdit = false;
                grid[i, 3].Editor.EnableEdit = false;
                //grid[i, 4].Editor.EnableEdit = false;   //Obj按钮
                grid[i, 5].Editor.EnableEdit = false;
                grid[i, 6].Editor.EnableEdit = false;
                grid[i, 7].Editor.EnableEdit = false;
                grid[i, 8].Editor.EnableEdit = false;
                grid[i, 9].Editor.EnableEdit = false;
                grid[i, 10].Editor.EnableEdit = false;
                grid[i, 11].Editor.EnableEdit = false;
                grid[i, 12].Editor.EnableEdit = false;
                grid[i, 13].Editor.EnableEdit = false;
                grid[i, 14].Editor.EnableEdit = false;
                grid[i, 15].Editor.EnableEdit = false;
                grid[i, 16].Editor.EnableEdit = false;
                grid[i, 17].Editor.EnableEdit = false;
                grid[i, 18].Editor.EnableEdit = false;
                grid[i, 19].Editor.EnableEdit = false;
                grid[i, 20].Editor.EnableEdit = false;
                grid[i, 21].Editor.EnableEdit = false;
                grid[i, 22].Editor.EnableEdit = false;

                //为表单添加右键选项
                //grid[i, 0].AddController(menuController);
                //grid[i, 1].AddController(menuController);
                //grid[i, 2].AddController(menuController);
                //grid[i, 3].AddController(menuController);


            }
            grid.Refresh();
        }
        /// <summary>
        /// 表格列宽设置
        /// </summary>
        /// <param name="Grid"></param>
        /// <param name="ColumnWidth"></param>
        public void BuildGridColumnWidth(SourceGrid.Grid Grid, int[] ColumnWidth)
        {
            for (int i = 0; i < ColumnWidth.Length; i++)
            {
                Grid.Columns[i].Width = ColumnWidth[i];
            }
        }
        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, EventArgs e)
        {
            string id = grid1[grid1.Selection.ActivePosition.Row, 0].ToString();//选中行的id
            AccountEditForm acf = new AccountEditForm(id);
            try
            {
                if (acf.ShowDialog() == DialogResult.OK)
                {
                    Account acc = new Account();
                    DataSet ds_account = acc.queryAccount();
                    BindSourceGrid(grid1, ds_account.Tables[0]);
                    grid1.Selection.SelectRow(1, true);
                    grid1.Selection.FocusFirstCell(true);
                }
                 ///MessageBox.Show(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
            }catch(Exception mye){
                log.Error(mye.Message);
            }
               
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 报表按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void report_Button_Click(object sender, EventArgs e)
        {
            AccountReportForm ar = new AccountReportForm(ds_report);
            ar.ShowDialog();
        }
        /// <summary>
        /// 销帐按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeoffButton_Click(object sender, EventArgs e)
        {
            //DialogResult dr;
            //log.Debug(grid1[grid1.Selection.ActivePosition.Row, 0].Value);
            //log.Debug(grid1[grid1.Selection.ActivePosition.Row, 1].Value);
            //log.Debug(grid1[grid1.Selection.ActivePosition.Row, 2].Value);
            AccountOffForm aof = new AccountOffForm(grid1[grid1.Selection.ActivePosition.Row, 0].Value.ToString(), grid1[grid1.Selection.ActivePosition.Row, 1].Value.ToString(), grid1[grid1.Selection.ActivePosition.Row, 2].Value.ToString());

            if (aof.ShowDialog() == DialogResult.OK)
            {
                //重新绑定DataGridView;
                Account acc = new Account();
                DataSet ds_account = acc.queryAccount();
                BindSourceGrid(grid1, ds_account.Tables[0]);
                grid1.Selection.SelectRow(1, true);
                grid1.Selection.FocusFirstCell(true);
            }
            //Account acc = new Account();
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
    /// 单击单元格中查看obj三维模型按钮事件
    /// </summary>
    public class objButtonClickController : SourceGrid.Cells.Controllers.ControllerBase
    {
        public override void OnClick(SourceGrid.CellContext sender, EventArgs e)
        {
            Account acc = new Account();
            base.OnClick(sender, e);
            //object val = sender.Value;
            //object val = sender.Position.Row;
            object val = sender.Grid.GetCell(sender.Position.Row, 0);//获取ID号，注意要和grid的行列坐标对应！
            byte[] objBytes = null;
            if (val != null)
            {
                DataSet ds_obj = acc.queryAccountObjById(val.ToString());
                DataTable data = ds_obj.Tables[0];
                //MessageBox.Show(sender.Grid, val.ToString());
                byte[] testByte = BitConverter.GetBytes(0x00);
                //MessageBox.Show(testByte[0].ToString());
                //MessageBox.Show(((byte[])data.Rows[0][3])[0].ToString());
                if ( ((byte[])data.Rows[0][3])[0] != testByte[0])//是否存在三维模型
                {
                    objBytes = (byte[])data.Rows[0][3];
                    Account3DViewerForm a3d = new Account3DViewerForm(objBytes);
                    a3d.Text = data.Rows[0][0].ToString() + "-" + data.Rows[0][1].ToString() + "-" + data.Rows[0][2].ToString();
                    a3d.ShowDialog();
                }
                else
                {
                    MessageBox.Show("该设备无三维模型！");
                }
                
                
            }
                
        }

    }
    /// <summary>
    /// 双击查看图片事件
    /// </summary>
    public class imageDoubleClickController : SourceGrid.Cells.Controllers.ControllerBase
    {
        public override void OnDoubleClick(SourceGrid.CellContext sender, EventArgs e)
        {
            Account acc = new Account();
            base.OnDoubleClick(sender, e);
            //object val = sender.Value;
            //object val = sender.Position.Row;
            object val = sender.Grid.GetCell(sender.Position.Row, 0);//获取ID号，注意要和grid的行列坐标对应！
            byte[] imgBytes = null;
            if (val != null)
            {
                DataSet ds_img = acc.queryAccountImgById(val.ToString());
                DataTable data = ds_img.Tables[0];
                //MessageBox.Show(sender.Grid, val.ToString());
                byte[] testByte = BitConverter.GetBytes(0x00);
                //MessageBox.Show(testByte[0].ToString());
                //MessageBox.Show(((byte[])data.Rows[0][3])[0].ToString());
                if (((byte[])data.Rows[0][3])[0] != testByte[0])//是否存在图片
                {
                    imgBytes = (byte[])data.Rows[0][3];
                    //Account3DViewerForm a3d = new Account3DViewerForm(imgBytes);
                    AccountImageViewerForm aivf = new AccountImageViewerForm(imgBytes);
                    aivf.Text = data.Rows[0][0].ToString() + "-" + data.Rows[0][1].ToString() + "-" + data.Rows[0][2].ToString();
                    aivf.ShowDialog();
                }
                else
                {
                    MessageBox.Show("该设备无图片！");
                }


            }

        }

    }
}
