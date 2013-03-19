using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer.Equipment;

namespace BusinessLogicLayer.Equipment
{
    public class Account
    {
        AccountService acc = new AccountService();
        /// <summary>
        /// 查找部门treeview数据
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_Department()
        {
            return acc.CreateDataSet_Department();
        }
        /// <summary>
        /// 查找设备类型treeview数据
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_EquipmentType()
        {
            return acc.CreateDataSet_EquipmentType();
        }
        /// <summary>
        /// 查找设备台帐信息
        /// </summary>
        /// <returns></returns>
        public DataSet queryAccount()
        {
            return acc.queryAccount();
        }
    }
}
