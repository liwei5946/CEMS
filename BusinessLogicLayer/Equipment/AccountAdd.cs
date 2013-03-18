using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Equipment;

namespace BusinessLogicLayer.Equipment
{
    public class AccountAdd
    {
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

    }
}
