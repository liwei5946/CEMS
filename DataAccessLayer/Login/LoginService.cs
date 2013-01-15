using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace DataAccessLayer.Login
{
    public class LoginService
    {
        ILog log = log4net.LogManager.GetLogger(typeof(LoginService));
        #region Private Members
        //从配置文件中读取数据库连接字符串
        private readonly string connString = ConfigurationManager.ConnectionStrings["CEMSConnectionString"].ToString();
        private readonly string dboOwner = ConfigurationManager.ConnectionStrings["DataBaseOwner"].ToString();
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
    }
}
