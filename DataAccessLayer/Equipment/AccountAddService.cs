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
        /// <summary>
        /// 添加台帐
        /// </summary>
        /// <param name="isoff"></param>
        /// <param name="asset"></param>
        /// <param name="eqname"></param>
        /// <param name="model"></param>
        /// <param name="specification"></param>
        /// <param name="department"></param>
        /// <param name="weight"></param>
        /// <param name="brand"></param>
        /// <param name="manufacturer"></param>
        /// <param name="supplier"></param>
        /// <param name="manu_date"></param>
        /// <param name="produ_date"></param>
        /// <param name="filing_date"></param>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <param name="electromotor"></param>
        /// <param name="power"></param>
        /// <param name="status"></param>
        /// <param name="type"></param>
        /// <param name="address"></param>
        /// <param name="photo"></param>
        /// <param name="three_dimensional"></param>
        /// <returns></returns>
        public bool addAccount(bool isoff, string asset, string eqname,string model,string specification,int department,string weight,string brand,
            string manufacturer,string supplier,string manu_date,string produ_date,string filing_date,float value,int count,int electromotor,float power,
            int status,int type,string address,byte[] photo,byte[] three_dimensional)
        {
            int resault = 0;
            string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) VALUES (@isoff,@asset,@eqname,@model,@specification,@department,@weight,@brand,@manufacturer,@supplier,@manu_date,@produ_date,@filing_date,@value,@count,@electromotor,@power,@status,@type,@address,@photo,@three_dimensional)");
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@isoff", SqlDbType.Bit));
                    mycom.Parameters.Add(new SqlParameter("@asset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@eqname", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@model", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@specification", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@weight", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@brand", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@manufacturer", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@supplier", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@manu_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@produ_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@filing_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@value", SqlDbType.Float));
                    mycom.Parameters.Add(new SqlParameter("@count", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@electromotor", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@power", SqlDbType.Float));
                    mycom.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@type", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar,50));
                   // mycom.Parameters.Add(new SqlParameter("@parts", SqlDbType.Bit));
                    mycom.Parameters.Add(new SqlParameter("@photo", SqlDbType.Image, photo.Length));
                    mycom.Parameters.Add(new SqlParameter("@three_dimensional", SqlDbType.Image, three_dimensional.Length));

                    //给参数赋值
                    mycom.Parameters["@isoff"].Value = isoff;
                    mycom.Parameters["@asset"].Value = asset;
                    mycom.Parameters["@eqname"].Value = eqname;
                    mycom.Parameters["@model"].Value = model;
                    mycom.Parameters["@specification"].Value = specification;
                    mycom.Parameters["@department"].Value = department;
                    mycom.Parameters["@weight"].Value = weight;
                    mycom.Parameters["@brand"].Value = brand;
                    mycom.Parameters["@manufacturer"].Value = manufacturer;
                    mycom.Parameters["@supplier"].Value = supplier;
                    mycom.Parameters["@manu_date"].Value = manu_date;
                    mycom.Parameters["@produ_date"].Value = produ_date;
                    mycom.Parameters["@filing_date"].Value = filing_date;
                    mycom.Parameters["@value"].Value = value;
                    mycom.Parameters["@count"].Value = count;
                    mycom.Parameters["@electromotor"].Value = electromotor;
                    mycom.Parameters["@power"].Value = power;
                    mycom.Parameters["@status"].Value = status;
                    mycom.Parameters["@type"].Value = type;
                    mycom.Parameters["@address"].Value = address;
                    mycom.Parameters["@photo"].Value = photo;
                    mycom.Parameters["@three_dimensional"].Value = three_dimensional;
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
    }
}
