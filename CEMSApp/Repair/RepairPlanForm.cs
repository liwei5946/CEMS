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

namespace CEMSApp.Repair
{
    public partial class RepairPlanForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(RepairPlanForm));
        //DataSet ds_report = null;
        public RepairPlanForm()
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
        /// 为SourceGrid绑定数据源
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="data"></param>
        public void BindSourceGrid(SourceGrid.Grid grid, DataTable data)
        {
            int[] ColumnWidth = new int[] { 40, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 240 };
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
            grid.ColumnsCount = 13;
            grid.FixedRows = 1;
            BuildGridColumnWidth(grid, ColumnWidth);
            grid.Rows.Insert(0);
            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("维修计划ID");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("维修计划编号");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("设备编号");
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("设备名称");
            grid[0, 4] = new SourceGrid.Cells.ColumnHeader("所属部门");
            grid[0, 5] = new SourceGrid.Cells.ColumnHeader("维修级别");
            grid[0, 6] = new SourceGrid.Cells.ColumnHeader("安排日期");
            grid[0, 7] = new SourceGrid.Cells.ColumnHeader("维护天数");
            grid[0, 8] = new SourceGrid.Cells.ColumnHeader("停机天数");
            grid[0, 9] = new SourceGrid.Cells.ColumnHeader("被维修部门");
            grid[0, 10] = new SourceGrid.Cells.ColumnHeader("维修部门");
            grid[0, 11] = new SourceGrid.Cells.ColumnHeader("维修负责人");
            grid[0, 12] = new SourceGrid.Cells.ColumnHeader("维护说明");

            grid[0, 1].View.Font = new Font("宋体", 10, FontStyle.Bold);

            //隐藏列
            grid[0, 0].Column.Visible = false;

            grid[0, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            
            for (int i = 1; i < data.Rows.Count + 1; i++)
            {
                //grid[i + grid.FixedRows, j] = new SourceGrid.Cells.Cell(data.Rows[i][j]);
                //grid[i + grid.FixedRows, j].View =SourceGridView.NormalGridView;
                grid.Rows.Insert(i);
                //设置行高
                //grid.Rows.SetHeight(i, 48);

                #region 表体塞值

                //表体塞值
                grid[i, 0] = new SourceGrid.Cells.Cell(data.Rows[i - 1][0], typeof(int)); //id
                grid[i, 1] = new SourceGrid.Cells.Cell(data.Rows[i - 1][1], typeof(string));//计划编号
                grid[i, 2] = new SourceGrid.Cells.Cell(data.Rows[i - 1][2], typeof(string));//设备编号
                grid[i, 3] = new SourceGrid.Cells.Cell(data.Rows[i - 1][3], typeof(string)); //设备名称
                grid[i, 4] = new SourceGrid.Cells.Cell(data.Rows[i - 1][4], typeof(string)); //所属部门
                grid[i, 5] = new SourceGrid.Cells.Cell(data.Rows[i - 1][5], typeof(string)); //维修级别
                grid[i, 6] = new SourceGrid.Cells.Cell(data.Rows[i - 1][6], typeof(DateTime));//安排日期
                grid[i, 7] = new SourceGrid.Cells.Cell(data.Rows[i - 1][7], typeof(int));//维护天数
                grid[i, 8] = new SourceGrid.Cells.Cell(data.Rows[i - 1][8], typeof(int));//停机天数
                grid[i, 9] = new SourceGrid.Cells.Cell(data.Rows[i - 1][9], typeof(string));//被维修部门
                grid[i, 10] = new SourceGrid.Cells.Cell(data.Rows[i - 1][10], typeof(string));//维修部门
                grid[i, 11] = new SourceGrid.Cells.Cell(data.Rows[i - 1][11], typeof(string));//维修负责人
                grid[i, 12] = new SourceGrid.Cells.Cell(data.Rows[i - 1][12], typeof(string));//维护说明

                #endregion

                //设置单元格不可编辑
                grid[i, 0].Editor.EnableEdit = false;
                grid[i, 1].Editor.EnableEdit = false;
                grid[i, 2].Editor.EnableEdit = false;
                grid[i, 3].Editor.EnableEdit = false;
                grid[i, 4].Editor.EnableEdit = false;  
                grid[i, 5].Editor.EnableEdit = false;
                grid[i, 6].Editor.EnableEdit = false;
                grid[i, 7].Editor.EnableEdit = false;
                grid[i, 8].Editor.EnableEdit = false;
                grid[i, 9].Editor.EnableEdit = false;
                grid[i, 10].Editor.EnableEdit = false;
                grid[i, 11].Editor.EnableEdit = false;
                grid[i, 12].Editor.EnableEdit = false;
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
            //DialogResult dr;
            //Boolean flag = false;
            RepairPlanEditForm mef = new RepairPlanEditForm(id);
            try
            {
                if (grid1[grid1.Selection.ActivePosition.Row, 0] != null)
                {
                    //dr = mef.ShowDialog();
                    //dr = MessageBox.Show("您确认将编号为" + grid1[grid1.Selection.ActivePosition.Row, 1].ToString() + "的记录重新入账？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mef.ShowDialog() == DialogResult.OK)
                    {
                        Account acc = new Account();
                        DataSet ds_RepairPlan = acc.queryRepairPlanByDays(365);
                        BindSourceGrid(grid1, ds_RepairPlan.Tables[0]);
                        grid1.Selection.SelectRow(1, true);
                        grid1.Selection.FocusFirstCell(true);
                    }
                    
                }
                 ///MessageBox.Show(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
            }catch(Exception mye){
                log.Error(mye.Message);
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

        private void MaintainPlanForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Account acc = new Account();
            DataSet ds_RepairPlan = acc.queryRepairPlanByDays(365);
            //ds_report = ds_account;//公共DS，用于报表输出
            BindSourceGrid(grid1, ds_RepairPlan.Tables[0]);

            grid1.Selection.SelectRow(1, true);
            grid1.Selection.FocusFirstCell(true);
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelButton_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            Boolean flag = false;
            Account acc = new Account();
            if (grid1[grid1.Selection.ActivePosition.Row, 0] != null)
            {
                dr = MessageBox.Show("您确认删除编号为" + grid1[grid1.Selection.ActivePosition.Row, 1].ToString() + "的维修计划？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!acc.hasRepairForPlan(grid1[grid1.Selection.ActivePosition.Row, 0].ToString()))
                    {

                        //flag = acc.deleteAccountById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                        //flag = acc.deleteMaintainPlanById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                        flag = acc.deleteRepairPlanById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                        if (flag)
                        {
                            MessageBox.Show("删除成功！");
                            DataSet ds_RepairPlan = acc.queryRepairPlanByDays(365);
                            BindSourceGrid(grid1, ds_RepairPlan.Tables[0]);
                            grid1.Selection.SelectRow(1, true);
                            grid1.Selection.FocusFirstCell(true);
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("已存在下游数据，不允许删除！", "操作流程错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        /// <summary>
        /// 维修记录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintainButton_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            //Boolean flag = false;
            if (grid1[grid1.Selection.ActivePosition.Row, 0] != null)
            {
                dr = MessageBox.Show("您确认为编号为" + grid1[grid1.Selection.ActivePosition.Row, 1].ToString() + "的维修计划增加对应维修记录？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    
                    Account acc = new Account();
                    if (acc.hasRepairForPlan(grid1[grid1.Selection.ActivePosition.Row, 0].ToString()))
                    {
                        //MessageBox.Show("该维修计划已存在对应的维修记录！");
                        MessageBox.Show("该维修计划已存在对应的维修记录！", "操作流程错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //MaintainAddForm maf = new MaintainAddForm(grid1[grid1.Selection.ActivePosition.Row, 0].ToString(), grid1[grid1.Selection.ActivePosition.Row, 1].ToString(), grid1[grid1.Selection.ActivePosition.Row, 2].ToString(), grid1[grid1.Selection.ActivePosition.Row, 3].ToString());
                        //maf.ShowDialog();
                        RepairAddForm raf = new RepairAddForm(grid1[grid1.Selection.ActivePosition.Row, 2].ToString(), grid1[grid1.Selection.ActivePosition.Row, 3].ToString(), grid1[grid1.Selection.ActivePosition.Row, 4].ToString(), grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                        raf.ShowDialog();
                    }
                    /*
                    //flag = acc.deleteAccountById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                    flag = acc.deleteMaintainPlanById(grid1[grid1.Selection.ActivePosition.Row, 0].ToString());
                    if (flag)
                    {
                        MessageBox.Show("删除成功！");
                        DataSet ds_MaintainPlan = acc.queryMaintainPlanByDays(365);//查询365天前到今天的维护计划信息
                        BindSourceGrid(grid1, ds_MaintainPlan.Tables[0]);
                        grid1.Selection.SelectRow(1, true);
                        grid1.Selection.FocusFirstCell(true);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                     * */
                }
            }
        }


    }
}
