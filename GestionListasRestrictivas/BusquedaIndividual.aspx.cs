
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
            string Usuario = HttpContext.Current.User.Identity.Name;

            string StrSql = "SA.PKG_GESTOR_LST_RESTICTIVAS.sp_lst_carga_cons_individual";


            primer_nombre.Value = primer_nombre.Value;
            segundo_nombre.Value = (segundo_nombre.Value == "") ? string.Empty : segundo_nombre.Value;
            primer_apellido.Value = primer_apellido.Value;
            segundo_apellido.Value = (segundo_apellido.Value == "") ? string.Empty : segundo_apellido.Value;
            tercer_nombre.Value = (tercer_nombre.Value == "") ? string.Empty : tercer_nombre.Value;
            codigo_asegurado.Value = (codigo_asegurado.Value == "") ? "0" : codigo_asegurado.Value;
            documento_identificacion.Value = (documento_identificacion.Value == " ") ? string.Empty : documento_identificacion.Value;


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
                        OraSentenBanca.Parameters.Add(":p_usuario", OracleDbType.Varchar2).Value = Usuario;



                        OraSentenBanca.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

            consultarRegistros(Usuario);

        }

        protected void consultarRegistros(string usuario)
        {
            string StrSql = "SA.PKG_GESTOR_LST_RESTICTIVAS.sp_con_registros_individual";

            try
            {
                using (OracleConnection con = new OracleConnection(DataBaseConnections.ORACLEConnection()))
                {


                    using (OracleCommand OraSentenBanca = new OracleCommand(StrSql, con))
                    {
                        con.Open();

                        OraSentenBanca.CommandTimeout = 60000;
                        OraSentenBanca.CommandType = CommandType.StoredProcedure;

                        OraSentenBanca.Parameters.Add("P_USUARIO", OracleDbType.Varchar2, usuario, ParameterDirection.Input);
                        OraSentenBanca.Parameters.Add("P_CUR_DATA", OracleDbType.RefCursor, ParameterDirection.Output);


                        var da = new OracleDataAdapter(OraSentenBanca);
                        var dt = new DataTable();
                        da.Fill(dt);

                        gvResultadosValidacion.DataSource = dt;
                        gvResultadosValidacion.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void validarResultados(string usuario)
        {
            string Usuario = HttpContext.Current.User.Identity.Name;
            string StrSql = "SA.PKG_GESTOR_LST_RESTICTIVAS.spi_lst_proc_validacion_ind";

            try
            {
                using (OracleConnection con = new OracleConnection(DataBaseConnections.ORACLEConnection()))
                {


                    using (OracleCommand OraSentenBanca = new OracleCommand(StrSql, con))
                    {
                        con.Open();

                        OraSentenBanca.CommandTimeout = 60000;
                        OraSentenBanca.CommandType = CommandType.StoredProcedure;
                        OraSentenBanca.Parameters.Add(":p_usuario", OracleDbType.Varchar2).Value = usuario;



                        OraSentenBanca.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }




        }

        protected void btn_conResultados_Click(object sender, EventArgs e)
        {
            string Usuario = HttpContext.Current.User.Identity.Name;

            validarResultados(Usuario);

            string StrSql = "SA.PKG_GESTOR_LST_RESTICTIVAS.sp_con_validacion_indiv";


            try
            {
                using (OracleConnection con = new OracleConnection(DataBaseConnections.ORACLEConnection()))
                {


                    using (OracleCommand OraSentenBanca = new OracleCommand(StrSql, con))
                    {
                        con.Open();

                        OraSentenBanca.CommandTimeout = 60000;
                        OraSentenBanca.CommandType = CommandType.StoredProcedure;

                        OraSentenBanca.Parameters.Add("P_USUARIO", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);
                        OraSentenBanca.Parameters.Add("P_CUR_DATA", OracleDbType.RefCursor, ParameterDirection.Output);


                        var da = new OracleDataAdapter(OraSentenBanca);
                        var dt = new DataTable();
                        da.Fill(dt);

                        gvResultadosValidacion.DataSource = dt;
                        gvResultadosValidacion.DataBind();

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