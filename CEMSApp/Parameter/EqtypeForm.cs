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

namespace CEMSApp.Parameter
{
    /// <summary>
    /// 本通用窗体使用方法：
    /// 1.修改窗体标题栏名称
    /// 2.修改Load方法内容
    /// 3.修改“修改按钮”回传刷新代码，修改按钮实例化代码
    /// 4.修改“添加按钮”回传刷新代码，添加窗体实例化代码
    /// 5.修改“删除按钮”回传刷新代码
    /// </summary>
    public partial class EqtypeForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(EqtypeForm));
        //DataSet ds_report = null;
        public EqtypeForm()
        {
            InitializeComponent();
        }
        //窗体初始化
        private void AccountForm_Load(object sender, EventArgs e)
        {
            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;//将光标置为等待状态
           
            //this.WindowState = FormWindowState.Maximized;
            //数据格
            Account acc = new Account();
            DataSet ds = acc.queryInfomation("eq_type");
            BindSourceGrid(grid1, ds.Tables[0],"设备类型");
            grid1.Selection.SelectRow(1, true);
            grid1.Selection.FocusFirstCell(true);
            Cursor.Current = cr;//将光标置回原来状态 
        }
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            EqtypeAddForm addForm = new EqtypeAddForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                //重新绑定DataGridView;
                Account acc = new Account();
                DataSet ds = acc.queryInfomation("eq_type");
                BindSourceGrid(grid1, ds.Tables[0], "设备类型");
                grid1.Selection.SelectRow(1, true);
                grid1.Selection.FocusFirstCell(true);
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
            EqtypeEditForm editForm = new EqtypeEditForm(id);
            try
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    Account acc = new Account();
                    DataSet ds = acc.queryInfomation("eq_type");
                    BindSourceGrid(grid1, ds.Tables[0], "设备类型");
                    grid1.Selection.SelectRow(1, true);
                    grid1.Selection.FocusFirstCell(true);
                }
                ///MessageBox.Show(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
            }
            catch (Exception mye)
            {
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
                dr = MessageBox.Show("您确认删除此条记录？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Account acc = new Account();
                    //flag = acc.deleteFaultById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                    flag = acc.deleteInfomation(grid1[grid1.Selection.ActivePosition.Row, 0].ToString(), "eq_type");
                    if (flag)
                    {
                        MessageBox.Show("删除成功！");
                        DataSet ds = acc.queryInfomation("eq_type");
                        BindSourceGrid(grid1, ds.Tables[0], "设备类型");
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
        /// 为SourceGrid绑定数据源
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="data"></param>
        public void BindSourceGrid(SourceGrid.Grid grid, DataTable data, string colName)
        {
            int[] ColumnWidth = new int[] { 40, 200};
            //PopupMenu menuController = new PopupMenu();
            if (grid.RowsCount > 0)
            {
                //清除原表格内容
                grid.Rows.RemoveRange(0, grid.RowsCount);
            }
            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;//选行模式
            grid.Selection.EnableMultiSelection = false; //行不允许多选
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.ColumnsCount = 2;
            grid.FixedRows = 1;
            BuildGridColumnWidth(grid, ColumnWidth);
            grid.Rows.Insert(0);
            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("ID");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader(colName);

            grid[0, 1].View.Font = new Font("宋体", 10, FontStyle.Bold);

            //隐藏列
            grid[0, 0].Column.Visible = false;

            grid[0, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            for (int i = 1; i < data.Rows.Count + 1; i++)
            {
                grid.Rows.Insert(i);
                //设置行高
                grid.Rows.SetHeight(i, 30);

                #region 表体塞值

                //表体塞值
                grid[i, 0] = new SourceGrid.Cells.Cell(data.Rows[i - 1][0], typeof(int)); //id
                grid[i, 1] = new SourceGrid.Cells.Cell(data.Rows[i - 1][1], typeof(string));//名称

                #endregion

                //设置单元格不可编辑
                grid[i, 0].Editor.EnableEdit = false;
                grid[i, 1].Editor.EnableEdit = false;

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
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
 




}
