using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionListasRestrictivas
{
    public partial class ComparacionDataListas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btn_ProgramarProc_Click(object sender, EventArgs e)
        {


            string Usuario = HttpContext.Current.User.Identity.Name;
            datepicker.Text = (datepicker.Text == "") ? string.Empty : datepicker.Text;
            correo_usuario.Value = (correo_usuario.Value == "") ? string.Empty : correo_usuario.Value;
            correoTecnologia.Value = (correoTecnologia.Value == "") ? string.Empty : correoTecnologia.Value;
            descripcion_proceso.Value = (descripcion_proceso.Value == "") ? string.Empty : descripcion_proceso.Value;
             


            string StrSql = "sa.PKG_GESTOR_LST_RESTICTIVAS.spi_lr_prm_scheduler";
            //string DescError;
            int CodError;


            try
            {
                using (OracleConnection con = new OracleConnection(DataBaseConnections.ORACLEConnection()))
                {
                    using (OracleCommand OraSentenBanca = new OracleCommand(StrSql, con))
                    {
                        con.Open();

                        OraSentenBanca.CommandTimeout = 60000;
                        OraSentenBanca.CommandType = CommandType.StoredProcedure;

                        OraSentenBanca.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = descripcion_proceso.Value;
                        OraSentenBanca.Parameters.Add("P_fecha_programada", OracleDbType.Varchar2).Value = datepicker.Text;
                        OraSentenBanca.Parameters.Add("p_email_aviso_err", OracleDbType.Varchar2).Value = correoTecnologia.Value;
                        OraSentenBanca.Parameters.Add("p_email_aviso_usr", OracleDbType.Varchar2).Value = correo_usuario.Value;
                        OraSentenBanca.Parameters.Add("p_ramo_ejecucion", OracleDbType.Int32).Value = ramo_procesar.SelectedValue;               
                        OraSentenBanca.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = Usuario;

                        OraSentenBanca.ExecuteNonQuery();


                        CodError = 0;
                       //return CodError;
                    }
                }
            }
            catch (Exception ex)
            {
                //return 9;
                //escribirLog.WriteLog(1, ex.Message);
                //throw new Exception(ex.Message, ex);
            }
        }
    }
}