﻿namespace CEMSApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.设备信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eqAccountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peijianguanli = new System.Windows.Forms.ToolStripMenuItem();
            this.OffAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.数据导入导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配件数据导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.维护信息管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.weihujihua = new System.Windows.Forms.ToolStripMenuItem();
            this.weihujilu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.点检管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点检记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.维修信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weixiujihua = new System.Windows.Forms.ToolStripMenuItem();
            this.weixiujilu = new System.Windows.Forms.ToolStripMenuItem();
            this.故障管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_fault = new System.Windows.Forms.ToolStripMenuItem();
            this.故障统计分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.guzhangzhishiku = new System.Windows.Forms.ToolStripMenuItem();
            this.shiguguanli = new System.Windows.Forms.ToolStripMenuItem();
            this.canshushezhi = new System.Windows.Forms.ToolStripMenuItem();
            this.bumenguanli = new System.Windows.Forms.ToolStripMenuItem();
            this.shebeileixing = new System.Windows.Forms.ToolStripMenuItem();
            this.shebeizhuangtai = new System.Windows.Forms.ToolStripMenuItem();
            this.guzhangmoshi = new System.Windows.Forms.ToolStripMenuItem();
            this.weixiudengji = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SystemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.xiugaimima = new System.Windows.Forms.ToolStripMenuItem();
            this.yonghuguanli = new System.Windows.Forms.ToolStripMenuItem();
            this.shujukushezhi = new System.Windows.Forms.ToolStripMenuItem();
            this.shujukubeifen = new System.Windows.Forms.ToolStripMenuItem();
            this.shujukuhuifu = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_peijianguanli = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_maintainplan = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_repair = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_fault = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_trouble = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.systemTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.usernameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.userrightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备信息管理ToolStripMenuItem,
            this.维护信息管理ToolStripMenuItem1,
            this.维修信息管理ToolStripMenuItem,
            this.故障管理ToolStripMenuItem,
            this.shiguguanli,
            this.canshushezhi,
            this.ToolStripMenuItem_SystemManage,
            this.帮助ToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(779, 25);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            this.MainMenu.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.MainMenu_ItemAdded);
            // 
            // 设备信息管理ToolStripMenuItem
            // 
            this.设备信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eqAccountMenuItem,
            this.peijianguanli,
            this.OffAccountToolStripMenuItem,
            this.toolStripSeparator4,
            this.数据导入导出ToolStripMenuItem});
            this.设备信息管理ToolStripMenuItem.Name = "设备信息管理ToolStripMenuItem";
            this.设备信息管理ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.设备信息管理ToolStripMenuItem.Text = "设备台帐管理";
            // 
            // eqAccountMenuItem
            // 
            this.eqAccountMenuItem.Name = "eqAccountMenuItem";
            this.eqAccountMenuItem.Size = new System.Drawing.Size(148, 22);
            this.eqAccountMenuItem.Text = "设备台帐";
            this.eqAccountMenuItem.Click += new System.EventHandler(this.eqAccountMenuItem_Click);
            // 
            // peijianguanli
            // 
            this.peijianguanli.Name = "peijianguanli";
            this.peijianguanli.Size = new System.Drawing.Size(148, 22);
            this.peijianguanli.Text = "配件管理";
            this.peijianguanli.Click += new System.EventHandler(this.peijianguanli_Click);
            // 
            // OffAccountToolStripMenuItem
            // 
            this.OffAccountToolStripMenuItem.Name = "OffAccountToolStripMenuItem";
            this.OffAccountToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.OffAccountToolStripMenuItem.Text = "销帐登记";
            this.OffAccountToolStripMenuItem.Click += new System.EventHandler(this.OffAccountToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // 数据导入导出ToolStripMenuItem
            // 
            this.数据导入导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据导入ToolStripMenuItem,
            this.配件数据导入ToolStripMenuItem,
            this.数据导出ToolStripMenuItem});
            this.数据导入导出ToolStripMenuItem.Name = "数据导入导出ToolStripMenuItem";
            this.数据导入导出ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.数据导入导出ToolStripMenuItem.Text = "数据导入导出";
            // 
            // 数据导入ToolStripMenuItem
            // 
            this.数据导入ToolStripMenuItem.Name = "数据导入ToolStripMenuItem";
            this.数据导入ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.数据导入ToolStripMenuItem.Text = "设备数据导入";
            // 
            // 配件数据导入ToolStripMenuItem
            // 
            this.配件数据导入ToolStripMenuItem.Name = "配件数据导入ToolStripMenuItem";
            this.配件数据导入ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.配件数据导入ToolStripMenuItem.Text = "配件数据导入";
            // 
            // 数据导出ToolStripMenuItem
            // 
            this.数据导出ToolStripMenuItem.Name = "数据导出ToolStripMenuItem";
            this.数据导出ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.数据导出ToolStripMenuItem.Text = "数据导出";
            // 
            // 维护信息管理ToolStripMenuItem1
            // 
            this.维护信息管理ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weihujihua,
            this.weihujilu,
            this.toolStripSeparator7,
            this.点检管理ToolStripMenuItem,
            this.点检记录ToolStripMenuItem});
            this.维护信息管理ToolStripMenuItem1.Name = "维护信息管理ToolStripMenuItem1";
            this.维护信息管理ToolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.维护信息管理ToolStripMenuItem1.Text = "维护管理";
            // 
            // weihujihua
            // 
            this.weihujihua.Name = "weihujihua";
            this.weihujihua.Size = new System.Drawing.Size(148, 22);
            this.weihujihua.Text = "维护计划";
            this.weihujihua.Click += new System.EventHandler(this.weihujihua_Click);
            // 
            // weihujilu
            // 
            this.weihujilu.Name = "weihujilu";
            this.weihujilu.Size = new System.Drawing.Size(148, 22);
            this.weihujilu.Text = "维护记录管理";
            this.weihujilu.Click += new System.EventHandler(this.weihujilu_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(145, 6);
            // 
            // 点检管理ToolStripMenuItem
            // 
            this.点检管理ToolStripMenuItem.Name = "点检管理ToolStripMenuItem";
            this.点检管理ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.点检管理ToolStripMenuItem.Text = "点检管理";
            // 
            // 点检记录ToolStripMenuItem
            // 
            this.点检记录ToolStripMenuItem.Name = "点检记录ToolStripMenuItem";
            this.点检记录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.点检记录ToolStripMenuItem.Text = "点检记录";
            // 
            // 维修信息管理ToolStripMenuItem
            // 
            this.维修信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weixiujihua,
            this.weixiujilu});
            this.维修信息管理ToolStripMenuItem.Name = "维修信息管理ToolStripMenuItem";
            this.维修信息管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.维修信息管理ToolStripMenuItem.Text = "维修管理";
            // 
            // weixiujihua
            // 
            this.weixiujihua.Name = "weixiujihua";
            this.weixiujihua.Size = new System.Drawing.Size(148, 22);
            this.weixiujihua.Text = "维修计划";
            this.weixiujihua.Click += new System.EventHandler(this.weixiujihua_Click);
            // 
            // weixiujilu
            // 
            this.weixiujilu.Name = "weixiujilu";
            this.weixiujilu.Size = new System.Drawing.Size(148, 22);
            this.weixiujilu.Text = "维修记录管理";
            this.weixiujilu.Click += new System.EventHandler(this.weixiujilu_Click);
            // 
            // 故障管理ToolStripMenuItem
            // 
            this.故障管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_fault,
            this.故障统计分析ToolStripMenuItem,
            this.toolStripSeparator5,
            this.guzhangzhishiku});
            this.故障管理ToolStripMenuItem.Name = "故障管理ToolStripMenuItem";
            this.故障管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.故障管理ToolStripMenuItem.Text = "故障管理";
            // 
            // ToolStripMenuItem_fault
            // 
            this.ToolStripMenuItem_fault.Name = "ToolStripMenuItem_fault";
            this.ToolStripMenuItem_fault.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_fault.Text = "故障记录管理";
            this.ToolStripMenuItem_fault.Click += new System.EventHandler(this.ToolStripMenuItem_fault_Click);
            // 
            // 故障统计分析ToolStripMenuItem
            // 
            this.故障统计分析ToolStripMenuItem.Name = "故障统计分析ToolStripMenuItem";
            this.故障统计分析ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.故障统计分析ToolStripMenuItem.Text = "故障统计分析";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // guzhangzhishiku
            // 
            this.guzhangzhishiku.Name = "guzhangzhishiku";
            this.guzhangzhishiku.Size = new System.Drawing.Size(148, 22);
            this.guzhangzhishiku.Text = "故障知识库";
            this.guzhangzhishiku.Click += new System.EventHandler(this.guzhangzhishiku_Click);
            // 
            // shiguguanli
            // 
            this.shiguguanli.Name = "shiguguanli";
            this.shiguguanli.Size = new System.Drawing.Size(68, 21);
            this.shiguguanli.Text = "事故管理";
            this.shiguguanli.Click += new System.EventHandler(this.shiguguanli_Click);
            // 
            // canshushezhi
            // 
            this.canshushezhi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bumenguanli,
            this.shebeileixing,
            this.shebeizhuangtai,
            this.guzhangmoshi,
            this.weixiudengji});
            this.canshushezhi.Name = "canshushezhi";
            this.canshushezhi.Size = new System.Drawing.Size(68, 21);
            this.canshushezhi.Text = "参数设置";
            // 
            // bumenguanli
            // 
            this.bumenguanli.Name = "bumenguanli";
            this.bumenguanli.Size = new System.Drawing.Size(148, 22);
            this.bumenguanli.Text = "部门管理";
            this.bumenguanli.Click += new System.EventHandler(this.bumenguanli_Click);
            // 
            // shebeileixing
            // 
            this.shebeileixing.Name = "shebeileixing";
            this.shebeileixing.Size = new System.Drawing.Size(148, 22);
            this.shebeileixing.Text = "设备类型管理";
            this.shebeileixing.Click += new System.EventHandler(this.shebeileixing_Click);
            // 
            // shebeizhuangtai
            // 
            this.shebeizhuangtai.Name = "shebeizhuangtai";
            this.shebeizhuangtai.Size = new System.Drawing.Size(148, 22);
            this.shebeizhuangtai.Text = "设备状态管理";
            this.shebeizhuangtai.Click += new System.EventHandler(this.shebeizhuangtai_Click);
            // 
            // guzhangmoshi
            // 
            this.guzhangmoshi.Name = "guzhangmoshi";
            this.guzhangmoshi.Size = new System.Drawing.Size(148, 22);
            this.guzhangmoshi.Text = "故障模式管理";
            this.guzhangmoshi.Click += new System.EventHandler(this.guzhangmoshi_Click);
            // 
            // weixiudengji
            // 
            this.weixiudengji.Name = "weixiudengji";
            this.weixiudengji.Size = new System.Drawing.Size(148, 22);
            this.weixiudengji.Text = "维修等级管理";
            this.weixiudengji.Click += new System.EventHandler(this.weixiudengji_Click);
            // 
            // ToolStripMenuItem_SystemManage
            // 
            this.ToolStripMenuItem_SystemManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xiugaimima,
            this.yonghuguanli,
            this.shujukushezhi});
            this.ToolStripMenuItem_SystemManage.Name = "ToolStripMenuItem_SystemManage";
            this.ToolStripMenuItem_SystemManage.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItem_SystemManage.Text = "系统管理";
            // 
            // xiugaimima
            // 
            this.xiugaimima.Name = "xiugaimima";
            this.xiugaimima.Size = new System.Drawing.Size(152, 22);
            this.xiugaimima.Text = "修改密码";
            this.xiugaimima.Click += new System.EventHandler(this.xiugaimima_Click);
            // 
            // yonghuguanli
            // 
            this.yonghuguanli.Name = "yonghuguanli";
            this.yonghuguanli.Size = new System.Drawing.Size(152, 22);
            this.yonghuguanli.Text = "用户管理";
            this.yonghuguanli.Click += new System.EventHandler(this.yonghuguanli_Click);
            // 
            // shujukushezhi
            // 
            this.shujukushezhi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shujukubeifen,
            this.shujukuhuifu});
            this.shujukushezhi.Name = "shujukushezhi";
            this.shujukushezhi.Size = new System.Drawing.Size(152, 22);
            this.shujukushezhi.Text = "数据库设置";
            // 
            // shujukubeifen
            // 
            this.shujukubeifen.Name = "shujukubeifen";
            this.shujukubeifen.Size = new System.Drawing.Size(152, 22);
            this.shujukubeifen.Text = "数据库备份";
            this.shujukubeifen.Click += new System.EventHandler(this.shujukubeifen_Click);
            // 
            // shujukuhuifu
            // 
            this.shujukuhuifu.Name = "shujukuhuifu";
            this.shujukuhuifu.Size = new System.Drawing.Size(152, 22);
            this.shujukuhuifu.Text = "数据库恢复";
            this.shujukuhuifu.Click += new System.EventHandler(this.shujukuhuifu_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton_peijianguanli,
            this.toolStripSeparator8,
            this.toolStripButton_maintainplan,
            this.toolStrip_repair,
            this.toolStripButton_fault,
            this.toolStripButton_trouble,
            this.toolStripSeparator1,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(779, 56);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::CEMSApp.Properties.Resources.table_multiple;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 53);
            this.toolStripButton1.Text = "设备台帐";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton_peijianguanli
            // 
            this.toolStripButton_peijianguanli.Image = global::CEMSApp.Properties.Resources.plugin_edit;
            this.toolStripButton_peijianguanli.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_peijianguanli.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_peijianguanli.Name = "toolStripButton_peijianguanli";
            this.toolStripButton_peijianguanli.Size = new System.Drawing.Size(60, 53);
            this.toolStripButton_peijianguanli.Text = "配件管理";
            this.toolStripButton_peijianguanli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_peijianguanli.Click += new System.EventHandler(this.toolStripButton_peijianguanli_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 56);
            // 
            // toolStripButton_maintainplan
            // 
            this.toolStripButton_maintainplan.Image = global::CEMSApp.Properties.Resources.cog_edit;
            this.toolStripButton_maintainplan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_maintainplan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_maintainplan.Name = "toolStripButton_maintainplan";
            this.toolStripButton_maintainplan.Size = new System.Drawing.Size(84, 53);
            this.toolStripButton_maintainplan.Text = "维护记录管理";
            this.toolStripButton_maintainplan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_maintainplan.Click += new System.EventHandler(this.toolStripButton_maintainplan_Click);
            // 
            // toolStrip_repair
            // 
            this.toolStrip_repair.Image = global::CEMSApp.Properties.Resources.settings;
            this.toolStrip_repair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStrip_repair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_repair.Name = "toolStrip_repair";
            this.toolStrip_repair.Size = new System.Drawing.Size(84, 53);
            this.toolStrip_repair.Text = "维修记录管理";
            this.toolStrip_repair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStrip_repair.Click += new System.EventHandler(this.toolStrip_repair_Click);
            // 
            // toolStripButton_fault
            // 
            this.toolStripButton_fault.Image = global::CEMSApp.Properties.Resources.link_break;
            this.toolStripButton_fault.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_fault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_fault.Name = "toolStripButton_fault";
            this.toolStripButton_fault.Size = new System.Drawing.Size(84, 53);
            this.toolStripButton_fault.Text = "故障记录管理";
            this.toolStripButton_fault.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_fault.Click += new System.EventHandler(this.toolStripButton_fault_Click);
            // 
            // toolStripButton_trouble
            // 
            this.toolStripButton_trouble.Image = global::CEMSApp.Properties.Resources.exclamation;
            this.toolStripButton_trouble.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_trouble.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_trouble.Name = "toolStripButton_trouble";
            this.toolStripButton_trouble.Size = new System.Drawing.Size(84, 53);
            this.toolStripButton_trouble.Text = "事故记录管理";
            this.toolStripButton_trouble.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_trouble.Click += new System.EventHandler(this.toolStripButton_trouble_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::CEMSApp.Properties.Resources.door_in;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(60, 53);
            this.toolStripButton4.Text = "退出系统";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemTime,
            this.toolStripSeparator2,
            this.usernameLabel,
            this.toolStripSeparator3,
            this.userrightLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(779, 23);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // systemTime
            // 
            this.systemTime.Name = "systemTime";
            this.systemTime.Size = new System.Drawing.Size(68, 18);
            this.systemTime.Text = "系统时间：";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(68, 18);
            this.usernameLabel.Text = "当前用户：";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // userrightLabel
            // 
            this.userrightLabel.Name = "userrightLabel";
            this.userrightLabel.Size = new System.Drawing.Size(68, 18);
            this.userrightLabel.Text = "用户角色：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CEMSApp.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(779, 542);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "化工企业设备维护维修管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem 设备信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 维护信息管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 维修信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 故障管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SystemManage;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton_maintainplan;
        private System.Windows.Forms.ToolStripButton toolStripButton_fault;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel systemTime;
        private System.Windows.Forms.ToolStripStatusLabel usernameLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel userrightLabel;
        private System.Windows.Forms.ToolStripMenuItem eqAccountMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peijianguanli;
        private System.Windows.Forms.ToolStripMenuItem OffAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 数据导入导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配件数据导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canshushezhi;
        private System.Windows.Forms.ToolStripMenuItem 点检管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weixiujilu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_fault;
        private System.Windows.Forms.ToolStripMenuItem 故障统计分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem guzhangzhishiku;
        private System.Windows.Forms.ToolStripMenuItem bumenguanli;
        private System.Windows.Forms.ToolStripMenuItem shebeileixing;
        private System.Windows.Forms.ToolStripMenuItem shebeizhuangtai;
        private System.Windows.Forms.ToolStripMenuItem guzhangmoshi;
        private System.Windows.Forms.ToolStripMenuItem yonghuguanli;
        private System.Windows.Forms.ToolStripMenuItem shujukushezhi;
        private System.Windows.Forms.ToolStripMenuItem shujukubeifen;
        private System.Windows.Forms.ToolStripMenuItem shujukuhuifu;
        private System.Windows.Forms.ToolStripButton toolStrip_repair;
        private System.Windows.Forms.ToolStripMenuItem weihujilu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem 点检记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_peijianguanli;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem weihujihua;
        private System.Windows.Forms.ToolStripMenuItem weixiujihua;
        private System.Windows.Forms.ToolStripButton toolStripButton_trouble;
        private System.Windows.Forms.ToolStripMenuItem shiguguanli;
        private System.Windows.Forms.ToolStripMenuItem weixiudengji;
        private System.Windows.Forms.ToolStripMenuItem xiugaimima;

    }
}

