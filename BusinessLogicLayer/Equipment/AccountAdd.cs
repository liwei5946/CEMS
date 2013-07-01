using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
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
        /// 创建repair_level的DataSet
        /// 查找repair_level表
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_RepairLevel()
        {
            return aas.CreateDataSet_RepairLevel();
        }
        /// <summary>
        /// 创建maintain_level的DataSet
        /// 查找maintain_level表
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_MaintainLevel()
        {
            return aas.CreateDataSet_MaintainLevel();
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
        public bool addAccount(bool isoff, string asset, string eqname, string model, string specification, int department, string weight, string brand,
            string manufacturer, string supplier, string manu_date, string produ_date, string filing_date, float value, int count, int electromotor, float power,
            int status, int type, string address, byte[] photo, byte[] three_dimensional)
        {
            return aas.addAccount(isoff, asset, eqname, model, specification, department, weight, brand, manufacturer, supplier, manu_date, produ_date, filing_date, value, count, electromotor, power, status, type, address, photo, three_dimensional);
        }
        /// <summary>
        /// 修改台帐信息
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
        public bool updateAccount( string asset, string eqname, string model, string specification, int department, string weight, string brand,
    string manufacturer, string supplier, string manu_date, string produ_date, string filing_date, float value, int count, int electromotor, float power,
    int status, int type, string address, byte[] photo, byte[] three_dimensional, string id)
        {
            return aas.updateAccount( asset, eqname, model, specification, department, weight, brand, manufacturer, supplier, manu_date, produ_date, filing_date, value, count, electromotor, power, status, type, address, photo, three_dimensional,id);
        }

    }
}
