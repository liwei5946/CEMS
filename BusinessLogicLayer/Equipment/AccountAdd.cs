using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Equipment;
using log4net;

namespace BusinessLogicLayer.Equipment
{
    public class AccountAdd
    {
        ILog log = log4net.LogManager.GetLogger(typeof(AccountAdd));
        AccountAddService aas = new AccountAddService();
        /// <summary>
        /// 查找设备类型combobox数据
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_EquipmentType()
        {
            return aas.CreateDataSet_EquipmentType();
        }
        /// <summary>
        /// 查找部门combobox数据
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_Department()
        {
            return aas.CreateDataSet_Department();
        }
        /// <summary>
        /// 查找设备状态combobox数据
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_Status()
        {
            return aas.CreateDataSet_Status();
        }
        /// <summary>
        /// 获取上传图片文件的byte序列
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public byte[] getFileBytes(string fullPath)
        {
            log.Debug(fullPath);
            FileStream fs = new FileStream(fullPath, FileMode.Open);
            byte[] imageBytes = new byte[fs.Length];
            BinaryReader br = new BinaryReader(fs);
            imageBytes = br.ReadBytes(Convert.ToInt32(fs.Length));
            br.Close();
            fs.Close();
            return imageBytes;
        }

        public bool addAccount(bool isoff, string asset, string eqname, string model, string specification, int department, string weight, string brand,
            string manufacturer, string supplier, string manu_date, string produ_date, string filing_date, float value, int count, int electromotor, float power,
            int status, int type, string address, byte[] photo, byte[] three_dimensional)
        {
            return aas.addAccount(isoff, asset, eqname, model, specification, department, weight, brand, manufacturer, supplier, manu_date, produ_date, filing_date, value, count, electromotor, power, status, type, address, photo, three_dimensional);
        }

    }
}
