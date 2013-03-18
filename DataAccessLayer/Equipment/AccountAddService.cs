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
    public class AccountAddService
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
        /// 创建设备状态的DataSet
        /// 查找eq_status表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataSet CreateDataSet_Status()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT * FROM eq_status");
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
    }
}
