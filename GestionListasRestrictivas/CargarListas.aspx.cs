using GestionListasRestrictivas.Helpers.GestionListasRestrictivas;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
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
        protected void CargarListaONU_Click(object sender, EventArgs e)
        {


            //DataSet myDataSet = new DataSet();

            //myDataSet.ReadXml("myXmlFile.xml");

            //DataSet dsTest = new DataSet();
          
            //DataTable dt = dsTest.Tables[0];

            // Specify the path on the server to
            // save the uploaded file to.
            String savePath = @"c:\temp\uploads\";

            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (FileUpload1.HasFile)
            {
                Serializer ser = new Serializer();

                //using (StreamReader inputStreamReader = new StreamReader(FileUpload1.PostedFile.InputStream))
                //{
                //    var serializer = new XmlSerializer(typeof(sdnListSdnEntry));
                //    result = (sdnListSdnEntry)serializer.Deserialize(inputStreamReader);
                //}

                XmlDocument document = new XmlDocument();
                using (StreamReader inputStreamReader = new StreamReader(FileUpload1.PostedFile.InputStream))
                {
                    using (XmlReader reader = XmlReader.Create(inputStreamReader))
                    {
                        document.Load(inputStreamReader);
                    }
                }

                sdnListSdnEntry listSdnEntry = ser.Deserialize<sdnListSdnEntry>(document.OuterXml);

                //ConvertXMLtoDataSet(FileUpload1);


                // Get the name of the file to upload.
                String fileName = FileUpload1.FileName;

                // Append the name of the file to upload to the path.
                savePath += fileName;


                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                FileUpload1.SaveAs(savePath);

                // Notify the user of the name of the file
                // was saved under.
                UploadStatusLabel.Text = "Your file was saved as " + fileName;
            }
            else
            {
                // Notify the user that a file was not uploaded.
                UploadStatusLabel.Text = "You did not specify a file to upload.";
            }

        }
        protected void CargarListaOFAC_Click(object sender, EventArgs e)
        {
            // Specify the path on the server to
            // save the uploaded file to.
            String savePath = @"c:\temp\uploads\";

            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (FileUpload1.HasFile)
            {
                // Get the name of the file to upload.
                String fileName = FileUpload1.FileName;

                // Append the name of the file to upload to the path.
                savePath += fileName;


                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                FileUpload1.SaveAs(savePath);

                // Notify the user of the name of the file
                // was saved under.
                UploadStatusLabel.Text = "Your file was saved as " + fileName;
            }
            else
            {
                // Notify the user that a file was not uploaded.
                UploadStatusLabel.Text = "You did not specify a file to upload.";
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