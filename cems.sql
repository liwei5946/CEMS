/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2013-3-19 16:41:25                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('eq_account') and o.name = 'FK_EQ_ACCOU_REFERENCE_EQ_STATU')
alter table eq_account
   drop constraint FK_EQ_ACCOU_REFERENCE_EQ_STATU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('eq_account') and o.name = 'FK_EQ_ACCOU_REFERENCE_EQ_TYPE')
alter table eq_account
   drop constraint FK_EQ_ACCOU_REFERENCE_EQ_TYPE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('eq_account') and o.name = 'FK_EQ_ACCOU_REFERENCE_DEPARTME')
alter table eq_account
   drop constraint FK_EQ_ACCOU_REFERENCE_DEPARTME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('department')
            and   type = 'U')
   drop table department
go

if exists (select 1
            from  sysobjects
           where  id = object_id('eq_account')
            and   type = 'U')
   drop table eq_account
go

if exists (select 1
            from  sysobjects
           where  id = object_id('eq_status')
            and   type = 'U')
   drop table eq_status
go

if exists (select 1
            from  sysobjects
           where  id = object_id('eq_type')
            and   type = 'U')
   drop table eq_type
go

if exists (select 1
            from  sysobjects
           where  id = object_id('eq_writeoff')
            and   type = 'U')
   drop table eq_writeoff
go

if exists (select 1
            from  sysobjects
           where  id = object_id('fault')
            and   type = 'U')
   drop table fault
go

if exists (select 1
            from  sysobjects
           where  id = object_id('fault_knowledge')
            and   type = 'U')
   drop table fault_knowledge
go

if exists (select 1
            from  sysobjects
           where  id = object_id('maintain')
            and   type = 'U')
   drop table maintain
go

if exists (select 1
            from  sysobjects
           where  id = object_id('maintain_level')
            and   type = 'U')
   drop table maintain_level
go

if exists (select 1
            from  sysobjects
           where  id = object_id('maintain_plan')
            and   type = 'U')
   drop table maintain_plan
go

if exists (select 1
            from  sysobjects
           where  id = object_id('part_account')
            and   type = 'U')
   drop table part_account
go

if exists (select 1
            from  sysobjects
           where  id = object_id('repair')
            and   type = 'U')
   drop table repair
go

if exists (select 1
            from  sysobjects
           where  id = object_id('repair_plan')
            and   type = 'U')
   drop table repair_plan
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sys_sys')
            and   type = 'U')
   drop table sys_sys
go

