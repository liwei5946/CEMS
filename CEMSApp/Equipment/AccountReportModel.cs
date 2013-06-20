using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMSApp.Equipment
{
    class AccountReportModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int isoff;

        public int Isoff
        {
            get { return isoff; }
            set { isoff = value; }
        }
        private string asset;

        public string Asset
        {
            get { return asset; }
            set { asset = value; }
        }
        private string eqname;

        public string Eqname
        {
            get { return eqname; }
            set { eqname = value; }
        }
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private string specification;

        public string Specification
        {
            get { return specification; }
            set { specification = value; }
        }
        private string departname;

        public string Departname
        {
            get { return departname; }
            set { departname = value; }
        }


        private string weight;

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private string brand;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        private string manufacturer;

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }
        private string supplier;

        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }
        private DateTime manu_date;

        public DateTime Manu_date
        {
            get { return manu_date; }
            set { manu_date = value; }
        }
        private DateTime produ_date;

        public DateTime Produ_date
        {
            get { return produ_date; }
            set { produ_date = value; }
        }
        private DateTime filing_date;

        public DateTime Filing_date
        {
            get { return filing_date; }
            set { filing_date = value; }
        }
        private float value;

        public float Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int electromotor;

        public int Electromotor
        {
            get { return electromotor; }
            set { electromotor = value; }
        }
        private float power;

        public float Power
        {
            get { return power; }
            set { power = value; }
        }
        private string status_name;

        public string Status_name
        {
            get { return status_name; }
            set { status_name = value; }
        }


        private string type_name;

        public string Type_name
        {
            get { return type_name; }
            set { type_name = value; }
        }


        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string photo;

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        private string three_dimensional;

        public string Three_dimensional
        {
            get { return three_dimensional; }
            set { three_dimensional = value; }
        }
        private string parts;

        public string Parts
        {
            get { return parts; }
            set { parts = value; }
        }
        private DateTime ts;

        public DateTime Ts
        {
            get { return ts; }
            set { ts = value; }
        }
        private int dr;

        public int Dr
        {
            get { return dr; }
            set { dr = value; }
        }
        //private string myVar;
    }
}
