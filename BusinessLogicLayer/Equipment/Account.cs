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
        /// <summary>
        /// 根据id查询对应obj三维模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet queryAccountObjById(string id)
        {
            return acc.queryAccountObjById(id);
        }
        /// <summary>
        /// 删除制定ID的台帐信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean deleteAccountById(string id)
        {
            return acc.deleteAccountById(id);
        }
    }
}
