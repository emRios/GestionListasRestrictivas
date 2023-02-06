
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionListasRestrictivas
{
    public partial class BusquedaIndividual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {

            string StrSql = "SA.PKG_GESTOR_LST_RESTICTIVAS.sp_lst_carga_cons_individual";

            string respuesta;

            primer_nombre.Value = (primer_nombre.Value == "") ? "ZZZ" : primer_nombre.Value;
            segundo_nombre.Value = (segundo_nombre.Value == "") ? "ZZZ" : segundo_nombre.Value;
            primer_apellido.Value = (primer_apellido.Value == "") ? "ZZZ" : primer_apellido.Value;
            segundo_apellido.Value = (segundo_apellido.Value == "") ? "ZZZ" : segundo_apellido.Value;
            tercer_nombre.Value = (tercer_nombre.Value == "") ? "ZZZ" : tercer_nombre.Value;
            codigo_asegurado.Value = (codigo_asegurado.Value == "") ? "0" : codigo_asegurado.Value;
            documento_identificacion.Value = (documento_identificacion.Value == " ") ? "ZZZ" : documento_identificacion.Value;


            try
            {
                using (OracleConnection con = new OracleConnection(DataBaseConnections.ORACLEConnection()))
                {


                    using (OracleCommand OraSentenBanca = new OracleCommand(StrSql, con))
                    {
                        con.Open();

                        OraSentenBanca.CommandTimeout = 60000;
                        OraSentenBanca.CommandType = CommandType.StoredProcedure;

                        OraSentenBanca.Parameters.Add(":p_primer_nombre", OracleDbType.Varchar2).Value = primer_nombre.Value.ToString(); ;
                        OraSentenBanca.Parameters.Add(":p_segundo_nombre", OracleDbType.Varchar2).Value = segundo_nombre.Value.ToString();
                        OraSentenBanca.Parameters.Add(":p_primer_apellido", OracleDbType.Varchar2).Value = primer_apellido.Value.ToString();
                        OraSentenBanca.Parameters.Add(":p_segundo_apellido", OracleDbType.Varchar2).Value = segundo_apellido.Value.ToString();
                        OraSentenBanca.Parameters.Add(":p_tercer_nombre", OracleDbType.Varchar2).Value = tercer_nombre.Value.ToString();
                        //OraSentenBanca.Parameters.Add(":apellido_casada", OracleDbType.Varchar2).Value = apellido_casada.Value;
                        OraSentenBanca.Parameters.Add(":p_codigo_asegurado", OracleDbType.Int32).Value = Convert.ToInt32(codigo_asegurado.Value);
                        OraSentenBanca.Parameters.Add(":p_documento_identificacion", OracleDbType.Varchar2).Value = documento_identificacion.Value.ToString();


                        //OraSentenBanca.Parameters.Add(":P_XML_OUT", OracleDbType.Clob).Direction = ParameterDirection.Output;
                        //OraSentenBanca.Parameters.Add(":P_COD_ERR", OracleDbType.Int64).Direction = ParameterDirection.Output;

                        OraSentenBanca.ExecuteNonQuery();

                        //myxml = (OracleClob)OraSentenBanca.Parameters[":P_XML_OUT"].Value;
                        //int.TryParse(OraSentenBanca.Parameters[":P_COD_ERR"].Value.ToString(), out codErr);
                        respuesta = "si";

                        // return respuesta;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        protected void btn_validar_Click(object sender, EventArgs e)
        {
            string StrSql = "SA.PKG_GESTOR_LST_RESTICTIVAS.spi_lst_proc_validacion_ind";

            string respuesta;

            try
            {
                using (OracleConnection con = new OracleConnection(DataBaseConnections.ORACLEConnection()))
                {


                    using (OracleCommand OraSentenBanca = new OracleCommand(StrSql, con))
                    {
                        con.Open();

                        OraSentenBanca.CommandTimeout = 60000;
                        OraSentenBanca.CommandType = CommandType.StoredProcedure;

                        //OraSentenBanca.Parameters.Add(":p_primer_nombre", OracleDbType.Varchar2).Value = primer_nombre.Value.ToString(); ;
                        //OraSentenBanca.Parameters.Add(":p_segundo_nombre", OracleDbType.Varchar2).Value = segundo_nombre.Value.ToString();
                        //OraSentenBanca.Parameters.Add(":p_primer_apellido", OracleDbType.Varchar2).Value = primer_apellido.Value.ToString();
                        //OraSentenBanca.Parameters.Add(":p_segundo_apellido", OracleDbType.Varchar2).Value = segundo_apellido.Value.ToString();
                        //OraSentenBanca.Parameters.Add(":p_tercer_nombre", OracleDbType.Varchar2).Value = tercer_nombre.Value.ToString();
                        ////OraSentenBanca.Parameters.Add(":apellido_casada", OracleDbType.Varchar2).Value = apellido_casada.Value;
                        //OraSentenBanca.Parameters.Add(":p_codigo_asegurado", OracleDbType.Int32).Value = Convert.ToInt32(codigo_asegurado.Value);
                        //OraSentenBanca.Parameters.Add(":p_documento_identificacion", OracleDbType.Varchar2).Value = documento_identificacion.Value.ToString();


                        //OraSentenBanca.Parameters.Add(":P_XML_OUT", OracleDbType.Clob).Direction = ParameterDirection.Output;
                        //OraSentenBanca.Parameters.Add(":P_COD_ERR", OracleDbType.Int64).Direction = ParameterDirection.Output;

                        OraSentenBanca.ExecuteNonQuery();

                        //myxml = (OracleClob)OraSentenBanca.Parameters[":P_XML_OUT"].Value;
                        //int.TryParse(OraSentenBanca.Parameters[":P_COD_ERR"].Value.ToString(), out codErr);
                        respuesta = "si";

                        // return respuesta;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }




        }

    }
}