using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionListasRestrictivas
{
    public static class DataBaseConnections
    {

        public static string ORACLEConnection()
        {
            string HOST = ConfigurationManager.AppSettings["ORAC_HOST"].ToString();
            string PORT = ConfigurationManager.AppSettings["ORAC_PORT"].ToString();
            string SERVICE_NAME = ConfigurationManager.AppSettings["ORAC_SERVICE_NAME"].ToString();
            string CREDENTIALS = ConfigurationManager.AppSettings["ORAC_CREDENTIALS"].ToString();

            string banca_desc = "Data Source=(DESCRIPTION =" +
                                "(ADDRESS = (PROTOCOL = TCP)(HOST =" + HOST + ")(PORT = " + PORT + "))" +
                                "(CONNECT_DATA =(SERVER = DEDICATED)" +
                                "(SERVICE_NAME = " + SERVICE_NAME + "))); " + CREDENTIALS;

            return banca_desc;
        }

       public static void AddArray<T>(this OracleParameterCollection parameters,
                                       string name,
                                       OracleDbType dbType,
                                       T[] array,
                                       ParameterDirection dir,
                                       T emptyArrayValue)
        {
            parameters.Add(new OracleParameter
            {
                ParameterName = name,
                OracleDbType = dbType,
                CollectionType = OracleCollectionType.PLSQLAssociativeArray
            });

            // oracle does not support passing null or empty arrays.
            // so pass an array with exactly one element
            // with a predefined value and use it to check
            // for empty array condition inside the proc code
            if (array == null || array.Length == 0)
            {
                parameters[name].Value = new T[1] { emptyArrayValue };
                parameters[name].Size = 1;
            }
            else
            {
                parameters[name].Value = array;
                parameters[name].Size = array.Length;
            }
        }

        public static OracleCommand CreateCommand(  this OracleConnection con,
                                                    string commandText,
                                                    CommandType commandType = CommandType.StoredProcedure,
                                                    int commandTimeout = 60,
                                                    bool bindByName = true)
        {
            var cmd = con.CreateCommand();
            cmd.CommandType = commandType;
            cmd.CommandText = commandText;
            cmd.CommandTimeout = commandTimeout;

            // binds the parameters by name.
            cmd.BindByName = bindByName;

            return cmd;
        }


    }
}