/*==============================================================*/
/* Table: department                                            */
/*==============================================================*/
create table department (
   id                   int                  identity,
   departname           nvarchar(50)         null,
   leader               nvarchar(50)         null,
   constraint PK_DEPARTMENT primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '部门表',
   'user', @CurrentUser, 'table', 'department'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '部门名称',
   'user', @CurrentUser, 'table', 'department', 'column', 'departname'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '部门负责人',
   'user', @CurrentUser, 'table', 'department', 'column', 'leader'
go

/*==============================================================*/
/* Table: eq_account                                            */
/*==============================================================*/
create table eq_account (
   id                   int                  identity,
   isoff                bit                  null,
   asset                nvarchar(50)         null,
   eqname               nvarchar(50)         null,
   model                nvarchar(50)         null,
   specification        nvarchar(50)         null,
   department           int                  null,
   weight               nvarchar(50)         null,
   brand                nvarchar(50)         null,
   manufacturer         nvarchar(50)         null,
   supplier             nvarchar(50)         null,
   manu_date            datetime             null,
   produ_date           datetime             null,
   filing_date          datetime             null,
   value                float                null,
   count                int                  null,
   electromotor         int                  null,
   power                float                null,
   status               int                  null,
   type                 int                  null,
   address              nvarchar(50)         null,
   photo                image                null,
   three_dimensional    image                null,
   parts                nvarchar(100)        null,
   constraint PK_EQ_ACCOUNT primary key nonclustered (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备台帐表',
   'user', @CurrentUser, 'table', 'eq_account'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已销帐：1已销帐；0未销帐',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'isoff'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资产编号',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'asset'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备名称',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'eqname'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备型号',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'model'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备规格',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'specification'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '部门ID',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'department'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备重量',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'weight'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备品牌',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'brand'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '制造商',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'manufacturer'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '供应商',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'supplier'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '制造年月',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'manu_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '投产年月',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'produ_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '建档日期',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'filing_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备原值',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'value'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备数量',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'count'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '电机数量',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'electromotor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '总功率',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'power'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备状态',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备分类、设备类型',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'type'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '安装地点',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'address'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备图片',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'photo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备三维图文件',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'three_dimensional'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所用零件。以分号隔开，如：1;3;6(本字段暂封存不用)',
   'user', @CurrentUser, 'table', 'eq_account', 'column', 'parts'
go

/*==============================================================*/
/* Table: eq_status                                             */
/*==============================================================*/
create table eq_status (
   id                   int                  identity,
   status_name          nvarchar(50)         null,
   constraint PK_EQ_STATUS primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备状态表',
   'user', @CurrentUser, 'table', 'eq_status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备状态名称',
   'user', @CurrentUser, 'table', 'eq_status', 'column', 'status_name'
go

/*==============================================================*/
/* Table: eq_type                                               */
/*==============================================================*/
create table eq_type (
   id                   int                  identity,
   type_name            nvarchar(50)         null,
   constraint PK_EQ_TYPE primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备类型表',
   'user', @CurrentUser, 'table', 'eq_type'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备类型名称',
   'user', @CurrentUser, 'table', 'eq_type', 'column', 'type_name'
go

/*==============================================================*/
/* Table: eq_writeoff                                           */
/*==============================================================*/
create table eq_writeoff (
   id                   int                  identity,
   eq_id                int                  null,
   off_date             datetime             null,
   off_type             nvarchar(50)         null,
   off_value            float                null,
   off_memo             ntext                null,
   constraint PK_EQ_WRITEOFF primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备销帐记录表',
   'user', @CurrentUser, 'table', 'eq_writeoff'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '销帐设备ID',
   'user', @CurrentUser, 'table', 'eq_writeoff', 'column', 'eq_id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '销帐时间',
   'user', @CurrentUser, 'table', 'eq_writeoff', 'column', 'off_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '销帐类型：报废、丢失、变卖、捐赠、其它',
   'user', @CurrentUser, 'table', 'eq_writeoff', 'column', 'off_type'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '折合价值',
   'user', @CurrentUser, 'table', 'eq_writeoff', 'column', 'off_value'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '销帐备注',
   'user', @CurrentUser, 'table', 'eq_writeoff', 'column', 'off_memo'
go

/*==============================================================*/
/* Table: fault                                                 */
/*==============================================================*/
create table fault (
   id                   int                  identity,
   eq_id                int                  null,
   fault_date           datetime             null,
   repair_date          datetime             null,
   fault_process        ntext                null,
   fault_reason         ntext                null,
   fault_lose           ntext                null,
   Countermeasure       ntext                null,
   fault_photo          image                null,
   constraint PK_FAULT primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '故障表',
   'user', @CurrentUser, 'table', 'fault'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', @CurrentUser, 'table', 'fault', 'column', 'eq_id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '事故发生时间',
   'user', @CurrentUser, 'table', 'fault', 'column', 'fault_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修复时间',
   'user', @CurrentUser, 'table', 'fault', 'column', 'repair_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '事故经过描述',
   'user', @CurrentUser, 'table', 'fault', 'column', 'fault_process'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '事故原因描述',
   'user', @CurrentUser, 'table', 'fault', 'column', 'fault_reason'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '事故损失描述',
   'user', @CurrentUser, 'table', 'fault', 'column', 'fault_lose'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '对策措施描述',
   'user', @CurrentUser, 'table', 'fault', 'column', 'Countermeasure'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '事故现场照片',
   'user', @CurrentUser, 'table', 'fault', 'column', 'fault_photo'
go

/*==============================================================*/
/* Table: fault_knowledge                                       */
/*==============================================================*/
create table fault_knowledge (
   id                   int                  identity,
   part_name            nvarchar(50)         null,
   phenomenon           ntext                null,
   reason               ntext                null,
   solve                ntext                null,
   constraint PK_FAULT_KNOWLEDGE primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '故障知识库表',
   'user', @CurrentUser, 'table', 'fault_knowledge'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '零件名称',
   'user', @CurrentUser, 'table', 'fault_knowledge', 'column', 'part_name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '故障现象',
   'user', @CurrentUser, 'table', 'fault_knowledge', 'column', 'phenomenon'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '故障原因',
   'user', @CurrentUser, 'table', 'fault_knowledge', 'column', 'reason'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '解决方法',
   'user', @CurrentUser, 'table', 'fault_knowledge', 'column', 'solve'
go

/*==============================================================*/
/* Table: maintain                                              */
/*==============================================================*/
create table maintain (
   id                   int                  identity,
   start_date           datetime             null,
   end_date             datetime             null,
   eq_id                int                  null,
   principal            nvarchar(50)         null,
   status               nvarchar(50)         null,
   memo                 ntext                null,
   constraint PK_MAINTAIN primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修维护记录表',
   'user', @CurrentUser, 'table', 'maintain'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维护开始日期',
   'user', @CurrentUser, 'table', 'maintain', 'column', 'start_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维护结束日期',
   'user', @CurrentUser, 'table', 'maintain', 'column', 'end_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', @CurrentUser, 'table', 'maintain', 'column', 'eq_id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维护责任人',
   'user', @CurrentUser, 'table', 'maintain', 'column', 'principal'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备状况',
   'user', @CurrentUser, 'table', 'maintain', 'column', 'status'
go

/*==============================================================*/
/* Table: maintain_level                                        */
/*==============================================================*/
create table maintain_level (
   id                   int                  identity,
   level_name           nvarchar(50)         null,
   constraint PK_MAINTAIN_LEVEL primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '保养等级表',
   'user', @CurrentUser, 'table', 'maintain_level'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '保养等级',
   'user', @CurrentUser, 'table', 'maintain_level', 'column', 'level_name'
go

/*==============================================================*/
/* Table: maintain_plan                                         */
/*==============================================================*/
create table maintain_plan (
   id                   int                  identity,
   plan_asset           nvarchar(50)         null,
   eq_id                int                  null,
   start_date           datetime             null,
   over_time            int                  null,
   constraint PK_MAINTAIN_PLAN primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维护计划表',
   'user', @CurrentUser, 'table', 'maintain_plan'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维护计划编号',
   'user', @CurrentUser, 'table', 'maintain_plan', 'column', 'plan_asset'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', @CurrentUser, 'table', 'maintain_plan', 'column', 'eq_id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '安排日期',
   'user', @CurrentUser, 'table', 'maintain_plan', 'column', 'start_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维护周期天数',
   'user', @CurrentUser, 'table', 'maintain_plan', 'column', 'over_time'
go

/*==============================================================*/
/* Table: part_account                                          */
/*==============================================================*/
create table part_account (
   id                   int                  identity,
   part_asset           nvarchar(50)         null,
   part_name            nvarchar(50)         null,
   material             nvarchar(50)         null,
   part_weight          nvarchar(50)         null,
   standard             bit                  null,
   equipment            nvarchar(100)        null,
   part_photo           image                null,
   part_3d              image                null,
   constraint PK_PART_ACCOUNT primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配件台帐',
   'user', @CurrentUser, 'table', 'part_account'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '零件编号',
   'user', @CurrentUser, 'table', 'part_account', 'column', 'part_asset'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '零件名称',
   'user', @CurrentUser, 'table', 'part_account', 'column', 'part_name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '制造材料',
   'user', @CurrentUser, 'table', 'part_account', 'column', 'material'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否标准件：1是 2否',
   'user', @CurrentUser, 'table', 'part_account', 'column', 'standard'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用到本零件的设备，用分号隔开，如：2;4;5',
   'user', @CurrentUser, 'table', 'part_account', 'column', 'equipment'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '零件图片',
   'user', @CurrentUser, 'table', 'part_account', 'column', 'part_photo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '零件3d图形文件',
   'user', @CurrentUser, 'table', 'part_account', 'column', 'part_3d'
go

/*==============================================================*/
/* Table: repair                                                */
/*==============================================================*/
create table repair (
   id                   int                  identity,
   repair_asset         nvarchar(50)         null,
   eq_id                int                  null,
   start_date           datetime             null,
   end_time             datetime             null,
   stop_time            int                  null,
   target_department    nvarchar(50)         null,
   source_department    nvarchar(50)         null,
   principal            nvarchar(50)         null,
   memo_before          ntext                null,
   memo_after           ntext                null,
   memo_record          ntext                null,
   constraint PK_REPAIR primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修记录表',
   'user', @CurrentUser, 'table', 'repair'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修编号',
   'user', @CurrentUser, 'table', 'repair', 'column', 'repair_asset'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', @CurrentUser, 'table', 'repair', 'column', 'eq_id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修开始日期',
   'user', @CurrentUser, 'table', 'repair', 'column', 'start_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修结束日期',
   'user', @CurrentUser, 'table', 'repair', 'column', 'end_time'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '停机天数',
   'user', @CurrentUser, 'table', 'repair', 'column', 'stop_time'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '目标部门，被修理部门',
   'user', @CurrentUser, 'table', 'repair', 'column', 'target_department'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修理部门',
   'user', @CurrentUser, 'table', 'repair', 'column', 'source_department'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修负责人',
   'user', @CurrentUser, 'table', 'repair', 'column', 'principal'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修前设备状况',
   'user', @CurrentUser, 'table', 'repair', 'column', 'memo_before'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修后设备状况',
   'user', @CurrentUser, 'table', 'repair', 'column', 'memo_after'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修记录',
   'user', @CurrentUser, 'table', 'repair', 'column', 'memo_record'
go

/*==============================================================*/
/* Table: repair_plan                                           */
/*==============================================================*/
create table repair_plan (
   id                   int                  identity,
   plan_asset           nvarchar(50)         null,
   eq_id                int                  null,
   start_date           datetime             null,
   over_time            int                  null,
   stop_time            int                  null,
   target_department    nvarchar(50)         null,
   source_department    nvarchar(50)         null,
   principal            nvarchar(50)         null,
   memo                 ntext                null,
   constraint PK_REPAIR_PLAN primary key (id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修计划',
   'user', @CurrentUser, 'table', 'repair_plan'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修计划编号',
   'user', @CurrentUser, 'table', 'repair_plan', 'column', 'plan_asset'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备ID',
   'user', @CurrentUser, 'table', 'repair_plan', 'column', 'eq_id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修开始日期',
   'user', @CurrentUser, 'table', 'repair_plan', 'column', 'start_date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修经历天数',
   'user', @CurrentUser, 'table', 'repair_plan', 'column', 'over_time'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '停机天数',
   'user', @CurrentUser, 'table', 'repair_plan', 'column', 'stop_time'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '目标部门，被修理部门',
   'user', @CurrentUser, 'table', 'repair_plan', 'column', 'target_department'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修理部门',
   'user', @CurrentUser, 'table', 'repair_plan', 'column', 'source_department'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修负责人',
   'user', @CurrentUser, 'table', 'repair_plan', 'column', 'principal'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '维修计划备注',
   'user', @CurrentUser, 'table', 'repair_plan', 'column', 'memo'
go

/*==============================================================*/
/* Table: sys_sys                                               */
/*==============================================================*/
create table sys_sys (
   username             nvarchar(50)         not null,
   password             nvarchar(50)         null,
   realname             nvarchar(50)         null,
   userright            int                  null,
   constraint PK_SYS_SYS primary key nonclustered (username)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '系统表',
   'user', @CurrentUser, 'table', 'sys_sys'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户名',
   'user', @CurrentUser, 'table', 'sys_sys', 'column', 'username'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '密码',
   'user', @CurrentUser, 'table', 'sys_sys', 'column', 'password'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户真实姓名',
   'user', @CurrentUser, 'table', 'sys_sys', 'column', 'realname'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '系统权限',
   'user', @CurrentUser, 'table', 'sys_sys', 'column', 'userright'
go

alter table eq_account
   add constraint FK_EQ_ACCOU_REFERENCE_EQ_STATU foreign key (status)
      references eq_status (id)
go

alter table eq_account
   add constraint FK_EQ_ACCOU_REFERENCE_EQ_TYPE foreign key (type)
      references eq_type (id)
go

alter table eq_account
   add constraint FK_EQ_ACCOU_REFERENCE_DEPARTME foreign key (department)
      references department (id)
go

