using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynceBanAchProcess
{
    public static class DataBaseConnections
    {

        public static string EbankingConnectionSQL()
        {

            string ConnectionString = ConfigurationManager.ConnectionStrings["EBSQLConnection"].ToString();

            return ConnectionString;

        }

        public static string ACHOmnConnectionSQL()
        {

            string ConnectionString = ConfigurationManager.ConnectionStrings["AchOmnSQLConnection"].ToString();

            return ConnectionString;

        }

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


    }
}
