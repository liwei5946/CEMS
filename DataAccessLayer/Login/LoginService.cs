using System;
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
        private readonly string basename = ConfigAppSettings.GetValue("basename");
        //private readonly string ip = ConfigAppSettings.GetValue("ipaddress");
        //private readonly string username = ConfigAppSettings.GetValue("user");
        //private readonly string pwd = ConfigAppSettings.GetValue("password");
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
        /////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        // string ConnectionString = string.Format("Data Source=({0});User id={1};Password={2}; Initial Catalog=master",UserHelper.sql.servername,UserHelper.sql.uid,UserHelper.sql.password);
        //string ConnectionString = "Data Source=(local);User id=sa;Password=123; Initial Catalog=master";

        //string ConnectionString = string.Format("Data Source={0};Initial Catalog=master;Persist Security Info=True;User ID={1};Password={2}", UserHelper.sql.servername, UserHelper.sql.uid, UserHelper.sql.password);
        /// <summary>
        /// SQL操作语句/存储过程
        /// </summary>
        public string StrSQL;

        /// <summary>
        /// 实例化一个数据库连接对象
        /// </summary>
        private SqlConnection Conn;

        /// <summary>
        /// 实例化一个新的数据库操作对象Comm
        /// </summary>
        private SqlCommand Comm;

        /// <summary>
        /// 要操作的数据库名称
        /// </summary>
        public string DataBaseName;

        /// <summary>
        /// 数据库文件完整地址
        /// </summary>
        public string DataBase_MDF;

        /// <summary>
        /// 数据库日志文件完整地址
        /// </summary>
        public string DataBase_LDF;

        /// <summary>
        /// 备份文件名
        /// </summary>
        public string DataBaseOfBackupName;

        /// <summary>
        /// 备份文件路径
        /// </summary>
        public string DataBaseOfBackupPath;

        /// <summary>
        /// 执行创建/修改数据库和表的操作
        /// </summary>
        public void DataBaseAndTableControl()
        {
            try
            {
                Conn = new SqlConnection(connString);
                Conn.Open();

                Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = StrSQL;
                Comm.CommandType = CommandType.Text;
                Comm.ExecuteNonQuery();
                //MyMessageBox.Show("数据库操作成功！", "信息提示");
            }
            catch (Exception ex)
            {
                //MyMessageBox.Show(ex.Message, "信息提示");
                log.Error(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// 附加数据库
        /// </summary>
        public void AddDataBase()
        {
            try
            {
                Conn = new SqlConnection(connString);
                Conn.Open();
                Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = @"sp_attach_db";
                Comm.Parameters.Add(new SqlParameter("@dbname", SqlDbType.NVarChar));
                Comm.Parameters["@dbname"].Value = DataBaseName;
                Comm.Parameters.Add(new SqlParameter("@filename1", SqlDbType.NVarChar));
                Comm.Parameters["@filename1"].Value = DataBase_MDF;
                Comm.Parameters.Add(new SqlParameter("@filename2", SqlDbType.NVarChar));
                Comm.Parameters["@filename2"].Value = DataBase_LDF;
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.ExecuteNonQuery();

                //MyMessageBox.Show("附加数据库成功", "信息提示");
            }
            catch (Exception ex)
            {
                //MyMessageBox.Show(ex.Message, "信息提示");
                log.Error(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// 分离数据库
        /// </summary>
        public void DeleteDataBase()
        {
            try
            {
                Conn = new SqlConnection(connString);
                Conn.Open();

                Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = @"sp_detach_db";

                Comm.Parameters.Add(new SqlParameter(@"dbname", SqlDbType.NVarChar));
                Comm.Parameters[@"dbname"].Value = DataBaseName;

                Comm.CommandType = CommandType.StoredProcedure;
                Comm.ExecuteNonQuery();

                //MyMessageBox.Show("分离数据库成功", "信息提示");
            }
            catch (Exception ex)
            {
                //MyMessageBox.Show(ex.Message, "信息提示");
                log.Error(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        public bool BackupDataBase(string path,string filename)
        {
            bool flag = false;
            try
            {
                Conn = new SqlConnection(connString);
                Conn.Open();

                Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = "use master;backup database @dbname to disk = @backupname;";

                Comm.Parameters.Add(new SqlParameter("@dbname", SqlDbType.NVarChar));
                //Comm.Parameters["@dbname"].Value = DataBaseName;
                Comm.Parameters["@dbname"].Value = basename;
                Comm.Parameters.Add(new SqlParameter("@backupname", SqlDbType.NVarChar));
                //Comm.Parameters["@backupname"].Value = @DataBaseOfBackupPath + @DataBaseOfBackupName;
                Comm.Parameters["@backupname"].Value = path + filename;

                Comm.CommandType = CommandType.Text;
                Comm.ExecuteNonQuery();

                //MyMessageBox.Show("备份数据库成功", "信息提示");
                flag = true;
            }
            catch (Exception ex)
            {
                //MyMessageBox.Show(ex.Message, "信息提示");
                log.Error(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
            return flag;
        }

        /// <summary>
        /// 还原数据库
        /// </summary>
        public void ReplaceDataBase()
        {
            try
            {
                string BackupFile = @DataBaseOfBackupPath + @DataBaseOfBackupName;
                Conn = new SqlConnection(connString);
                Conn.Open();

                Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = "use master;restore database @DataBaseName From disk = @BackupFile with replace;";

                Comm.Parameters.Add(new SqlParameter(@"DataBaseName", SqlDbType.NVarChar));
                Comm.Parameters[@"DataBaseName"].Value = DataBaseName;
                Comm.Parameters.Add(new SqlParameter(@"BackupFile", SqlDbType.NVarChar));
                Comm.Parameters[@"BackupFile"].Value = BackupFile;

                Comm.CommandType = CommandType.Text;
                Comm.ExecuteNonQuery();

                //MyMessageBox.Show("还原数据库成功", "信息提示");
            }
            catch (Exception ex)
            {
                //MyMessageBox.Show(ex.Message, "信息提示");
                log.Error(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// 获取所以的数据库
        /// </summary>
        /// <returns>数据库</returns>
        public List<string> getDatabase()
        {

            List<string> datas = new List<string>();
            string sql = "select name from sysdatabases ";
            try
            {
                Conn = new SqlConnection(connString);
                Conn.Open();
                Comm = new SqlCommand(sql, Conn);
                SqlDataReader reader = Comm.ExecuteReader();
                while (reader.Read())
                {
                    datas.Add(reader[0].ToString());
                }
                reader.Close();

                Conn.Close();

            }
            catch (Exception)
            {
                throw new Exception("数据库连接失败，请检查信息是否正确。");
            }
            return datas;
        }




    }
}
