using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Login;
using Util;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace BusinessLogicLayer.Login
{
    public class Login
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Login));
        LoginService ls = new LoginService();
        /// <summary>
        /// 判断是否登录成功
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool isLogin(string username, string password)
        {
            bool flag = false;
            flag = ls.isLogin(username, MD5Hashing.HashString(password));
            log.Debug("登录状态：" + flag);
            return flag;
        }
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int getUserRight(string username)
        {
            int result = 0;
            result = ls.getUserRight(username);
            log.Debug("用户" + username + "权限为：" + result);
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
            return ls.updatePasswordByUsername(username, MD5Hashing.HashString(password));
        }
        /// <summary>
        /// 备份数据库
        /// </summary>
        public bool BackupDataBase(string path, string filename)
        {
            return ls.BackupDataBase(path,filename);
        }
        /// <summary>
        /// 还原数据库
        /// </summary>
        public bool ReplaceDataBase(string fullFilename)
        {
            return ReplaceDataBase(fullFilename);
        }






    }
}
