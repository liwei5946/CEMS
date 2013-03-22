﻿using System;
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
            BindSourceGrid(grid1, ds_account.Tables[0]);
            //grid1.Selection.ActivePosition.Row
            grid1.Selection.SelectRow(1, true);
            grid1.Selection.FocusFirstCell(true);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
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
        /// <summary>
        /// 为SourceGrid绑定数据源
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="data"></param>
        public void BindSourceGrid(SourceGrid.Grid grid, DataTable data)
        {
            byte[] imagebytes = null;
            int[] ColumnWidth = new int[] { 40, 80, 100, 64 };
            PopupMenu menuController = new PopupMenu();
            //Redim grid
            //grid.Redim(data.Rows.Count + grid.FixedRows, data.Columns.Count);
            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.ColumnsCount = 4;
            grid.FixedRows = 1;
            BuildGridColumnWidth(grid, ColumnWidth);
            grid.Rows.Insert(0);
            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("序号");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("资产编号");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("设备名称");
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("设备图片");

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
                MessageBox.Show(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Boolean flag = false;
            dr = MessageBox.Show("您确认删除序号为"+grid1[grid1.Selection.ActivePosition.Row, 0].ToString()+"的记录？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Account acc = new Account();
                flag = acc.deleteAccountById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                if (flag)
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
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
}
