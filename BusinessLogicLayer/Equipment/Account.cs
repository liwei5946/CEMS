using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using Util;

namespace BusinessLogicLayer.Equipment
{
    public class Account
    {
        AccountService acc = new AccountService();
        /// <summary>
        /// 查找部门treeview数据
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_Department()
        {
            return acc.CreateDataSet_Department();
        }
        /// <summary>
        /// 查找设备类型treeview数据
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_EquipmentType()
        {
            return acc.CreateDataSet_EquipmentType();
        }
        /// <summary>
        /// 查找设备台帐信息
        /// </summary>
        /// <returns></returns>
        public DataSet queryAccount()
        {
            return acc.queryAccount();
        }
        /// <summary>
        /// 根据id查询对应obj三维模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryAccountObjById(string id)
        {
            return acc.queryAccountObjById(id);
        }
        /// <summary>
        /// 根据id查询对应设备图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns>id,asset,eqname,photo</returns>
        public DataSet queryAccountImgById(string id)
        {
            return acc.queryAccountImgById(id);
        }
        /// <summary>
        /// 删除制定ID的台帐信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteAccountById(string id)
        {
            return acc.deleteAccountById(id);
        }
        /// <summary>
        /// 根据ID查询台帐信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ea.id,	ea.isoff,	ea.asset,	ea.eqname,	ea.model,	ea.specification,	ea.department,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	ea.[status],	ea.[type],	ea.[address],	ea.photo,	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr</returns>
        public DataSet queryAccountById(string id)
        {
            return acc.queryAccountById(id);
        }
        /// <summary>
        /// 销帐
        /// </summary>
        /// <param name="isoff"></param>
        /// <param name="off_date"></param>
        /// <param name="off_type"></param>
        /// <param name="off_value"></param>
        /// <param name="off_memo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool writeOffAccount(Boolean isoff, string off_date, int off_type, float off_value, string off_memo, string id)
        {
            return acc.writeOffAccount(isoff, off_date, off_type, off_value, off_memo, id);
        }
        /// <summary>
        /// 查询销帐类型
        /// </summary>
        /// <returns></returns>
        public DataSet queryOffType()
        {
            return acc.queryOffType();
        }
        /// <summary>
        /// 查找全部已销帐设备台帐信息
        /// </summary>
        /// <returns></returns>
        public DataSet queryOffAccount()
        {
            return acc.queryOffAccount();
        }
        /// <summary>
        /// 将制定ID的设备重新入账
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean reOffAccountById(string id)
        {
            return acc.reOffAccountById(id);
        }
        /// <summary>
        /// 新增维护计划
        /// </summary>
        /// <param name="planAsset"></param>
        /// <param name="eqId"></param>
        /// <param name="startDate"></param>
        /// <param name="overTime"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public bool addMaintainPlan(string planAsset, int eqId, string startDate, int overTime, string memo)
        {
            return acc.addMaintainPlan(planAsset, eqId, startDate, overTime, memo);
        }
        /// <summary>
        /// 查询若干天前到今天的维护计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryMaintainPlanByDays(int overDays)
        {
            return acc.queryMaintainPlanByDays(overDays);
        }
        /// <summary>
        /// 修改维护计划
        /// </summary>
        /// <param name="plan_asset"></param>
        /// <param name="start_date"></param>
        /// <param name="over_time"></param>
        /// <param name="memo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool updateMaintainPlanById(string plan_asset, string start_date, int over_time, string memo, string id)
        {
            return acc.updateMaintainPlanById(plan_asset, start_date, over_time, memo, id);
        }
        /// <summary>
        /// 删除制定ID的维护计划信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteMaintainPlanById(string id)
        {
            return acc.deleteMaintainPlanById(id);
        }
        /// <summary>
        /// 查询是否已经存在某维护计划所对应的维护记录
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public bool hasMaintainForPlan(string planId)
        {
            return acc.hasMaintainForPlan(planId);
        }
        /// <summary>
        /// 新增维护记录
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="status"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="memo"></param>
        /// <param name="principal"></param>
        /// <returns></returns>
        public bool addMaintain(string planId, string status, string startDate, string endDate, string memo, string principal)
        {
            return acc.addMaintain(planId, status, startDate, endDate, memo, principal);
        }
        /// <summary>
        /// 查询若干天前到今天的维护记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryMaintainByDays(int overDays)
        {
            return acc.queryMaintainByDays(overDays);
        }
        /// <summary>
        /// 修改维修记录
        /// </summary>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <param name="principal"></param>
        /// <param name="status"></param>
        /// <param name="memo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool updateMaintainById(string start_date, string end_date, string principal, string status, string memo, string id)
        {
            return acc.updateMaintainById(start_date, end_date, principal, status, memo, id);
        }
        /// <summary>
        /// 删除制定ID的维护记录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteMaintainById(string id)
        {
            return acc.deleteMaintainById(id);
        }
        /// <summary>
        /// 新增维修计划
        /// </summary>
        /// <param name="plan_asset"></param>
        /// <param name="eq_id"></param>
        /// <param name="start_date"></param>
        /// <param name="over_time"></param>
        /// <param name="stop_time"></param>
        /// <param name="target_department"></param>
        /// <param name="source_department"></param>
        /// <param name="principal"></param>
        /// <param name="memo"></param>
        /// <param name="level_id"></param>
        /// <returns></returns>
        public bool addRepairPlan(string plan_asset, string eq_id, string start_date, int over_time, int stop_time, string target_department, string source_department, string principal, string memo, string level_id)
        {
            return acc.addRepairPlan(plan_asset, eq_id, start_date, over_time, stop_time, target_department, source_department, principal, memo, level_id);
        }
        /// <summary>
        /// 根据ID查询维修计划信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>rp.id,	rp.plan_asset,	ea.asset,	ea.eqname,	d.departname,	rp.level_id,	rp.[start_date],	rp.over_time,	rp.stop_time,	rp.target_department,	rp.source_department,	rp.principal,	rp.memo</returns>
        public DataSet queryRepairPlanById(string id)
        {
            return acc.queryRepairPlanById(id);
        }
        /// <summary>
        /// 查询若干天前到今天的维修计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryRepairPlanByDays(int overDays)
        {
            return acc.queryRepairPlanByDays(overDays);
        }
        /// <summary>
        /// 修改维修计划
        /// </summary>
        /// <param name="plan_asset"></param>
        /// <param name="eq_id"></param>
        /// <param name="start_date"></param>
        /// <param name="over_time"></param>
        /// <param name="stop_time"></param>
        /// <param name="target_department"></param>
        /// <param name="source_department"></param>
        /// <param name="principal"></param>
        /// <param name="memo"></param>
        /// <param name="level_id"></param>
        /// <returns></returns>
        public bool updateRepairPlan(string id, string plan_asset, string start_date, int over_time, int stop_time, string target_department, string source_department, string principal, string memo, string level_id)
        {
            return acc.updateRepairPlan(id, plan_asset, start_date, over_time, stop_time, target_department, source_department, principal, memo, level_id); 
        }
         /// <summary>
        /// 查询是否已经存在某维修计划所对应的维修记录
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public bool hasRepairForPlan(string planId)
        {
            return acc.hasRepairForPlan(planId);
        }
        /// <summary>
        /// 删除指定ID的维修记录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteRepairPlanById(string planId)
        {
            return acc.deleteRepairPlanById(planId);
        }
        /// <summary>
        /// 新增维修记录
        /// </summary>
        /// <param name="repair_asset"></param>
        /// <param name="plan_id"></param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <param name="stop_time"></param>
        /// <param name="target_department"></param>
        /// <param name="source_department"></param>
        /// <param name="repair_group"></param>
        /// <param name="principal"></param>
        /// <param name="memo_before"></param>
        /// <param name="memo_after"></param>
        /// <param name="memo_record"></param>
        /// <returns></returns>
        public bool addRepair(string repair_asset, string plan_id, string start_date, string end_date, string stop_time, string target_department, string source_department, string repair_group, string principal, string memo_before, string memo_after, string memo_record, string repair_level)
        {
            return acc.addRepair(repair_asset, plan_id, start_date, end_date, stop_time, target_department, source_department, repair_group, principal, memo_before, memo_after, memo_record, repair_level); 
        }
         /// <summary>
        /// 查询若干天前到今天的维修记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryRepairByDays(int overDays)
        {
            return acc.queryRepairByDays(overDays);
        }
        /// <summary>
        /// 根据ID查询维修信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryRepairById(string id)
        {
            return acc.queryRepairById(id);
        }
         /// <summary>
        /// 修改维修计划
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repair_asset"></param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <param name="stop_time"></param>
        /// <param name="target_department"></param>
        /// <param name="source_department"></param>
        /// <param name="repair_group"></param>
        /// <param name="principal"></param>
        /// <param name="memo_before"></param>
        /// <param name="memo_after"></param>
        /// <param name="memo_record"></param>
        /// <param name="repair_level"></param>
        /// <returns></returns>
        public bool updateRepair(string id, string repair_asset, string start_date, string end_date, string stop_time, string target_department, string source_department, string repair_group, string principal, string memo_before, string memo_after, string memo_record, string repair_level)
        {
            return acc.updateRepair(id, repair_asset, start_date, end_date, stop_time, target_department, source_department, repair_group, principal, memo_before, memo_after, memo_record, repair_level);
        }
        /// <summary>
        /// 删除指定ID的维修信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteRepairById(string repairId)
        {
            return acc.deleteRepairById(repairId);
        }
        /// <summary>
        /// 查找全部关键零配件台帐信息
        /// 前100条记录
        /// </summary>
        /// <returns></returns>
        public DataSet queryPart()
        {
            return acc.queryPart();
        }
        /// <summary>
        /// 根据id查询对应配件的obj三维模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryPartObjById(string id)
        {
            return acc.queryPartObjById(id);
        }
        /// <summary>
        /// 根据id查询对应配件图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns>id,asset,eqname,photo</returns>
        public DataSet queryPartImgById(string id)
        {
            return acc.queryPartImgById(id);
        }
        /// <summary>
        /// 根据ID查询配件信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryPartById(string id)
        {
            return acc.queryPartById(id);
        }
        /// <summary>
        /// 删除制定ID的配件信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deletePartById(string id)
        {
            return acc.deletePartById(id);
        }
        /// <summary>
        /// 查询是否已经存在某设备所对应的配件
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public bool hasPartForAccount(string eqId)
        {
            return acc.hasPartForAccount(eqId);
        }
        /// <summary>
        /// 查找全部故障信息
        /// </summary>
        /// <returns></returns>
        public DataSet queryFault()
        {
            return acc.queryFault();
        }
        /// <summary>
        /// 查找指定ID故障信息(含图片信息)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryFaultByIdIncludeImage(string id)
        {
            return acc.queryFaultByIdIncludeImage(id);
        }
        /// <summary>
        /// 查找指定ID故障信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryFaultById(string id)
        {
            return acc.queryFaultById(id);
        }
        /// <summary>
        /// 删除制定ID的故障信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteFaultById(string id)
        {
            return acc.deleteFaultById(id);
        }
         /// <summary>
        /// 查找全部故障知识库
        /// </summary>
        /// <returns></returns>
        public DataSet queryKnowledge()
        {
            return acc.queryKnowledge();
        }
        /// <summary>
        /// 查找指定ID故障知识
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryKnowledgeById(string id)
        {
            return acc.queryKnowledgeById(id);
        }
        /// <summary>
        /// 查找指定ID故障知识
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryKnowledgeByIdForEdit(string id)
        {
            return acc.queryKnowledgeByIdForEdit(id);
        }
        /// <summary>
        /// 删除制定ID的故障知识库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteKnowledgeById(string id)
        {
            return acc.deleteKnowledgeById(id);
        }
        /// <summary>
        /// 查找全部事故信息
        /// </summary>
        /// <returns></returns>
        public DataSet queryTrouble()
        {
            return acc.queryTrouble();
        }
        /// <summary>
        /// 查找指定ID故障信息(含图片信息)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryTroubleByIdIncludeImage(string id)
        {
            return acc.queryTroubleByIdIncludeImage(id);
        }
        /// <summary>
        /// 删除制定ID的事故信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteTroubleById(string id)
        {
            return acc.deleteTroubleById(id);
        }
        /// <summary>
        /// 添加信息
        /// 参数设置模块的通用添加方法
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colName"></param>
        /// <param name="insValue"></param>
        /// <returns></returns>
        public bool addInfomation(string tableName, string colName, string insValue)
        {
            return acc.addInfomation(tableName, colName, insValue);
        }
        /// <summary>
        /// 删除信息
        /// 参数设置模块的通用删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteInfomation(string id, string tableName)
        {
            return acc.deleteInfomation(id, tableName);
        }
        /// <summary>
        /// 查询信息
        /// 参数设置模块的通用查询方法
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataSet queryInfomation(string tableName)
        {
            return acc.queryInfomation(tableName);
        }
        /// <summary>
        /// 修改信息
        /// 参数设置模块的通用修改方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tableName"></param>
        /// <param name="colName"></param>
        /// <param name="updateValue"></param>
        /// <returns></returns>
        public bool updateInfomation(string id, string tableName, string colName, string updateValue)
        {
            return acc.updateInfomation(id, tableName, colName, updateValue);
        }
        /// <summary>
        /// 查找全部用户信息
        /// </summary>
        /// <returns></returns>
        public DataSet queryUsers()
        {
            return acc.queryUsers();
        }
        /// <summary>
        /// 判断是否已有重名的用户名存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool hasSameUsername(string username)
        {
            return acc.hasSameUsername(username);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="realname"></param>
        /// <param name="userright"></param>
        /// <returns></returns>
        public bool addUser(
            string username,
               string password,
               string realname,
               int userright
            )
        {
            return acc.addUser(username, MD5Hashing.HashString(password), realname, userright);
        }


    }
}
