USE [cems]
GO
/****** Object:  Table [dbo].[department]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[departname] [nvarchar](50) NULL,
	[leader] [nvarchar](50) NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_DEPARTMENT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'department', @level2type=N'COLUMN',@level2name=N'departname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门负责人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'department', @level2type=N'COLUMN',@level2name=N'leader'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'department'
GO
/****** Object:  Table [dbo].[sys_sys]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_sys](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[realname] [nvarchar](50) NULL,
	[userright] [int] NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_SYS_SYS] PRIMARY KEY NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_sys', @level2type=N'COLUMN',@level2name=N'username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_sys', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_sys', @level2type=N'COLUMN',@level2name=N'realname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_sys', @level2type=N'COLUMN',@level2name=N'userright'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys_sys'
GO
/****** Object:  Table [dbo].[repair_plan]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[repair_plan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[plan_asset] [nvarchar](50) NULL,
	[eq_id] [int] NULL,
	[start_date] [datetime] NULL,
	[over_time] [int] NULL,
	[stop_time] [int] NULL,
	[target_department] [nvarchar](50) NULL,
	[source_department] [nvarchar](50) NULL,
	[principal] [nvarchar](50) NULL,
	[memo] [ntext] NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_REPAIR_PLAN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan', @level2type=N'COLUMN',@level2name=N'plan_asset'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan', @level2type=N'COLUMN',@level2name=N'eq_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修开始日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan', @level2type=N'COLUMN',@level2name=N'start_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修经历天数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan', @level2type=N'COLUMN',@level2name=N'over_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停机天数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan', @level2type=N'COLUMN',@level2name=N'stop_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标部门，被修理部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan', @level2type=N'COLUMN',@level2name=N'target_department'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan', @level2type=N'COLUMN',@level2name=N'source_department'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修负责人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan', @level2type=N'COLUMN',@level2name=N'principal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修计划备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan', @level2type=N'COLUMN',@level2name=N'memo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修计划' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair_plan'
GO
/****** Object:  Table [dbo].[repair]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[repair](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[repair_asset] [nvarchar](50) NULL,
	[eq_id] [int] NULL,
	[start_date] [datetime] NULL,
	[end_time] [datetime] NULL,
	[stop_time] [int] NULL,
	[target_department] [nvarchar](50) NULL,
	[source_department] [nvarchar](50) NULL,
	[principal] [nvarchar](50) NULL,
	[memo_before] [ntext] NULL,
	[memo_after] [ntext] NULL,
	[memo_record] [ntext] NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_REPAIR] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'repair_asset'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'eq_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修开始日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'start_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修结束日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'end_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停机天数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'stop_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标部门，被修理部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'target_department'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修理部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'source_department'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修负责人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'principal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修前设备状况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'memo_before'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修后设备状况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'memo_after'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修记录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'memo_record'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair'
GO
/****** Object:  Table [dbo].[part_account]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[part_account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[part_asset] [nvarchar](50) NULL,
	[part_name] [nvarchar](50) NULL,
	[material] [nvarchar](50) NULL,
	[part_weight] [nvarchar](50) NULL,
	[standard] [bit] NULL,
	[equipment] [nvarchar](100) NULL,
	[part_photo] [image] NULL,
	[part_3d] [image] NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_PART_ACCOUNT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'零件编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'part_account', @level2type=N'COLUMN',@level2name=N'part_asset'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'零件名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'part_account', @level2type=N'COLUMN',@level2name=N'part_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造材料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'part_account', @level2type=N'COLUMN',@level2name=N'material'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否标准件：1是 2否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'part_account', @level2type=N'COLUMN',@level2name=N'standard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用到本零件的设备，用分号隔开，如：2;4;5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'part_account', @level2type=N'COLUMN',@level2name=N'equipment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'零件图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'part_account', @level2type=N'COLUMN',@level2name=N'part_photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'零件3d图形文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'part_account', @level2type=N'COLUMN',@level2name=N'part_3d'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配件台帐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'part_account'
GO
/****** Object:  Table [dbo].[maintain_plan]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[maintain_plan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[plan_asset] [nvarchar](50) NULL,
	[eq_id] [int] NULL,
	[start_date] [datetime] NULL,
	[over_time] [int] NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_MAINTAIN_PLAN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain_plan', @level2type=N'COLUMN',@level2name=N'plan_asset'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain_plan', @level2type=N'COLUMN',@level2name=N'eq_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安排日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain_plan', @level2type=N'COLUMN',@level2name=N'start_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护周期天数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain_plan', @level2type=N'COLUMN',@level2name=N'over_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护计划表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain_plan'
GO
/****** Object:  Table [dbo].[maintain_level]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[maintain_level](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[level_name] [nvarchar](50) NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_MAINTAIN_LEVEL] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保养等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain_level', @level2type=N'COLUMN',@level2name=N'level_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保养等级表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain_level'
GO
/****** Object:  Table [dbo].[maintain]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[maintain](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[eq_id] [int] NULL,
	[principal] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL,
	[memo] [ntext] NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_MAINTAIN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护开始日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain', @level2type=N'COLUMN',@level2name=N'start_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护结束日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain', @level2type=N'COLUMN',@level2name=N'end_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain', @level2type=N'COLUMN',@level2name=N'eq_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维护责任人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain', @level2type=N'COLUMN',@level2name=N'principal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备状况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维修维护记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'maintain'
GO
/****** Object:  Table [dbo].[fault_knowledge]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fault_knowledge](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[part_name] [nvarchar](50) NULL,
	[phenomenon] [ntext] NULL,
	[reason] [ntext] NULL,
	[solve] [ntext] NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_FAULT_KNOWLEDGE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'零件名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault_knowledge', @level2type=N'COLUMN',@level2name=N'part_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'故障现象' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault_knowledge', @level2type=N'COLUMN',@level2name=N'phenomenon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'故障原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault_knowledge', @level2type=N'COLUMN',@level2name=N'reason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'解决方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault_knowledge', @level2type=N'COLUMN',@level2name=N'solve'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'故障知识库表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault_knowledge'
GO
/****** Object:  Table [dbo].[fault]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fault](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[eq_id] [int] NULL,
	[fault_date] [datetime] NULL,
	[repair_date] [datetime] NULL,
	[fault_process] [ntext] NULL,
	[fault_reason] [ntext] NULL,
	[fault_lose] [ntext] NULL,
	[Countermeasure] [ntext] NULL,
	[fault_photo] [image] NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_FAULT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault', @level2type=N'COLUMN',@level2name=N'eq_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故发生时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault', @level2type=N'COLUMN',@level2name=N'fault_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修复时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault', @level2type=N'COLUMN',@level2name=N'repair_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故经过描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault', @level2type=N'COLUMN',@level2name=N'fault_process'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故原因描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault', @level2type=N'COLUMN',@level2name=N'fault_reason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故损失描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault', @level2type=N'COLUMN',@level2name=N'fault_lose'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对策措施描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault', @level2type=N'COLUMN',@level2name=N'Countermeasure'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事故现场照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault', @level2type=N'COLUMN',@level2name=N'fault_photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'故障表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fault'
GO
/****** Object:  Table [dbo].[eq_writeoff]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eq_writeoff](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[eq_id] [int] NULL,
	[off_date] [datetime] NULL,
	[off_type] [nvarchar](50) NULL,
	[off_value] [float] NULL,
	[off_memo] [ntext] NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_EQ_WRITEOFF] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销帐设备ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_writeoff', @level2type=N'COLUMN',@level2name=N'eq_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销帐时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_writeoff', @level2type=N'COLUMN',@level2name=N'off_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销帐类型：报废、丢失、变卖、捐赠、其它' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_writeoff', @level2type=N'COLUMN',@level2name=N'off_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折合价值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_writeoff', @level2type=N'COLUMN',@level2name=N'off_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销帐备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_writeoff', @level2type=N'COLUMN',@level2name=N'off_memo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备销帐记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_writeoff'
GO
/****** Object:  Table [dbo].[eq_type]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eq_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nvarchar](50) NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_EQ_TYPE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备类型名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_type', @level2type=N'COLUMN',@level2name=N'type_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备类型表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_type'
GO
/****** Object:  Table [dbo].[eq_status]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eq_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status_name] [nvarchar](50) NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_EQ_STATUS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备状态名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_status', @level2type=N'COLUMN',@level2name=N'status_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备状态表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_status'
GO
/****** Object:  Table [dbo].[eq_account]    Script Date: 06/15/2013 01:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eq_account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isoff] [bit] NULL,
	[asset] [nvarchar](50) NULL,
	[eqname] [nvarchar](50) NULL,
	[model] [nvarchar](50) NULL,
	[specification] [nvarchar](50) NULL,
	[department] [int] NULL,
	[weight] [nvarchar](50) NULL,
	[brand] [nvarchar](50) NULL,
	[manufacturer] [nvarchar](50) NULL,
	[supplier] [nvarchar](50) NULL,
	[manu_date] [datetime] NULL,
	[produ_date] [datetime] NULL,
	[filing_date] [datetime] NULL,
	[value] [float] NULL,
	[count] [int] NULL,
	[electromotor] [int] NULL,
	[power] [float] NULL,
	[status] [int] NULL,
	[type] [int] NULL,
	[address] [nvarchar](50) NULL,
	[photo] [image] NULL,
	[three_dimensional] [image] NULL,
	[parts] [nvarchar](100) NULL,
	[ts] [datetime] NULL,
	[dr] [tinyint] NULL,
 CONSTRAINT [PK_EQ_ACCOUNT] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已销帐：1已销帐；0未销帐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'isoff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资产编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'asset'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'eqname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'model'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'specification'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'department'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备重量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'weight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备品牌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'brand'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'manufacturer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'supplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'manu_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投产年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'produ_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建档日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'filing_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备原值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电机数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'electromotor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总功率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'power'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备分类、设备类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安装地点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备三维图文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'three_dimensional'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所用零件。以分号隔开，如：1;3;6(本字段暂封存不用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account', @level2type=N'COLUMN',@level2name=N'parts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备台帐表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'eq_account'
GO
/****** Object:  Default [DF_department_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[department] ADD  CONSTRAINT [DF_department_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_department_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[department] ADD  CONSTRAINT [DF_department_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_sys_sys_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[sys_sys] ADD  CONSTRAINT [DF_sys_sys_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_sys_sys_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[sys_sys] ADD  CONSTRAINT [DF_sys_sys_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_repair_plan_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[repair_plan] ADD  CONSTRAINT [DF_repair_plan_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_repair_plan_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[repair_plan] ADD  CONSTRAINT [DF_repair_plan_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_repair_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[repair] ADD  CONSTRAINT [DF_repair_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_repair_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[repair] ADD  CONSTRAINT [DF_repair_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_part_account_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[part_account] ADD  CONSTRAINT [DF_part_account_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_part_account_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[part_account] ADD  CONSTRAINT [DF_part_account_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_maintain_plan_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[maintain_plan] ADD  CONSTRAINT [DF_maintain_plan_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_maintain_plan_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[maintain_plan] ADD  CONSTRAINT [DF_maintain_plan_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_maintain_level_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[maintain_level] ADD  CONSTRAINT [DF_maintain_level_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_maintain_level_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[maintain_level] ADD  CONSTRAINT [DF_maintain_level_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_maintain_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[maintain] ADD  CONSTRAINT [DF_maintain_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_maintain_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[maintain] ADD  CONSTRAINT [DF_maintain_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_fault_knowledge_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[fault_knowledge] ADD  CONSTRAINT [DF_fault_knowledge_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_fault_knowledge_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[fault_knowledge] ADD  CONSTRAINT [DF_fault_knowledge_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_fault_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[fault] ADD  CONSTRAINT [DF_fault_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_fault_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[fault] ADD  CONSTRAINT [DF_fault_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_eq_writeoff_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_writeoff] ADD  CONSTRAINT [DF_eq_writeoff_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_eq_writeoff_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_writeoff] ADD  CONSTRAINT [DF_eq_writeoff_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_eq_type_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_type] ADD  CONSTRAINT [DF_eq_type_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_eq_type_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_type] ADD  CONSTRAINT [DF_eq_type_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_eq_status_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_status] ADD  CONSTRAINT [DF_eq_status_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_eq_status_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_status] ADD  CONSTRAINT [DF_eq_status_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  Default [DF_eq_account_ts]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_account] ADD  CONSTRAINT [DF_eq_account_ts]  DEFAULT (getdate()) FOR [ts]
GO
/****** Object:  Default [DF_eq_account_dr]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_account] ADD  CONSTRAINT [DF_eq_account_dr]  DEFAULT ((0)) FOR [dr]
GO
/****** Object:  ForeignKey [FK_EQ_ACCOU_REFERENCE_DEPARTME]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_account]  WITH CHECK ADD  CONSTRAINT [FK_EQ_ACCOU_REFERENCE_DEPARTME] FOREIGN KEY([department])
REFERENCES [dbo].[department] ([id])
GO
ALTER TABLE [dbo].[eq_account] CHECK CONSTRAINT [FK_EQ_ACCOU_REFERENCE_DEPARTME]
GO
/****** Object:  ForeignKey [FK_EQ_ACCOU_REFERENCE_EQ_STATU]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_account]  WITH CHECK ADD  CONSTRAINT [FK_EQ_ACCOU_REFERENCE_EQ_STATU] FOREIGN KEY([status])
REFERENCES [dbo].[eq_status] ([id])
GO
ALTER TABLE [dbo].[eq_account] CHECK CONSTRAINT [FK_EQ_ACCOU_REFERENCE_EQ_STATU]
GO
/****** Object:  ForeignKey [FK_EQ_ACCOU_REFERENCE_EQ_TYPE]    Script Date: 06/15/2013 01:03:08 ******/
ALTER TABLE [dbo].[eq_account]  WITH CHECK ADD  CONSTRAINT [FK_EQ_ACCOU_REFERENCE_EQ_TYPE] FOREIGN KEY([type])
REFERENCES [dbo].[eq_type] ([id])
GO
ALTER TABLE [dbo].[eq_account] CHECK CONSTRAINT [FK_EQ_ACCOU_REFERENCE_EQ_TYPE]
GO
