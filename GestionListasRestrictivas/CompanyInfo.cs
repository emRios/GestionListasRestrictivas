using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;

namespace OracleUDTSample
{
    /* CompanyInfo Class
    **   An instance of a CompanyInfo class represents an CompanyInfo object
    **   A custom type must implement INullable and IOracleCustomType interfaces
    */
    public class CompanyInfo : INullable, IOracleCustomType
    {
        private bool objectIsNull;

        [OracleObjectMappingAttribute("COMPANYID")]
        public string CompanyId { get; set; }

        [OracleObjectMappingAttribute("COMPANYNAME")]
        public string CompanyName { get; set; }

        [OracleObjectMappingAttribute("ADDRESS1")]
        public string Address1 { get; set; }

        [OracleObjectMappingAttribute("ADDRESS2")]
        public string Address2 { get; set; }

        [OracleObjectMappingAttribute("CITY")]
        public string City { get; set; }

        [OracleObjectMappingAttribute("STATE")]
        public string State { get; set; }

        [OracleObjectMappingAttribute("ZIP")]
        public string Zip { get; set; }

        [OracleObjectMappingAttribute("COUNTRY")]
        public string Country { get; set; }

        public static CompanyInfo Null
        {
            get
            {
                CompanyInfo company = new CompanyInfo();
                company.objectIsNull = true;
                return company;
            }
        }

        #region INullable Members

        public bool IsNull
        {
            get { return objectIsNull; }
        }

        #endregion

        #region IOracleCustomType Members

        public void FromCustomObject(Oracle.ManagedDataAccess.Client.OracleConnection con, IntPtr pUdt)
        {
            // Convert from the Custom Type to Oracle Object
            if (!string.IsNullOrEmpty(CompanyId))
            {
                OracleUdt.SetValue(con, pUdt, "COMPANYID", CompanyId);
            }
            if (!string.IsNullOrEmpty(CompanyName))
            {
                OracleUdt.SetValue(con, pUdt, "COMPANYNAME", CompanyName);
            }
            if (!string.IsNullOrEmpty(Address1))
            {
                OracleUdt.SetValue(con, pUdt, "ADDRESS1", Address1);
            }
            if (!string.IsNullOrEmpty(Address2))
            {
                OracleUdt.SetValue(con, pUdt, "ADDRESS2", Address2);
            }
            if (!string.IsNullOrEmpty(City))
            {
                OracleUdt.SetValue(con, pUdt, "CITY", City);
            }
            if (!string.IsNullOrEmpty(State))
            {
                OracleUdt.SetValue(con, pUdt, "STATE", State);
            }
            if (!string.IsNullOrEmpty(Zip))
            {
                OracleUdt.SetValue(con, pUdt, "ZIP", Zip);
            }
            if (!string.IsNullOrEmpty(Country))
            {
                OracleUdt.SetValue(con, pUdt, "COUNTRY", Country);
            }

        }

        public void ToCustomObject(Oracle.ManagedDataAccess.Client.OracleConnection con, IntPtr pUdt)
        {
            CompanyId = (string)OracleUdt.GetValue(con, pUdt, "COMPANYID");
            CompanyName = (string)OracleUdt.GetValue(con, pUdt, "COMPANYNAME");
            Address1 = (string)OracleUdt.GetValue(con, pUdt, "ADDRESS1");
            Address2 = (string)OracleUdt.GetValue(con, pUdt, "ADDRESS2");
            City = (string)OracleUdt.GetValue(con, pUdt, "CITY");
            State = (string)OracleUdt.GetValue(con, pUdt, "STATE");
            Zip = (string)OracleUdt.GetValue(con, pUdt, "ZIP");
            Country = (string)OracleUdt.GetValue(con, pUdt, "COUNTRY");
        }

        public void FromCustomObject(OracleConnection con, object udt)
        {
            throw new NotImplementedException();
        }

        public void ToCustomObject(OracleConnection con, object udt)
        {
            throw new NotImplementedException();
        }

        #endregion

    }

    [OracleCustomTypeMappingAttribute("SA.COMPYINFO")]
    public class CompanyInfoFactory : IOracleCustomTypeFactory
    {
        #region IOracleCustomTypeFactory Members

        public IOracleCustomType CreateObject()
        {
            return new CompanyInfo();
        }

        #endregion
    }



    /* CompanyInfoList Class
    **   An instance of a CompanyInfoList class represents an CompanyInfoList object
    **   A custom type must implement INullable and IOracleCustomType interfaces
    */
    public class CompanyInfoList : INullable, IOracleCustomType
    {
        [OracleArrayMapping()]
        public CompanyInfo[] CompanyInfoArray;

        private bool objectIsNull;

        #region INullable Members

        public bool IsNull
        {
            get { return objectIsNull; }
        }

        public static CompanyInfoList Null
        {
            get
            {
                CompanyInfoList obj = new CompanyInfoList();
                obj.objectIsNull = true;
                return obj;
            }
        }

        #endregion

        #region IOracleCustomType Members

        public void FromCustomObject(Oracle.ManagedDataAccess.Client.OracleConnection con, IntPtr pUdt)
        {
            OracleUdt.SetValue(con, pUdt, 0, CompanyInfoArray);
        }

        public void ToCustomObject(Oracle.ManagedDataAccess.Client.OracleConnection con, IntPtr pUdt)
        {
            CompanyInfoArray = (CompanyInfo[])OracleUdt.GetValue(con, pUdt, 0);
        }

        public void FromCustomObject(OracleConnection con, object udt)
        {
            throw new NotImplementedException();
        }

        public void ToCustomObject(OracleConnection con, object udt)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    [OracleCustomTypeMapping("SA.COMPANYINFOLIST")]
    public class CompanyInfoListFactory : IOracleCustomTypeFactory, IOracleArrayTypeFactory
    {
        #region IOracleCustomTypeFactory Members
        public IOracleCustomType CreateObject()
        {
            return new CompanyInfoList();
        }

        #endregion

        #region IOracleArrayTypeFactory Members
        public Array CreateArray(int numElems)
        {
            return new CompanyInfo[numElems];
        }

        public Array CreateStatusArray(int numElems)
        {
            return null;
        }

        #endregion
    }
}