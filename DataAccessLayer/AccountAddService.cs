using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Util;
using log4net;

namespace DataAccessLayer
{
    public class AccountAddService
    {
        private DataSet ds;
        ILog log = log4net.LogManager.GetLogger(typeof(AccountService));
        #region Private Members
        //从配置文件中读取数据库连接字符串
        //private readonly string connString = ConfigurationManager.ConnectionStrings["CEMSConnectionString"].ToString();
        //private readonly string dboOwner = ConfigurationManager.ConnectionStrings["DataBaseOwner"].ToString();
        private readonly string connString = ConfigAppSettings.getDBConnString();
        private readonly string dboOwner = ConfigAppSettings.getDBOwner();
        #endregion
        /// <summary>
        /// 创建eq_type的DataSet
        /// 查找eq_type表
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_EquipmentType()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT * FROM eq_type WHERE dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 创建故障模式表的DataSet
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataSet CreateDataSet_FaultLevel()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT * FROM fault_level WHERE dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 创建department的DataSet
        /// 查找department表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataSet CreateDataSet_Department()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT * FROM department  WHERE dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 创建设备状态的DataSet
        /// 查找eq_status表
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataSet CreateDataSet_Status()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT * FROM eq_status WHERE dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 创建repair_level的DataSet
        /// 查找repair_level表
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_RepairLevel()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT * FROM repair_level WHERE dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
        }
        /// <summary>
        /// 创建maintain_level的DataSet
        /// 查找maintain_level表
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet_MaintainLevel()
        {
            try
            {
                SqlDataAdapter sda;
                string sql = string.Format("SELECT * FROM maintain_level WHERE dr=0");
                log.Debug(sql);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    sda = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return ds;
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
        public bool addAccount(bool isoff, string asset, string eqname,string model,string specification,int department,string weight,string brand,
            string manufacturer,string supplier,string manu_date,string produ_date,string filing_date,float value,int count,int electromotor,float power,
            int status,int type,string address,byte[] photo,byte[] three_dimensional)
        {
            int resault = 0;
            string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) VALUES (@isoff,@asset,@eqname,@model,@specification,@department,@weight,@brand,@manufacturer,@supplier,@manu_date,@produ_date,@filing_date,@value,@count,@electromotor,@power,@status,@type,@address,@photo,@three_dimensional)");
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@isoff", SqlDbType.Bit));
                    mycom.Parameters.Add(new SqlParameter("@asset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@eqname", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@model", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@specification", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@weight", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@brand", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@manufacturer", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@supplier", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@manu_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@produ_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@filing_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@value", SqlDbType.Float));
                    mycom.Parameters.Add(new SqlParameter("@count", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@electromotor", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@power", SqlDbType.Float));
                    mycom.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@type", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar,50));
                   // mycom.Parameters.Add(new SqlParameter("@parts", SqlDbType.Bit));
                    mycom.Parameters.Add(new SqlParameter("@photo", SqlDbType.Image, photo.Length));
                    mycom.Parameters.Add(new SqlParameter("@three_dimensional", SqlDbType.Image, three_dimensional.Length));

                    //给参数赋值
                    mycom.Parameters["@isoff"].Value = isoff;
                    mycom.Parameters["@asset"].Value = asset;
                    mycom.Parameters["@eqname"].Value = eqname;
                    mycom.Parameters["@model"].Value = model;
                    mycom.Parameters["@specification"].Value = specification;
                    mycom.Parameters["@department"].Value = department;
                    mycom.Parameters["@weight"].Value = weight;
                    mycom.Parameters["@brand"].Value = brand;
                    mycom.Parameters["@manufacturer"].Value = manufacturer;
                    mycom.Parameters["@supplier"].Value = supplier;
                    mycom.Parameters["@manu_date"].Value = manu_date;
                    mycom.Parameters["@produ_date"].Value = produ_date;
                    mycom.Parameters["@filing_date"].Value = filing_date;
                    mycom.Parameters["@value"].Value = value;
                    mycom.Parameters["@count"].Value = count;
                    mycom.Parameters["@electromotor"].Value = electromotor;
                    mycom.Parameters["@power"].Value = power;
                    mycom.Parameters["@status"].Value = status;
                    mycom.Parameters["@type"].Value = type;
                    mycom.Parameters["@address"].Value = address;
                    mycom.Parameters["@photo"].Value = photo;
                    mycom.Parameters["@three_dimensional"].Value = three_dimensional;
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
        public bool addPart(string eq_id,	string part_asset,	string part_name,	string material,	string part_weight,	bool standard,    byte[] part_photo,	byte[] part_3d)
        {
            int resault = 0;
            //string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) VALUES (@isoff,@asset,@eqname,@model,@specification,@department,@weight,@brand,@manufacturer,@supplier,@manu_date,@produ_date,@filing_date,@value,@count,@electromotor,@power,@status,@type,@address,@photo,@three_dimensional)");
            string sql = "INSERT INTO part_account "
           + "( "
           + "	eq_id, "
           + "	part_asset, "
           + "	part_name, "
           + "	material, "
           + "	part_weight, "
           + "	[standard], "
           + "	part_photo, "
           + "	part_3d "
           + ") "
           + "VALUES "
           + "( "
           + "	@eq_id, "
           + "	@part_asset, "
           + "	@part_name, "
           + "	@material, "
           + "	@part_weight, "
           + "	@standard, "
           + "	@part_photo, "
           + "	@part_3d "
           + ")";
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@eq_id", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@part_asset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@part_name", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@material", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@part_weight", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@standard", SqlDbType.Bit));
                    mycom.Parameters.Add(new SqlParameter("@part_photo", SqlDbType.Image, part_photo.Length));
                    mycom.Parameters.Add(new SqlParameter("@part_3d", SqlDbType.Image, part_3d.Length));

                    //给参数赋值
                    mycom.Parameters["@eq_id"].Value = eq_id;
                    mycom.Parameters["@part_asset"].Value = part_asset;
                    mycom.Parameters["@part_name"].Value = part_name;
                    mycom.Parameters["@material"].Value = material;
                    mycom.Parameters["@part_weight"].Value = part_weight;
                    mycom.Parameters["@standard"].Value = standard;
                    mycom.Parameters["@part_photo"].Value = part_photo;
                    mycom.Parameters["@part_3d"].Value = part_3d;
                    
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
        public bool updateAccount(string asset, string eqname, string model, string specification, int department, string weight, string brand,
    string manufacturer, string supplier, string manu_date, string produ_date, string filing_date, float value, int count, int electromotor, float power,
    int status, int type, string address, byte[] photo, byte[] three_dimensional, string id)
        {
            int resault = 0;
            //string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) 
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    //VALUES (,,,,,,,,,,,,,,,,,,,)");
            string sql = string.Format("UPDATE eq_account SET	asset = @asset,	eqname = @eqname,	model = @model,	specification = @specification,	department = @department,	[weight] = @weight,	brand = @brand,	manufacturer = @manufacturer,	supplier = @supplier,	manu_date = @manu_date,	produ_date = @produ_date,	filing_date = @filing_date,	[value] = @value,	[count] = @count,	electromotor = @electromotor,	[power] = @power,	[status] = @status,	[type] = @type,	[address] = @address,	photo = @photo,	three_dimensional = @three_dimensional WHERE id=" + id);
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    //mycom.Parameters.Add(new SqlParameter("@isoff", SqlDbType.Bit));
                    mycom.Parameters.Add(new SqlParameter("@asset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@eqname", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@model", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@specification", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@department", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@weight", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@brand", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@manufacturer", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@supplier", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@manu_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@produ_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@filing_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@value", SqlDbType.Float));
                    mycom.Parameters.Add(new SqlParameter("@count", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@electromotor", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@power", SqlDbType.Float));
                    mycom.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@type", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@address", SqlDbType.NVarChar, 50));
                    // mycom.Parameters.Add(new SqlParameter("@parts", SqlDbType.Bit));
                    mycom.Parameters.Add(new SqlParameter("@photo", SqlDbType.Image, photo.Length));
                    mycom.Parameters.Add(new SqlParameter("@three_dimensional", SqlDbType.Image, three_dimensional.Length));

                    //给参数赋值
                    //mycom.Parameters["@isoff"].Value = isoff;
                    mycom.Parameters["@asset"].Value = asset;
                    mycom.Parameters["@eqname"].Value = eqname;
                    mycom.Parameters["@model"].Value = model;
                    mycom.Parameters["@specification"].Value = specification;
                    mycom.Parameters["@department"].Value = department;
                    mycom.Parameters["@weight"].Value = weight;
                    mycom.Parameters["@brand"].Value = brand;
                    mycom.Parameters["@manufacturer"].Value = manufacturer;
                    mycom.Parameters["@supplier"].Value = supplier;
                    mycom.Parameters["@manu_date"].Value = manu_date;
                    mycom.Parameters["@produ_date"].Value = produ_date;
                    mycom.Parameters["@filing_date"].Value = filing_date;
                    mycom.Parameters["@value"].Value = value;
                    mycom.Parameters["@count"].Value = count;
                    mycom.Parameters["@electromotor"].Value = electromotor;
                    mycom.Parameters["@power"].Value = power;
                    mycom.Parameters["@status"].Value = status;
                    mycom.Parameters["@type"].Value = type;
                    mycom.Parameters["@address"].Value = address;
                    mycom.Parameters["@photo"].Value = photo;
                    mycom.Parameters["@three_dimensional"].Value = three_dimensional;
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
            int resault = 0;
            //string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) 
            //VALUES (,,,,,,,,,,,,,,,,,,,)");
            //string sql = string.Format("UPDATE eq_account SET	asset = @asset,	eqname = @eqname,	model = @model,	specification = @specification,	department = @department,	[weight] = @weight,	brand = @brand,	manufacturer = @manufacturer,	supplier = @supplier,	manu_date = @manu_date,	produ_date = @produ_date,	filing_date = @filing_date,	[value] = @value,	[count] = @count,	electromotor = @electromotor,	[power] = @power,	[status] = @status,	[type] = @type,	[address] = @address,	photo = @photo,	three_dimensional = @three_dimensional WHERE id=" + id);
            string sql = "UPDATE part_account "
           + "SET "
           + "	part_asset = @part_asset, "
           + "	part_name = @part_name, "
           + "	material = @material, "
           + "	part_weight = @part_weight, "
           + "	[standard] = @standard, "
           + "	part_photo = @part_photo, "
           + "	part_3d = @part_3d "
           + "WHERE id=" + id;
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@part_asset", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@part_name", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@material", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@part_weight", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@standard", SqlDbType.Bit));
                    mycom.Parameters.Add(new SqlParameter("@part_photo", SqlDbType.Image, part_photo.Length));
                    mycom.Parameters.Add(new SqlParameter("@part_3d", SqlDbType.Image, part_3d.Length));

                    //给参数赋值
                    mycom.Parameters["@part_asset"].Value = part_asset;
                    mycom.Parameters["@part_name"].Value = part_name;
                    mycom.Parameters["@material"].Value = material;
                    mycom.Parameters["@part_weight"].Value = part_weight;
                    mycom.Parameters["@standard"].Value = standard;
                    mycom.Parameters["@part_photo"].Value = part_photo;
                    mycom.Parameters["@part_3d"].Value = part_3d;

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
	      string  part_name,
	      string  fault_level,
	      string  fault_date,
	      string  repair_date,
	      string  repairover_date,
	      string  fault_process,
	      string  fault_reason,
	     string   countermeasure,
	      byte[]  fault_photo
            )
        {
            int resault = 0;
            //string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) VALUES (@isoff,@asset,@eqname,@model,@specification,@department,@weight,@brand,@manufacturer,@supplier,@manu_date,@produ_date,@filing_date,@value,@count,@electromotor,@power,@status,@type,@address,@photo,@three_dimensional)");
            string sql = "INSERT INTO fault "
           + "( "
           + "	eq_id, "
           + "	part_name, "
           + "	fault_level, "
           + "	fault_date, "
           + "	repair_date, "
           + "	repairover_date, "
           + "	fault_process, "
           + "	fault_reason, "
           + "	countermeasure, "
           + "	fault_photo "
           + ") "
           + "VALUES "
           + "( "
           + "	@eq_id, "
           + "	@part_name, "
           + "	@fault_level, "
           + "	@fault_date, "
           + "	@repair_date, "
           + "	@repairover_date, "
           + "	@fault_process, "
           + "	@fault_reason, "
           + "	@countermeasure, "
           + "	@fault_photo "
           + ")";
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@eq_id", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@part_name", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@fault_level", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@fault_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@repair_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@repairover_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@fault_process", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@fault_reason", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@countermeasure", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@fault_photo", SqlDbType.Image, fault_photo.Length));


                    //给参数赋值
                    mycom.Parameters["@eq_id"].Value = eq_id;
                    mycom.Parameters["@part_name"].Value = part_name;
                    mycom.Parameters["@fault_level"].Value = fault_level;
                    mycom.Parameters["@fault_date"].Value = fault_date;
                    mycom.Parameters["@repair_date"].Value = repair_date;
                    mycom.Parameters["@repairover_date"].Value = repairover_date;
                    mycom.Parameters["@fault_process"].Value = fault_process;
                    mycom.Parameters["@fault_reason"].Value = fault_reason;
                    mycom.Parameters["@countermeasure"].Value = countermeasure;
                    mycom.Parameters["@fault_photo"].Value = fault_photo;
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
	         string   fault_level,
	         string   fault_date ,
	         string   repair_date ,
	         string   repairover_date ,
	         string   fault_process ,
	          string  fault_reason ,
	         string   countermeasure ,
	        byte[] fault_photo , 
                    string id)
        {
            int resault = 0;
            //string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) 
            //VALUES (,,,,,,,,,,,,,,,,,,,)");
            //string sql = string.Format("UPDATE eq_account SET	asset = @asset,	eqname = @eqname,	model = @model,	specification = @specification,	department = @department,	[weight] = @weight,	brand = @brand,	manufacturer = @manufacturer,	supplier = @supplier,	manu_date = @manu_date,	produ_date = @produ_date,	filing_date = @filing_date,	[value] = @value,	[count] = @count,	electromotor = @electromotor,	[power] = @power,	[status] = @status,	[type] = @type,	[address] = @address,	photo = @photo,	three_dimensional = @three_dimensional WHERE id=" + id);
            string sql = "UPDATE fault "
               + "SET "
               + "	part_name = @part_name, "
               + "	fault_level = @fault_level, "
               + "	fault_date = @fault_date, "
               + "	repair_date = @repair_date, "
               + "	repairover_date = @repairover_date, "
               + "	fault_process = @fault_process, "
               + "	fault_reason = @fault_reason, "
               + "	countermeasure = @countermeasure, "
               + "	fault_photo = @fault_photo "
               + "WHERE id=" + id;
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@part_name", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@fault_level", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@fault_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@repair_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@repairover_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@fault_process", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@fault_reason", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@countermeasure", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@fault_photo", SqlDbType.Image, fault_photo.Length));

                    //给参数赋值
                    mycom.Parameters["@part_name"].Value = part_name;
                    mycom.Parameters["@fault_level"].Value = fault_level;
                    mycom.Parameters["@fault_date"].Value = fault_date;
                    mycom.Parameters["@repair_date"].Value = repair_date;
                    mycom.Parameters["@repairover_date"].Value = repairover_date;
                    mycom.Parameters["@fault_process"].Value = fault_process;
                    mycom.Parameters["@fault_reason"].Value = fault_reason;
                    mycom.Parameters["@countermeasure"].Value = countermeasure;
                    mycom.Parameters["@fault_photo"].Value = fault_photo;

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
          string  eq_name,
	       string part_name,
	       string fault_level,
	       string fault_process,
	       string fault_reason,
           string countermeasure)
        {
            int resault = 0;
            //string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) VALUES (@isoff,@asset,@eqname,@model,@specification,@department,@weight,@brand,@manufacturer,@supplier,@manu_date,@produ_date,@filing_date,@value,@count,@electromotor,@power,@status,@type,@address,@photo,@three_dimensional)");
            string sql = "INSERT INTO fault_knowledge "
               + "( "
               + "	eq_name, "
               + "	part_name, "
               + "	fault_level, "
               + "	fault_process, "
               + "	fault_reason, "
               + "	countermeasure "
               + ") "
               + "VALUES "
               + "( "
               + "	@eq_name, "
               + "	@part_name, "
               + "	@fault_level, "
               + "	@fault_process, "
               + "	@fault_reason, "
               + "	@countermeasure "
               + ")";
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@eq_name", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@part_name", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@fault_level", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@fault_process", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@fault_reason", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@countermeasure", SqlDbType.NText));


