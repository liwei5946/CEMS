using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Util;
using log4net;

namespace DataAccessLayer
{
    public class AccountService
    {
        private DataSet ds;
        ILog log = log4net.LogManager.GetLogger(typeof(AccountService));
        #region Private Members
        //从配置文件中读取数据库连接字符串
        //private readonly string connString = ConfigurationManager.ConnectionStrings["CEMSConnectionString"].ToString();
        //private readonly string dboOwner = ConfigurationManager.ConnectionStrings["DataBaseOwner"].ToString();
        private readonly string connString = ConfigAppSettings.getDBConnString();
        private readonly string dboOwner = ConfigAppSettings.getDBOwner();
        #endregion
        /// <summary>
        /// 创建department的DataSet
        /// 查找department表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataSet CreateDataSet_Department()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT * FROM department WHERE dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 创建eq_type的DataSet
        /// 查找eq_type表
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_EquipmentType()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT * FROM eq_type WHERE dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 查找全部设备台帐信息
        /// 前100条记录
        /// </summary>
        /// <returns></returns>
        public DataSet queryAccount()
        {
            try
            {
                SqlDataAdapter sda;
                
                //string sql = string.Format("SELECT id,asset,eqname,photo FROM eq_account WHERE dr=0");
                //string sql = string.Format("SELECT	ea.id, ea.asset, ea.eqname, ea.photo,	ea.isoff,ea.model,	ea.specification,	d.departname,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	es.status_name,	et.[type_name],	ea.[address],	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr  FROM	eq_account ea LEFT JOIN department d ON ea.department=d.id LEFT JOIN eq_status es ON ea.[status]=es.id LEFT JOIN eq_type et ON ea.[type]=et.id WHERE  ea.isoff=0 AND ea.dr=0");
                string sql = "SELECT TOP 100 ea.id, ea.asset, ea.eqname, ea.photo,	ea.isoff,ea.model,	ea.specification,	d.departname,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	es.status_name,	et.[type_name],	ea.[address],	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr  FROM	eq_account ea LEFT JOIN department d ON ea.department=d.id LEFT JOIN eq_status es ON ea.[status]=es.id LEFT JOIN eq_type et ON ea.[type]=et.id  "
           + "WHERE  ea.isoff=0 AND ea.dr=0 "
           + "ORDER BY ea.ts DESC";
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 查找全部关键零配件台帐信息
        /// 前100条记录
        /// </summary>
        /// <returns></returns>
        public DataSet queryPart()
        {
            try
            {
                SqlDataAdapter sda;

                //string sql = string.Format("SELECT id,asset,eqname,photo FROM eq_account WHERE dr=0");
                //string sql = string.Format("SELECT	ea.id, ea.asset, ea.eqname, ea.photo,	ea.isoff,ea.model,	ea.specification,	d.departname,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	es.status_name,	et.[type_name],	ea.[address],	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr  FROM	eq_account ea LEFT JOIN department d ON ea.department=d.id LEFT JOIN eq_status es ON ea.[status]=es.id LEFT JOIN eq_type et ON ea.[type]=et.id WHERE  ea.isoff=0 AND ea.dr=0");
                string sql = "SELECT TOP 100 pa.id, "
           + "       ea.asset, "
           + "       ea.eqname, "
           + "       d.departname, "
           + "       pa.part_asset, "
           + "       pa.part_name, "
           + "       pa.material, "
           + "       pa.part_weight, "
           + "       pa.[standard] "
           + "FROM   part_account pa "
           + "       LEFT JOIN eq_account ea "
           + "            ON  pa.eq_id = ea.id "
           + "       LEFT JOIN department d "
           + "            ON  ea.department = d.id "
           + "WHERE pa.dr=0  "
           + "ORDER BY "
           + "       pa.ts DESC";
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 查找全部已销帐设备台帐信息
        /// </summary>
        /// <returns></returns>
        public DataSet queryOffAccount()
        {
            try
            {
                SqlDataAdapter sda;
                //string sql = string.Format("SELECT id,asset,eqname,photo FROM eq_account WHERE dr=0");
                string sql = string.Format("SELECT	ea.id, ea.asset, ea.eqname,et.[type_name], d.departname,ew.off_typename,ea.[value],ea.off_value,ea.[count],ea.off_date	  FROM	eq_account ea LEFT JOIN department d ON ea.department=d.id LEFT JOIN eq_status es ON ea.[status]=es.id LEFT JOIN eq_type et ON ea.[type]=et.id LEFT JOIN eq_writeoff ew ON ea.off_type=ew.id WHERE  ea.isoff=1 AND ea.dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 根据id查询对应obj三维模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns>id,asset,eqname,three_dimensional</returns>
        public DataSet queryAccountObjById(string id)
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT id,asset,eqname,three_dimensional FROM eq_account WHERE dr=0 AND id=" + id);
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 根据id查询对应设备图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns>id,asset,eqname,photo</returns>
        public DataSet queryAccountImgById(string id)
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT id,asset,eqname,photo FROM eq_account WHERE dr=0 AND id=" + id);
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 根据ID查询台帐信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ea.id,	ea.isoff,	ea.asset,	ea.eqname,	ea.model,	ea.specification,	ea.department,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	ea.[status],	ea.[type],	ea.[address],	ea.photo,	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr</returns>
        public DataSet queryAccountById(string id)
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT	ea.id,	ea.isoff,	ea.asset,	ea.eqname,	ea.model,	ea.specification,	ea.department,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	ea.[status],	ea.[type],	ea.[address],	ea.photo,	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr FROM	eq_account ea WHERE ea.dr=0 AND ea.id=" + id);
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 删除制定ID的台帐信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteAccountById(string id)
        {
            int result = 0;
            try
            {
                string sql = string.Format("UPDATE eq_account SET dr = 1 WHERE id=" + id);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// 删除制定ID的维护计划信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteMaintainPlanById(string id)
        {
            int result = 0;
            try
            {
                string sql = string.Format("UPDATE maintain_plan SET dr = 1 WHERE id=" + id);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 删除制定ID的维护记录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteMaintainById(string id)
        {
            int result = 0;
            try
            {
                string sql = string.Format("UPDATE maintain SET dr = 1 WHERE id=" + id);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

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
            int resault = 0;
            string sql = string.Format("UPDATE eq_account SET isoff =@isoff,off_date = @off_date,off_type =@off_type,off_value = @off_value,off_memo = @off_memo WHERE id=" + id);
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@isoff", SqlDbType.Bit));
                    mycom.Parameters.Add(new SqlParameter("@off_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@off_type", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@off_value", SqlDbType.Float));
                    mycom.Parameters.Add(new SqlParameter("@off_memo", SqlDbType.NText));


                    //给参数赋值
                    mycom.Parameters["@isoff"].Value = isoff;
                    mycom.Parameters["@off_date"].Value = off_date;
                    mycom.Parameters["@off_type"].Value = off_type;
                    mycom.Parameters["@off_value"].Value = off_value;
                    mycom.Parameters["@off_memo"].Value = off_memo;

                    //执行添加语句 
                    resault = mycom.ExecuteNonQuery();
                    log.Debug(resault);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            if (resault > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询销帐类型
        /// </summary>
        /// <returns></returns>
        public DataSet queryOffType()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT	ew.id, ew.off_typename FROM eq_writeoff ew");
                //log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 将制定ID的设备重新入账
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean reOffAccountById(string id)
        {
            int result = 0;
            try
            {
                string sql = string.Format("UPDATE eq_account SET isoff = 0 WHERE id=" + id);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

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
            int resault = 0;
            string sql = string.Format("INSERT INTO maintain_plan(	plan_asset,	eq_id,	[start_date],	over_time,	memo)VALUES(@planAsset,@eqId,@startDate,@overTime,@memo)");
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@planAsset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@eqId", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@startDate", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@overTime", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@memo", SqlDbType.NText));

                    //给参数赋值
                    mycom.Parameters["@planAsset"].Value = planAsset;
                    mycom.Parameters["@eqId"].Value = eqId;
                    mycom.Parameters["@startDate"].Value = startDate;
                    mycom.Parameters["@overTime"].Value = overTime;
                    mycom.Parameters["@memo"].Value = memo;
                    //执行添加语句 
                    resault = mycom.ExecuteNonQuery();
                    log.Debug(resault);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            if (resault > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 查询若干天前到制定日期的维护计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryMaintainPlanByDays(int overDays, string maintainDay)
        {
            try
            {
                SqlDataAdapter sda;
                //GETDATE()
                string sql = string.Format("SELECT mp.id, mp.plan_asset,ea.eqname,ea.asset, d.departname, mp.[start_date], mp.over_time, mp.memo  FROM maintain_plan mp  LEFT JOIN eq_account ea ON mp.eq_id=ea.id  LEFT JOIN department d ON d.id=ea.department WHERE mp.[start_date]>=DATEADD(DAY,-" + overDays + "," + maintainDay + ") AND mp.dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 查询若干天前到今天的维护计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryMaintainPlanByDays(int overDays)
        {
            try
            {
                SqlDataAdapter sda;
                //GETDATE()
                string sql = string.Format("SELECT mp.id, mp.plan_asset,ea.eqname,ea.asset, d.departname, mp.[start_date], mp.over_time, mp.memo  FROM maintain_plan mp  LEFT JOIN eq_account ea ON mp.eq_id=ea.id  LEFT JOIN department d ON d.id=ea.department WHERE mp.[start_date]>=DATEADD(DAY,-" + overDays + ",GETDATE()) AND mp.dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
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
            int resault = 0;
            string sql = string.Format("UPDATE maintain_plan SET plan_asset = @plan_asset,[start_date] = @start_date, over_time = @over_time,memo = @memo WHERE id=" + id);
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@plan_asset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@start_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@over_time", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@memo", SqlDbType.NText));

                    //给参数赋值
                    mycom.Parameters["@plan_asset"].Value = plan_asset;
                    mycom.Parameters["@start_date"].Value = start_date;
                    mycom.Parameters["@over_time"].Value = over_time;
                    mycom.Parameters["@memo"].Value = memo;

                    //执行添加语句 
                    resault = mycom.ExecuteNonQuery();
                    log.Debug(resault);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            if (resault > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询是否已经存在某维护计划所对应的维护记录
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public bool hasMaintainForPlan(string planId)
        {
            bool flag = false;
            int result = 0;
            try
            {
                string sql = string.Format("SELECT COUNT(*) FROM maintain m WHERE m.dr=0 AND m.plan_id=" + planId);
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(sql, conn);
                    conn.Open();
                    result = (int)command.ExecuteScalar();
                    conn.Close();
                    conn.Dispose();
                }
                if (result > 0)
                {
                    flag = true;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            return flag;
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
            int resault = 0;
            string sql = string.Format("INSERT INTO maintain ([start_date],end_date,plan_id,principal,[status],memo) VALUES(@startDate,@endDate,@planId,@principal,@status,@memo)");
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@planId", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@startDate", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@endDate", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@memo", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@principal", SqlDbType.NVarChar, 50));

                    //给参数赋值
                    mycom.Parameters["@planId"].Value = planId;
                    mycom.Parameters["@status"].Value = status;
                    mycom.Parameters["@startDate"].Value = startDate;
                    mycom.Parameters["@endDate"].Value = endDate;
                    mycom.Parameters["@memo"].Value = memo;
                    mycom.Parameters["@principal"].Value = principal;
                    //执行添加语句 
                    resault = mycom.ExecuteNonQuery();
                    log.Debug(resault);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            if (resault > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 查询若干天前到今天的维护记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryMaintainByDays(int overDays)
        {
            try
            {
                SqlDataAdapter sda;
                //GETDATE()
                string sql = string.Format("SELECT	m.id,m.[start_date],m.end_date,	m.principal,m.[status],	m.memo,mp.plan_asset,mp.[start_date],mp.over_time,ea.asset,ea.eqname,d.departname FROM	maintain m	LEFT JOIN maintain_plan mp ON m.plan_id=mp.id	LEFT JOIN eq_account ea ON mp.eq_id=ea.id	LEFT JOIN department d ON ea.department=d.id WHERE m.[start_date]>=DATEADD(DAY,-" + overDays + ",GETDATE()) AND m.dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
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
            int resault = 0;
            string sql = string.Format("UPDATE maintain SET	[start_date] = @start_date,	end_date = @end_date,	principal = @principal,	[status] = @status,	memo = @memo WHERE id=" + id);
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@principal", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@start_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@end_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@memo", SqlDbType.NText));

                    //给参数赋值
                    mycom.Parameters["@principal"].Value = principal;
                    mycom.Parameters["@status"].Value = status;
                    mycom.Parameters["@start_date"].Value = start_date;
                    mycom.Parameters["@end_date"].Value = end_date;
                    mycom.Parameters["@memo"].Value = memo;

                    //执行添加语句 
                    resault = mycom.ExecuteNonQuery();
                    log.Debug(resault);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            if (resault > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            int resault = 0;
            string sql = string.Format("INSERT INTO repair_plan(	plan_asset,	eq_id,	[start_date],	over_time,	stop_time,	target_department,	source_department,	principal,	memo,	level_id) VALUES(@plan_asset,@eq_id,@start_date,@over_time,@stop_time,@target_department,@source_department,@principal,@memo,@level_id)");
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@plan_asset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@eq_id", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@start_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@over_time", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@stop_time", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@target_department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@source_department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@principal", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@memo", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@level_id", SqlDbType.Int));

                    //给参数赋值
                    mycom.Parameters["@plan_asset"].Value = plan_asset;
                    mycom.Parameters["@eq_id"].Value = eq_id;
                    mycom.Parameters["@start_date"].Value = start_date;
                    mycom.Parameters["@over_time"].Value = over_time;
                    mycom.Parameters["@stop_time"].Value = stop_time;
                    mycom.Parameters["@target_department"].Value = target_department;
                    mycom.Parameters["@source_department"].Value = source_department;
                    mycom.Parameters["@principal"].Value = principal;
                    mycom.Parameters["@memo"].Value = memo;
                    mycom.Parameters["@level_id"].Value = level_id;
                    //执行添加语句 
                    resault = mycom.ExecuteNonQuery();
                    log.Debug(resault);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            if (resault > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据ID查询维修计划信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>rp.id,	rp.plan_asset,	ea.asset,	ea.eqname,	d.departname,	rp.level_id,	rp.[start_date],	rp.over_time,	rp.stop_time,	rp.target_department,	rp.source_department,	rp.principal,	rp.memo</returns>
        public DataSet queryRepairPlanById(string id)
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT	rp.id,	rp.plan_asset,	ea.asset,ea.eqname,d.departname,	rp.[start_date],	rp.over_time,	rp.stop_time,	rp.target_department,	rp.source_department,	rp.principal,	rp.memo,	rp.level_id FROM	repair_plan rp LEFT JOIN eq_account ea ON rp.eq_id=ea.id LEFT JOIN department d ON ea.department=d.id WHERE rp.dr=0 AND rp.id=" + id);
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 查询若干天前到今天的维修计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryRepairPlanByDays(int overDays)
        {
            try
            {
                SqlDataAdapter sda;
                //GETDATE()
                string sql = string.Format("SELECT	rp.id,	rp.plan_asset,	ea.asset,	ea.eqname,	d.departname,	r.level_name,	rp.[start_date],	rp.over_time,	rp.stop_time,d1.departname AS tdep,	d2.departname AS sdep,	rp.principal,	rp.memo FROM	repair_plan rp LEFT JOIN eq_account ea ON rp.eq_id=ea.id LEFT JOIN department d ON ea.department=d.id LEFT JOIN department d1 ON rp.target_department=d1.id LEFT JOIN department d2 ON rp.source_department =d2.id LEFT JOIN repair_level r ON rp.level_id=r.id WHERE rp.dr=0 AND rp.[start_date]>=DATEADD(DAY,-" + overDays + ",GETDATE())");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
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
        public bool updateRepairPlan(string id,string plan_asset, string start_date, int over_time, int stop_time, string target_department, string source_department, string principal, string memo, string level_id)
        {
            int resault = 0;
            string sql = string.Format("UPDATE repair_plan SET	plan_asset = @plan_asset,	[start_date] = @start_date,	over_time = @over_time,	stop_time = @stop_time,	target_department = @target_department,	source_department = @source_department,	principal = @principal,	memo = @memo,	level_id = @level_id WHERE id=" + id);
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@plan_asset", SqlDbType.NVarChar, 50));
                    //mycom.Parameters.Add(new SqlParameter("@eq_id", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@start_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@over_time", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@stop_time", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@target_department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@source_department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@principal", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@memo", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@level_id", SqlDbType.Int));

                    //给参数赋值
                    mycom.Parameters["@plan_asset"].Value = plan_asset;
                    //mycom.Parameters["@eq_id"].Value = eq_id;
                    mycom.Parameters["@start_date"].Value = start_date;
                    mycom.Parameters["@over_time"].Value = over_time;
                    mycom.Parameters["@stop_time"].Value = stop_time;
                    mycom.Parameters["@target_department"].Value = target_department;
                    mycom.Parameters["@source_department"].Value = source_department;
                    mycom.Parameters["@principal"].Value = principal;
                    mycom.Parameters["@memo"].Value = memo;
                    mycom.Parameters["@level_id"].Value = level_id;
                    //执行添加语句 
                    resault = mycom.ExecuteNonQuery();
                    log.Debug(resault);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            if (resault > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询是否已经存在某维修计划所对应的维修记录
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public bool hasRepairForPlan(string planId)
        {
            bool flag = false;
            int result = 0;
            try
            {
                string sql = string.Format("SELECT COUNT(*) FROM repair m WHERE m.dr=0 AND m.plan_id=" + planId);
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(sql, conn);
                    conn.Open();
                    result = (int)command.ExecuteScalar();
                    conn.Close();
                    conn.Dispose();
                }
                if (result > 0)
                {
                    flag = true;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            return flag;
        }
        /// <summary>
        /// 删除指定ID的维修计划信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteRepairPlanById(string planId)
        {
            int result = 0;
            try
            {
                string sql = string.Format("UPDATE repair_plan SET dr = 1 WHERE id=" + planId);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public bool addRepair(string repair_asset, string plan_id, string start_date, string end_date, string stop_time, string target_department, string source_department, string repair_group, string principal, string memo_before, string memo_after, string memo_record,string repair_level)
        {
            int resault = 0;
            string sql = string.Format("INSERT INTO repair(	repair_asset,	plan_id,	[start_date],	end_date,	stop_time,	target_department,	source_department,	repair_group,	principal,	memo_before,	memo_after,	memo_record,repair_level) VALUES (@repair_asset,	@plan_id,	@start_date,	@end_date,	@stop_time,	@target_department,	@source_department,	@repair_group,	@principal,	@memo_before,	@memo_after,	@memo_record,@repair_level)");
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@repair_asset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@plan_id", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@start_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@end_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@stop_time", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@target_department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@source_department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@repair_group", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@principal", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@memo_before", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@memo_after", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@memo_record", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@repair_level", SqlDbType.Int));

                    //给参数赋值
                    mycom.Parameters["@repair_asset"].Value = repair_asset;
                    mycom.Parameters["@plan_id"].Value = plan_id;
                    mycom.Parameters["@start_date"].Value = start_date;
                    mycom.Parameters["@end_date"].Value = end_date;
                    mycom.Parameters["@stop_time"].Value = stop_time;
                    mycom.Parameters["@target_department"].Value = target_department;
                    mycom.Parameters["@source_department"].Value = source_department;
                    mycom.Parameters["@repair_group"].Value = repair_group;
                    mycom.Parameters["@principal"].Value = principal;
                    mycom.Parameters["@memo_before"].Value = memo_before;
                    mycom.Parameters["@memo_after"].Value = memo_after;
                    mycom.Parameters["@memo_record"].Value = memo_record;
                    mycom.Parameters["@repair_level"].Value = repair_level;
                    //执行添加语句 
                    resault = mycom.ExecuteNonQuery();
                    log.Debug(resault);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            if (resault > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询若干天前到今天的维修记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryRepairByDays(int overDays)
        {
            try
            {
                SqlDataAdapter sda;
                //GETDATE()
                //string sql = string.Format("SELECT	rp.id,	rp.plan_asset,	ea.asset,	ea.eqname,	d.departname,	r.level_name,	rp.[start_date],	rp.over_time,	rp.stop_time,d1.departname AS tdep,	d2.departname AS sdep,	rp.principal,	rp.memo FROM	repair_plan rp LEFT JOIN eq_account ea ON rp.eq_id=ea.id LEFT JOIN department d ON ea.department=d.id LEFT JOIN department d1 ON rp.target_department=d1.id LEFT JOIN department d2 ON rp.source_department =d2.id LEFT JOIN repair_level r ON rp.level_id=r.id WHERE rp.dr=0 AND rp.[start_date]>=DATEADD(DAY,-" + overDays + ",GETDATE())");
                string sql = "SELECT r.id, "
           + "       r.repair_asset, "
           + "       ea.asset, "
           + "       ea.eqname, "
           + "       d.departname, "
           + "       rl.level_name, "
           + "       r.[start_date], "
           + "       r.end_date, "
           + "       r.stop_time, "
           + "       d2.departname  AS tdep, "
           + "       d3.departname  AS sdep, "
           + "       r.repair_group, "
           + "       r.principal, "
           + "       r.memo_before, "
           + "       r.memo_after, "
           + "       r.memo_record "
           + "FROM   repair r "
           + "       LEFT JOIN repair_plan rp ON  r.plan_id = rp.id "
           + "       LEFT JOIN eq_account ea ON  rp.eq_id = ea.id "
           + "       LEFT JOIN department d ON  ea.department = d.id "
           + "       LEFT JOIN department d2 ON  r.target_department = d2.id "
           + "       LEFT JOIN department d3 ON  r.source_department = d3.id "
           + "       LEFT JOIN repair_level rl ON r.repair_level=rl.id "
           + "WHERE  r.dr = 0 AND r.[start_date] >= DATEADD(DAY, -" + overDays + ", GETDATE())";
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 根据ID查询维修信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryRepairById(string id)
        {
            try
            {
                SqlDataAdapter sda;
                //string sql = string.Format("SELECT	rp.id,	rp.plan_asset,	ea.asset,ea.eqname,d.departname,	rp.[start_date],	rp.over_time,	rp.stop_time,	rp.target_department,	rp.source_department,	rp.principal,	rp.memo,	rp.level_id FROM	repair_plan rp LEFT JOIN eq_account ea ON rp.eq_id=ea.id LEFT JOIN department d ON ea.department=d.id WHERE rp.dr=0 AND rp.id=" + id);
                string sql = "SELECT "
           + "	r.id, "
           + "	r.repair_asset, "
           + "	r.repair_level, "
           + "	r.[start_date], "
           + "	r.end_date, "
           + "	r.stop_time, "
           + "	r.target_department, "
           + "	r.source_department, "
           + "	r.repair_group, "
           + "	r.principal, "
           + "	r.memo_before, "
           + "	r.memo_after, "
           + "	r.memo_record "
           + "FROM "
           + "	repair r "
           + "WHERE r.id=" + id;
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
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
            int resault = 0;
            //string sql = string.Format("UPDATE repair_plan SET	plan_asset = @plan_asset,	[start_date] = @start_date,	over_time = @over_time,	stop_time = @stop_time,	target_department = @target_department,	source_department = @source_department,	principal = @principal,	memo = @memo,	level_id = @level_id WHERE id=" + id);
            string sql = "UPDATE repair "
           + "SET "
           + "	repair_asset = @repair_asset, "
           + "	[start_date] = @start_date, "
           + "	end_date = @end_date, "
           + "	stop_time = @stop_time, "
           + "	target_department = @target_department, "
           + "	source_department = @source_department, "
           + "	repair_group = @repair_group, "
           + "	principal = @principal, "
           + "	memo_before = @memo_before, "
           + "	memo_after = @memo_after, "
           + "	memo_record = @memo_record, "
           + "	repair_level = @repair_level "
           + "WHERE id=" + id;
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@repair_asset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@start_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@end_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@stop_time", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@target_department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@source_department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@repair_group", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@principal", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@memo_before", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@memo_after", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@memo_record", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@repair_level", SqlDbType.Int));

                    //给参数赋值
                    mycom.Parameters["@repair_asset"].Value = repair_asset;
                    mycom.Parameters["@start_date"].Value = start_date;
                    mycom.Parameters["@end_date"].Value = end_date;
                    mycom.Parameters["@stop_time"].Value = stop_time;
                    mycom.Parameters["@target_department"].Value = target_department;
                    mycom.Parameters["@source_department"].Value = source_department;
                    mycom.Parameters["@repair_group"].Value = repair_group;
                    mycom.Parameters["@principal"].Value = principal;
                    mycom.Parameters["@memo_before"].Value = memo_before;
                    mycom.Parameters["@memo_after"].Value = memo_after;
                    mycom.Parameters["@memo_record"].Value = memo_record;
                    mycom.Parameters["@repair_level"].Value = repair_level;
                    //执行添加语句 
                    resault = mycom.ExecuteNonQuery();
                    log.Debug(resault);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

            if (resault > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除指定ID的维修信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteRepairById(string repairId)
        {
            int result = 0;
            try
            {
                string sql = string.Format("UPDATE repair SET dr = 1 WHERE id=" + repairId);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据id查询对应配件的obj三维模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryPartObjById(string id)
        {
            try
            {
                SqlDataAdapter sda;
                //string sql = string.Format("SELECT id,asset,eqname,three_dimensional FROM eq_account WHERE dr=0 AND id=" + id);
                string sql = "SELECT "
           + "	pa.id, "
           + "	pa.part_asset, "
           + "	pa.part_name, "
           + "	pa.part_3d "
           + "FROM "
           + "	part_account pa "
           + "WHERE pa.dr=0 AND pa.id=" + id;
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 根据id查询对应配件图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns>id,asset,eqname,photo</returns>
        public DataSet queryPartImgById(string id)
        {
            try
            {
                SqlDataAdapter sda;
                //string sql = string.Format("SELECT id,asset,eqname,photo FROM eq_account WHERE dr=0 AND id=" + id);
                string sql = "SELECT "
           + "	pa.id, "
           + "	pa.part_asset, "
           + "	pa.part_name, "
           + "	pa.part_photo "
           + "FROM "
           + "	part_account pa "
           + "WHERE pa.dr=0 AND pa.id=" + id;
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 根据ID查询配件信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryPartById(string id)
        {
            try
            {
                SqlDataAdapter sda;
                //string sql = string.Format("SELECT	rp.id,	rp.plan_asset,	ea.asset,ea.eqname,d.departname,	rp.[start_date],	rp.over_time,	rp.stop_time,	rp.target_department,	rp.source_department,	rp.principal,	rp.memo,	rp.level_id FROM	repair_plan rp LEFT JOIN eq_account ea ON rp.eq_id=ea.id LEFT JOIN department d ON ea.department=d.id WHERE rp.dr=0 AND rp.id=" + id);
                string sql = "SELECT "
           + "	pa.part_asset, "
           + "	pa.part_name, "
           + "	pa.material, "
           + "	pa.part_weight, "
           + "	pa.[standard], "
           + "	pa.part_photo, "
           + "	pa.part_3d "
           + "FROM "
           + "	part_account pa "
           + "WHERE pa.id=" + id;
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 删除制定ID的配件信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deletePartById(string id)
        {
            int result = 0;
            try
            {
                string sql = string.Format("UPDATE part_account SET dr = 1 WHERE id=" + id);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询是否已经存在某设备所对应的配件
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public bool hasPartForAccount(string eqId)
        {
            bool flag = false;
            int result = 0;
            try
            {
                //string sql = string.Format("SELECT COUNT(*) FROM repair m WHERE m.dr=0 AND m.plan_id=" + planId);
                string sql = "SELECT COUNT(*)  "
           + "FROM part_account pa  "
           + "WHERE pa.dr=0 AND pa.eq_id="+eqId;
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(sql, conn);
                    conn.Open();
                    result = (int)command.ExecuteScalar();
                    conn.Close();
                    conn.Dispose();
                }
                if (result > 0)
                {
                    flag = true;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return flag;
        }
        /// <summary>
        /// 查找全部故障信息
        /// </summary>
        /// <returns></returns>
        public DataSet queryFault()
        {
            try
            {
                SqlDataAdapter sda;

                //string sql = string.Format("SELECT id,asset,eqname,photo FROM eq_account WHERE dr=0");
                //string sql = string.Format("SELECT	ea.id, ea.asset, ea.eqname, ea.photo,	ea.isoff,ea.model,	ea.specification,	d.departname,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	es.status_name,	et.[type_name],	ea.[address],	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr  FROM	eq_account ea LEFT JOIN department d ON ea.department=d.id LEFT JOIN eq_status es ON ea.[status]=es.id LEFT JOIN eq_type et ON ea.[type]=et.id WHERE  ea.isoff=0 AND ea.dr=0");
                string sql = "SELECT "
                   + "	f.id, "
                   + "	ea.asset, "
                   + "	ea.eqname, "
                   + "	d.departname, "
                   + "	f.part_name, "
                   + "	fl.level_name, "
                   + "	f.fault_date, "
                   + "	f.repair_date, "
                   + "	f.repairover_date, "
                   + "	f.fault_process, "
                   + "	f.fault_reason, "
                   + "	f.countermeasure "
                   + "FROM "
                   + "	fault f "
                   + "	LEFT JOIN eq_account ea ON f.eq_id=ea.id "
                   + "	LEFT JOIN department d ON ea.department=d.id "
                   + "	LEFT JOIN fault_level fl ON f.fault_level=fl.id "
                   + "WHERE f.dr=0 ORDER BY f.ts DESC";
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 查找指定ID故障信息(含图片信息)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryFaultByIdIncludeImage(string id)
        {
            try
            {
                SqlDataAdapter sda;

                //string sql = string.Format("SELECT id,asset,eqname,photo FROM eq_account WHERE dr=0");
                //string sql = string.Format("SELECT	ea.id, ea.asset, ea.eqname, ea.photo,	ea.isoff,ea.model,	ea.specification,	d.departname,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	es.status_name,	et.[type_name],	ea.[address],	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr  FROM	eq_account ea LEFT JOIN department d ON ea.department=d.id LEFT JOIN eq_status es ON ea.[status]=es.id LEFT JOIN eq_type et ON ea.[type]=et.id WHERE  ea.isoff=0 AND ea.dr=0");
                string sql = "SELECT "
                   + "	f.id, "
                   + "	ea.asset, "
                   + "	ea.eqname, "
                   + "	d.departname, "
                   + "	f.part_name, "
                   + "	fl.level_name, "
                   + "	f.fault_date, "
                   + "	f.repair_date, "
                   + "	f.repairover_date, "
                   + "	f.fault_process, "
                   + "	f.fault_reason, "
                   + "	f.countermeasure, "
                   + "	f.fault_photo "
                   + "FROM "
                   + "	fault f "
                   + "	LEFT JOIN eq_account ea ON f.eq_id=ea.id "
                   + "	LEFT JOIN department d ON ea.department=d.id "
                   + "	LEFT JOIN fault_level fl ON f.fault_level=fl.id "
                   + "WHERE f.id=" + id;
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 查找指定ID故障信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryFaultById(string id)
        {
            try
            {
                SqlDataAdapter sda;

                //string sql = string.Format("SELECT id,asset,eqname,photo FROM eq_account WHERE dr=0");
                //string sql = string.Format("SELECT	ea.id, ea.asset, ea.eqname, ea.photo,	ea.isoff,ea.model,	ea.specification,	d.departname,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	es.status_name,	et.[type_name],	ea.[address],	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr  FROM	eq_account ea LEFT JOIN department d ON ea.department=d.id LEFT JOIN eq_status es ON ea.[status]=es.id LEFT JOIN eq_type et ON ea.[type]=et.id WHERE  ea.isoff=0 AND ea.dr=0");
                string sql = "SELECT "
                   + "	f.id, "
                   + "	ea.asset, "
                   + "	ea.eqname, "
                   + "	d.departname, "
                   + "	f.part_name, "
                   + "	f.fault_level, "
                   + "	f.fault_date, "
                   + "	f.repair_date, "
                   + "	f.repairover_date, "
                   + "	f.fault_process, "
                   + "	f.fault_reason, "
                   + "	f.countermeasure, "
                   + "	f.fault_photo "
                   + "FROM "
                   + "	fault f "
                   + "	LEFT JOIN eq_account ea ON f.eq_id=ea.id "
                   + "	LEFT JOIN department d ON ea.department=d.id "
                   + "	LEFT JOIN fault_level fl ON f.fault_level=fl.id "
                   + "WHERE f.id=" + id;
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 删除制定ID的故障信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteFaultById(string id)
        {
            int result = 0;
            try
            {
                string sql = string.Format("UPDATE fault SET dr = 1 WHERE id=" + id);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        












    }

}
