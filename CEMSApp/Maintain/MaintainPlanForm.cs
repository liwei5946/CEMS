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

namespace CEMSApp.Maintain
{
    public partial class MaintainPlanForm : ChildForm
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MaintainPlanForm));
        //DataSet ds_report = null;
        public MaintainPlanForm()
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
            int[] ColumnWidth = new int[] { 40, 100, 100, 100, 100, 100, 100, 240 };
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
            grid.ColumnsCount = 8;
            grid.FixedRows = 1;
            BuildGridColumnWidth(grid, ColumnWidth);
            grid.Rows.Insert(0);
            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("序号");
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("计划编号");
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("设备名称");
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("设备编号");
            grid[0, 4] = new SourceGrid.Cells.ColumnHeader("所属部门");
            grid[0, 5] = new SourceGrid.Cells.ColumnHeader("安排日期");
            grid[0, 6] = new SourceGrid.Cells.ColumnHeader("维护天数");
            grid[0, 7] = new SourceGrid.Cells.ColumnHeader("维护说明");

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
                grid[i, 2] = new SourceGrid.Cells.Cell(data.Rows[i - 1][2], typeof(string));//设备名称
                grid[i, 3] = new SourceGrid.Cells.Cell(data.Rows[i - 1][3], typeof(string)); //设备编号
                grid[i, 4] = new SourceGrid.Cells.Cell(data.Rows[i - 1][4], typeof(string)); //所属部门
                grid[i, 5] = new SourceGrid.Cells.Cell(data.Rows[i - 1][5], typeof(DateTime)); //安排日期
                grid[i, 6] = new SourceGrid.Cells.Cell(data.Rows[i - 1][6], typeof(int));//维护天数
                grid[i, 7] = new SourceGrid.Cells.Cell(data.Rows[i - 1][7], typeof(string));//维护说明
                //grid[i, 8] = new SourceGrid.Cells.Cell(data.Rows[i - 1][8], typeof(int));//数量
                //grid[i, 9] = new SourceGrid.Cells.Cell(data.Rows[i - 1][9], typeof(DateTime));//销帐时间
                /*
                //将图片显示在单元格中
                imagebytes = (byte[])data.Rows[i - 1][3];
                MemoryStream ms = new MemoryStream(imagebytes);
                Image img = Image.FromStream(ms);
                //pb.Image = img;
                grid[i, 3] = new SourceGrid.Cells.Image(img);
                //grid[i, 3].AddController(new imageDoubleClickController()); //双击图片放大查看
                ms.Close();

                //设置obj浏览
                grid[i, 4] = new SourceGrid.Cells.Button("三维预览");
                //grid[i, 4].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                //grid[i, 4].AddController(new objButtonClickController()); //单击按钮事件 
               
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
                 *  */
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
            DialogResult dr;
            Boolean flag = false;
            //AccountEditForm acf = new AccountEditForm(id);
            try
            {
                if (grid1[grid1.Selection.ActivePosition.Row, 0] != null)
                {
                    dr = MessageBox.Show("您确认将编号为" + grid1[grid1.Selection.ActivePosition.Row, 1].ToString() + "的记录重新入账？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        Account acc = new Account();
                        flag = acc.reOffAccountById(id);
                        if (flag)
                        {
                            MessageBox.Show("重新入账成功！");
                            DataSet ds_account = acc.queryOffAccount();
                            BindSourceGrid(grid1, ds_account.Tables[0]);
                            grid1.Selection.SelectRow(1, true);
                            grid1.Selection.FocusFirstCell(true);
                        }
                        else
                        {
                            MessageBox.Show("重新入账失败！");
                        }
                    }
                    /*
                    Account acc = new Account();
                    DataSet ds_account = acc.queryAccount();
                    BindSourceGrid(grid1, ds_account.Tables[0]);
                    grid1.Selection.SelectRow(1, true);
                    grid1.Selection.FocusFirstCell(true);
                     * */
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
            //DataSet ds1 = null, ds2 = null;
            Account acc = new Account();
            //ds1 = acc.CreateDataSet_Department();
            //ds2 = acc.CreateDataSet_EquipmentType();

            DataSet ds_MaintainPlan = acc.queryMaintainPlanByDays(365);//查询365天到今天的维护计划信息
            //ds_report = ds_account;//公共DS，用于报表输出
            BindSourceGrid(grid1, ds_MaintainPlan.Tables[0]);

            grid1.Selection.SelectRow(1, true);
            grid1.Selection.FocusFirstCell(true);
        }



    }
}
