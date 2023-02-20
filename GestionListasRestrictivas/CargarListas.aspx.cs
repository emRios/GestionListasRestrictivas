using GestionListasRestrictivas.GestionListas;
using GestionListasRestrictivas.Helpers;
using GestionListasRestrictivas.Helpers.GestionListasRestrictivas;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GestionListasRestrictivas
{
    public partial class CargarListas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }


        }
        protected void CargarListaOFAC_Click(object sender, EventArgs e)
        {


            GestionarLIstasDeDatos gestionListasOFAC = new GestionarLIstasDeDatos();
          

            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (FileUpload1.HasFile)
            {


                XmlDocument document = new XmlDocument();
                using (StreamReader inputStreamReader = new StreamReader(FileUpload1.PostedFile.InputStream))
                {
                    

                    using (XmlReader reader = XmlReader.Create(inputStreamReader))
                    {
                        document.Load(reader);
                    }
                }

                gestionListasOFAC.listaOfacXML = document.OuterXml;
                gestionListasOFAC.CargarListasOFAC();

               
                //// Notify the user of the name of the file
                //// was saved under.
                //UploadStatusLabel.Text = "Your file was saved as " + fileName;
            }
            else
            {
                // Notify the user that a file was not uploaded.
                Label1.Text = "You did not specify a file to upload.";
            }

        }
        protected void CargarListaONU_Click(object sender, EventArgs e)
        {

            GestionarLIstasDeDatos gestionListasONU = new GestionarLIstasDeDatos();

            //var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            //if (authCookie == null) return;
            //var cookieValue = authCookie.Value;

            //if (String.IsNullOrWhiteSpace(cookieValue)) return;
            //var ticket = FormsAuthentication.Decrypt(cookieValue);

            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (FileUpload2.HasFile)
            {
                XmlDocument document = new XmlDocument();
                using (StreamReader inputStreamReader = new StreamReader(FileUpload2.PostedFile.InputStream))
                {


                    using (XmlReader reader = XmlReader.Create(inputStreamReader))
                    {
                        document.Load(reader);
                    }
                }

                gestionListasONU.listaOnuXML = document.OuterXml;
                gestionListasONU.CargarListasONU();
            }
            else
            {
                // Notify the user that a file was not uploaded.
                Label2.Text = "You did not specify a file to upload.";
            }

        }

        protected void ConvertXMLtoDataSet(XmlDocument listas )
        {
            //DataSet objDataSet;
            //string strFileName = string.Empty;
            //string xmlOutputData = string.Empty;
            Serializer ser = new Serializer();
            //XmlDocument doc = new XmlDocument();

            try
            {

                //objDataSet = new DataSet();
                //objDataSet.ReadXml(inputStreamReader);

                //xmlInputData = File.ReadAllText()
                
                StringWriter sw = new StringWriter();
                XmlTextWriter tx = new XmlTextWriter(sw);
                listas.WriteTo(tx);

                string strListas = sw.ToString();
                   
              
                sdnListSdnEntry listSdnEntry = ser.Deserialize<sdnListSdnEntry>(strListas);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                //objDataSet = null;
                //strFileName = string.Empty;
            }
        }
    }
}