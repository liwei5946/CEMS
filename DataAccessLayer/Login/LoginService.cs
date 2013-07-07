﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using System.Configuration;
using Util;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace DataAccessLayer.Login
{
    public class LoginService
    {
        ILog log = log4net.LogManager.GetLogger(typeof(LoginService));
        #region Private Members
        //从配置文件中读取数据库连接字符串
        //private readonly string connString = ConfigurationManager.ConnectionStrings["CEMSConnectionString"].ToString();
        //private readonly string dboOwner = ConfigurationManager.ConnectionStrings["DataBaseOwner"].ToString();
        private readonly string connString = ConfigAppSettings.getDBConnString();
        private readonly string dboOwner = ConfigAppSettings.getDBOwner();
        #endregion
        /// <summary>
        /// 判断能否登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool isLogin(string username, string password)
        {
            bool flag = false;
            int result = 0;
            log.Debug(dboOwner);
            log.Debug(connString);
            try
            {
                string sql = string.Format("SELECT COUNT(*) FROM sys_sys WHERE sys_sys.username='{0}' AND sys_sys.password='{1}'", username, password);
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
        /// 查询登录用户的权限
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>权限值</returns>
        public int getUserRight(string username)
        {
            int result = 0;//0代表普通用户，1代表管理员
            try
            {
                //SELECT sys_sys.userright FROM sys_sys WHERE sys_sys.username='liwei'
                string sql = string.Format("SELECT sys_sys.userright FROM sys_sys WHERE sys_sys.username='{0}'", username);
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(sql, conn);
                    conn.Open();
                    result = (int)command.ExecuteScalar();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return result;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool updatePasswordByUsername(string username, string password)
        {
            int resault = 0;
            //string sql = string.Format("UPDATE maintain SET	[start_date] = @start_date,	end_date = @end_date,	principal = @principal,	[status] = @status,	memo = @memo WHERE id=" + id);
            string sql = "UPDATE sys_sys "
               + "SET "
               + "	[password] = @password "
               + " WHERE username = @username ";
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50));
                    //给参数赋值
                    mycom.Parameters["@username"].Value = username;
                    mycom.Parameters["@password"].Value = password;
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
