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

namespace CEMSApp.Login
{
    public partial class UserForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(UserForm));
        //DataSet ds_report = null;
        public UserForm()
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
            DataSet ds = acc.queryUsers();
            BindSourceGrid(grid1, ds.Tables[0]);
            grid1.Selection.SelectRow(1, true);
            grid1.Selection.FocusFirstCell(true);
            Cursor.Current = cr;//将光标置回原来状态 
        }


        /// <summary>
        /// 为SourceGrid绑定数据源
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="data"></param>
        public void BindSourceGrid(SourceGrid.Grid grid, DataTable data)
        {
            //byte[] imagebytes = null;

            int[] ColumnWidth = new int[] { 120, 100, 100 };
            //PopupMenu menuController = new PopupMenu();
            if (grid.RowsCount > 0)
            {
                //清除原表格内容
                grid.Rows.RemoveRange(0, grid.RowsCount);
            }
            //Redim grid
            //grid.Redim(data.Rows.Count + grid.FixedRows, data.Columns.Count);
            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;//选行模式
            grid.Selection.EnableMultiSelection = false; //行不允许多选
            //grid.EnableSort = false; //不允许排序
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.ColumnsCount = 3;
            grid.FixedRows = 1;
            BuildGridColumnWidth(grid, ColumnWidth);
            grid.Rows.Insert(0);
            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("用户名");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("姓名");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("用户角色");

            grid[0, 1].View.Font = new Font("宋体", 10, FontStyle.Bold);

            grid[0, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            for (int i = 1; i < data.Rows.Count + 1; i++)
            {
                grid.Rows.Insert(i);
                //设置行高
                grid.Rows.SetHeight(i, 30);

                #region 表体塞值

                //表体塞值
                grid[i, 0] = new SourceGrid.Cells.Cell(data.Rows[i - 1][0], typeof(string)); //用户名
                grid[i, 1] = new SourceGrid.Cells.Cell(data.Rows[i - 1][1], typeof(string));//姓名
                //grid[i, 2] = new SourceGrid.Cells.Cell(data.Rows[i - 1][2], typeof(string));//用户角色
                if (data.Rows[i - 1][2].ToString() == "0")
                {
                    grid[i, 2] = new SourceGrid.Cells.Cell("普通用户", typeof(string));
                }
                else if (data.Rows[i - 1][2].ToString() == "1")
                {
                    grid[i, 2] = new SourceGrid.Cells.Cell("管理员", typeof(string));
                }
                else
                {
                    grid[i, 2] = new SourceGrid.Cells.Cell("未知角色", typeof(string));
                }

                #endregion

                //设置单元格不可编辑
                grid[i, 0].Editor.EnableEdit = false;
                grid[i, 1].Editor.EnableEdit = false;
                grid[i, 2].Editor.EnableEdit = false;
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
            UserEditForm kef = new UserEditForm(id);
            try
            {
                if (kef.ShowDialog() == DialogResult.OK)
                {
                    Account acc = new Account();
                    DataSet ds = acc.queryUsers();
                    BindSourceGrid(grid1, ds.Tables[0]);
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
                dr = MessageBox.Show("您确认删除用户\"" + grid1[grid1.Selection.ActivePosition.Row, 0].ToString() + "\"？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Account acc = new Account();
                    //flag = acc.deleteFaultById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                    //flag = acc.deleteKnowledgeById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                    flag = acc.deleteUserByUsername(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                    if (flag)
                    {
                        MessageBox.Show("删除成功！");
                        DataSet ds = acc.queryUsers();
                        BindSourceGrid(grid1, ds.Tables[0]);
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
            UserAddForm uaf = new UserAddForm();
            if (uaf.ShowDialog() == DialogResult.OK)
            {
                //重新绑定DataGridView;
                Account acc = new Account();
                DataSet ds = acc.queryUsers();
                BindSourceGrid(grid1, ds.Tables[0]);
                grid1.Selection.SelectRow(1, true);
                grid1.Selection.FocusFirstCell(true);
            }
        }

        private void chongzhimima_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Boolean flag = false;
            if (grid1[grid1.Selection.ActivePosition.Row, 0] != null)
            {
                dr = MessageBox.Show("您确认将用户\"" + grid1[grid1.Selection.ActivePosition.Row, 0].ToString() + "\"的密码重置为初始密码\"123456\"吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Account acc = new Account();
                    //flag = acc.deleteFaultById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                    //flag = acc.deleteKnowledgeById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                    flag = acc.updatePasswordForInit(grid1[grid1.Selection.ActivePosition.Row, 0].ToString(), "123456");
                    if (flag)
                    {
                        MessageBox.Show("密码重置成功！");
                    }
                    else
                    {
                        MessageBox.Show("密码重置失败！");
                    }
                }
            }
        }



    }

}
