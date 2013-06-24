using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Util;
using log4net;

namespace DataAccessLayer.Equipment
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
                string sql = string.Format("SELECT * FROM department");
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
                string sql = string.Format("SELECT * FROM eq_type");
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
        /// </summary>
        /// <returns></returns>
        public DataSet queryAccount()
        {
            try
            {
                SqlDataAdapter sda;
                
                //string sql = string.Format("SELECT id,asset,eqname,photo FROM eq_account WHERE dr=0");
                string sql = string.Format("SELECT	ea.id, ea.asset, ea.eqname, ea.photo,	ea.isoff,ea.model,	ea.specification,	d.departname,	ea.[weight],	ea.brand,	ea.manufacturer,	ea.supplier,	ea.manu_date,	ea.produ_date,	ea.filing_date,	ea.[value],	ea.[count],	ea.electromotor,	ea.[power],	es.status_name,	et.[type_name],	ea.[address],	ea.three_dimensional,	ea.parts,	ea.ts,	ea.dr  FROM	eq_account ea LEFT JOIN department d ON ea.department=d.id LEFT JOIN eq_status es ON ea.[status]=es.id LEFT JOIN eq_type et ON ea.[type]=et.id WHERE  ea.isoff=0 AND ea.dr=0");
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
    }

}
