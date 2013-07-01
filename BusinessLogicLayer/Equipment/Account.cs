using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

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
    }
}
