using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Util
{
    /// <summary>
    /// 对exe.Config文件中的appSettings段进行读写配置操作
    /// 注意：
    /// 1.调试时，写操作将写在vhost.exe.config文件中
    /// 2.先添加对system.configuration.dll程序集的引用
    /// </summary>
    public class ConfigAppSettings
    {
        /// <summary>
        /// 写入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// 
        public static void SetValue(string key, string value)
        {
            //增加的内容写在appSettings段下 <add key="RegCode" value="0"/>
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件 
        }

        /// <summary>
        /// 读取指定key的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
                return "";
            else
                return config.AppSettings.Settings[key].Value;
        }
        /// <summary>
        /// 读取数据库接口的dbowner值
        /// </summary>
        /// <returns></returns>
        public static string getDBOwner()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["dbowner"] == null)
            {
                return "";
            }
            else
            {
                return config.AppSettings.Settings["dbowner"].Value;
            }
        }
        /// <summary>
        /// 读取数据库接口的ConnectionString值
        /// </summary>
        /// <returns></returns>
        public static string getDBConnString()
        {
            //Data Source=127.0.0.1;Initial Catalog=cems;User ID=sa;Password=ziyu5946
            string dbConnString = "";
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["ipaddress"] == null ||
                config.AppSettings.Settings["basename"] == null ||
                config.AppSettings.Settings["user"] == null ||
                config.AppSettings.Settings["password"] == null)
            {
                return dbConnString;
            }
            else
            {
                dbConnString = "Data Source=" + config.AppSettings.Settings["ipaddress"].Value +
                    ";Initial Catalog=" + config.AppSettings.Settings["basename"].Value +
                    ";User ID=" + config.AppSettings.Settings["user"].Value +
                    ";Password=" + config.AppSettings.Settings["password"].Value;
                return dbConnString;
            }
        }

    }
}