                    //给参数赋值
                    mycom.Parameters["@eq_name"].Value = eq_name;
                    mycom.Parameters["@part_name"].Value = part_name;
                    mycom.Parameters["@fault_level"].Value = fault_level;
                    mycom.Parameters["@fault_process"].Value = fault_process;
                    mycom.Parameters["@fault_reason"].Value = fault_reason;
                    mycom.Parameters["@countermeasure"].Value = countermeasure;


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
	            string    part_name,
	            string    fault_level,
	            string    fault_process,
	            string    fault_reason,
                string countermeasure,
                    string id)
        {
            int resault = 0;
            //string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) 
            //VALUES (,,,,,,,,,,,,,,,,,,,)");
            //string sql = string.Format("UPDATE eq_account SET	asset = @asset,	eqname = @eqname,	model = @model,	specification = @specification,	department = @department,	[weight] = @weight,	brand = @brand,	manufacturer = @manufacturer,	supplier = @supplier,	manu_date = @manu_date,	produ_date = @produ_date,	filing_date = @filing_date,	[value] = @value,	[count] = @count,	electromotor = @electromotor,	[power] = @power,	[status] = @status,	[type] = @type,	[address] = @address,	photo = @photo,	three_dimensional = @three_dimensional WHERE id=" + id);
            string sql = "UPDATE fault_knowledge "
               + "SET "
               + "	eq_name = @eq_name, "
               + "	part_name = @part_name, "
               + "	fault_level = @fault_level, "
               + "	fault_process = @fault_process, "
               + "	fault_reason = @fault_reason, "
               + "	countermeasure = @countermeasure "
               + "WHERE id=" + id;
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);

                    //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@eq_name", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@part_name", SqlDbType.NVarChar, 50));
                    mycom.Parameters.Add(new SqlParameter("@fault_level", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@fault_process", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@fault_reason", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@countermeasure", SqlDbType.NText));

                    //给参数赋值
                    mycom.Parameters["@eq_name"].Value = eq_name;
                    mycom.Parameters["@part_name"].Value = part_name;
                    mycom.Parameters["@fault_level"].Value = fault_level;
                    mycom.Parameters["@fault_process"].Value = fault_process;
                    mycom.Parameters["@fault_reason"].Value = fault_reason;
                    mycom.Parameters["@countermeasure"].Value = countermeasure;

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
            int resault = 0;
            //string sql = string.Format("INSERT INTO eq_account (isoff,asset,eqname,model,specification,department,weight,brand,manufacturer,supplier,manu_date,produ_date,filing_date,value,count,electromotor,power,status,type,address,photo,three_dimensional) VALUES (@isoff,@asset,@eqname,@model,@specification,@department,@weight,@brand,@manufacturer,@supplier,@manu_date,@produ_date,@filing_date,@value,@count,@electromotor,@power,@status,@type,@address,@photo,@three_dimensional)");
            string sql = "INSERT INTO trouble "
               + "( "
               + "	eq_id, "
               + "	trouble_date, "
               + "	process, "
               + "	reason, "
               + "	lose, "
               + "	solve, "
               + "	photo "
               + ") "
               + "VALUES "
               + "( "
               + "	@eq_id, "
               + "	@trouble_date, "
               + "	@process, "
               + "	@reason, "
               + "	@lose, "
               + "	@solve, "
               + "	@photo "
               + ")";
            log.Debug(sql);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand mycom = new SqlCommand(sql, conn);
                      //添加参数 
                    mycom.Parameters.Add(new SqlParameter("@eq_id", SqlDbType.Int));
                    mycom.Parameters.Add(new SqlParameter("@trouble_date", SqlDbType.DateTime));
                    mycom.Parameters.Add(new SqlParameter("@process", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@reason", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@lose", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@solve", SqlDbType.NText));
                    mycom.Parameters.Add(new SqlParameter("@photo", SqlDbType.Image, photo.Length));
                    //给参数赋值
                    mycom.Parameters["@eq_id"].Value = eq_id;
                    mycom.Parameters["@trouble_date"].Value = trouble_date;
                    mycom.Parameters["@process"].Value = process;
                    mycom.Parameters["@reason"].Value = reason;
                    mycom.Parameters["@lose"].Value = lose;
                    mycom.Parameters["@solve"].Value = solve;
                    mycom.Parameters["@photo"].Value = photo;

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








    }
}
