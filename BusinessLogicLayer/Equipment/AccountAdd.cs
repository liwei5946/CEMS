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
        /// <summary>
        /// 添加配件
        /// </summary>
        /// <param name="eq_id"></param>
        /// <param name="part_asset"></param>
        /// <param name="part_name"></param>
        /// <param name="material"></param>
        /// <param name="part_weight"></param>
        /// <param name="standard"></param>
        /// <param name="part_photo"></param>
        /// <param name="part_3d"></param>
        /// <returns></returns>
        public bool addPart(string eq_id, string part_asset, string part_name, string material, string part_weight, bool standard, byte[] part_photo, byte[] part_3d)
        {
            return aas.addPart(eq_id, part_asset, part_name, material, part_weight, standard, part_photo, part_3d);
        }
        /// <summary>
        /// 修改配件信息
        /// </summary>
        /// <param name="part_asset"></param>
        /// <param name="part_name"></param>
        /// <param name="material"></param>
        /// <param name="part_weight"></param>
        /// <param name="standard"></param>
        /// <param name="part_photo"></param>
        /// <param name="part_3d"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool updatePart(string part_asset,
    string part_name,
    string material,
    string part_weight,
    bool standard,
    byte[] part_photo,
    byte[] part_3d, string id)
        {
            return aas.updatePart(part_asset, part_name, material, part_weight, standard, part_photo, part_3d, id);
        }
        /// <summary>
        /// 创建故障模式表的DataSet
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataSet CreateDataSet_FaultLevel()
        {
            return aas.CreateDataSet_FaultLevel();
        }
        /// <summary>
        /// 添加故障信息
        /// </summary>
        /// <param name="eq_id"></param>
        /// <param name="part_name"></param>
        /// <param name="fault_level"></param>
        /// <param name="fault_date"></param>
        /// <param name="repair_date"></param>
        /// <param name="repairover_date"></param>
        /// <param name="fault_process"></param>
        /// <param name="fault_reason"></param>
        /// <param name="countermeasure"></param>
        /// <param name="fault_photo"></param>
        /// <returns></returns>
        public bool addFault(
           string eq_id,
          string part_name,
          string fault_level,
          string fault_date,
          string repair_date,
          string repairover_date,
          string fault_process,
          string fault_reason,
         string countermeasure,
          byte[] fault_photo
            )
        {
            return aas.addFault(eq_id, part_name, fault_level, fault_date, repair_date, repairover_date, fault_process, fault_reason, countermeasure, fault_photo);

        }
        /// <summary>
        /// 修改故障信息
        /// </summary>
        /// <param name="part_name"></param>
        /// <param name="fault_level"></param>
        /// <param name="fault_date"></param>
        /// <param name="repair_date"></param>
        /// <param name="repairover_date"></param>
        /// <param name="fault_process"></param>
        /// <param name="fault_reason"></param>
        /// <param name="countermeasure"></param>
        /// <param name="fault_photo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool updateFault(
              string part_name,
             string fault_level,
             string fault_date,
             string repair_date,
             string repairover_date,
             string fault_process,
              string fault_reason,
             string countermeasure,
            byte[] fault_photo,
                    string id)
        {
            return aas.updateFault(part_name, fault_level, fault_date, repair_date, repairover_date, fault_process, fault_reason, countermeasure, fault_photo, id);
        }
        /// <summary>
        /// 添加知识库
        /// </summary>
        /// <param name="eq_name"></param>
        /// <param name="part_name"></param>
        /// <param name="fault_level"></param>
        /// <param name="fault_process"></param>
        /// <param name="fault_reason"></param>
        /// <param name="countermeasure"></param>
        /// <returns></returns>
        public bool addKnowledge(
          string eq_name,
           string part_name,
           string fault_level,
           string fault_process,
           string fault_reason,
           string countermeasure)
        {
            return aas.addKnowledge(eq_name, part_name, fault_level, fault_process, fault_reason, countermeasure);
        }
        /// <summary>
        /// 修改知识库
        /// </summary>
        /// <param name="eq_name"></param>
        /// <param name="part_name"></param>
        /// <param name="fault_level"></param>
        /// <param name="fault_process"></param>
        /// <param name="fault_reason"></param>
        /// <param name="countermeasure"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool updateKnowledge(
              string eq_name,
                string part_name,
                string fault_level,
                string fault_process,
                string fault_reason,
                string countermeasure,
                    string id)
        {
            return aas.updateKnowledge(eq_name, part_name, fault_level, fault_process, fault_reason, countermeasure, id);
        }
        /// <summary>
        /// 添加事故信息
        /// </summary>
        /// <param name="eq_id"></param>
        /// <param name="trouble_date"></param>
        /// <param name="process"></param>
        /// <param name="reason"></param>
        /// <param name="lose"></param>
        /// <param name="solve"></param>
        /// <param name="photo"></param>
        /// <returns></returns>
        public bool addTrouble(
           string eq_id,
           string trouble_date,
           string process,
           string reason,
           string lose,
           string solve,
           byte[] photo
            )
        {
            return aas.addTrouble(eq_id, trouble_date, process, reason, lose, solve, photo);
        }
                /// <summary>
        /// 修改事故信息
        /// </summary>
        /// <param name="trouble_date"></param>
        /// <param name="process"></param>
        /// <param name="reason"></param>
        /// <param name="lose"></param>
        /// <param name="solve"></param>
        /// <param name="photo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool updateTrouble(
              string trouble_date,
                string process,
                  string reason,
                  string lose,
                  string solve,
                byte[] photo,
                    string id)
        {
            return aas.updateTrouble(trouble_date, process, reason, lose, solve, photo, id);
        }




    }
}
