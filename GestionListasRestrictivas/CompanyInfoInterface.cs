using Oracle.ManagedDataAccess.Client;
using OracleUDTSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CompanyInfoInterface
{
    #region Constants
    private const string procName = "sa.GetCompanyInfoArray";
    #endregion

    public static List<string> GetCompanyinfo(List<CompanyInfo> companyList)
    {
        List<string> companyNames = new List<string>();
        CompanyInfoList companyInfoList = new CompanyInfoList();
        companyInfoList.CompanyInfoArray = companyList.ToArray();

        using (DBAccess context = new DBAccess())
        {
            try
            {
                OracleParameter[] parameters = new OracleParameter[1];
                parameters[0] = DBAccess.CreateCustomTypeArrayInputParameter<CompanyInfoList>("companyInfoList", "SA.COMPANYINFOLIST", companyInfoList);
                //parameters[1] = DBAccess.CreateCursorParameter("resultCursor");
                using (OracleDataReader dr = context.GetDataReader(procName, parameters))
                {
                    while (dr.Read())
                    {
                        companyNames.Add(dr.IsDBNull(0) ? string.Empty : dr.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return companyNames;
        }
    }
}