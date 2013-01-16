using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Login;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace BusinessLogicLayer.Login
{
    public class Login
    {
        ILog log = log4net.LogManager.GetLogger(typeof(Login));
        LoginService ls = new LoginService();
        public bool isLogin(string username, string password)
        {
            bool flag = false;
            flag = ls.isLogin(username, MD5Hashing.HashString(password));
            log.Debug("登录状态：" + flag);
            return flag;
        }
        public int getUserRight(string username)
        {
            int result = 0;
            result = ls.getUserRight(username);
            log.Debug("用户" + username + "权限为：" + result);
            return result;
        }
    }
}
