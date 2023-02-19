using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace GestionListasRestrictivas.GestionListas
{

    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
        // <summary>
        //     An XElement extension method that removes all namespaces described by @this.
        // </summary>
        // <param name = "this" > The @this to act on.</param>
        // <returns>An XElement.</returns>
        public static XElement RemoveAllNamespaces(this XElement @this)
        {
            return new XElement(@this.Name.LocalName,
                (from n in @this.Nodes()
                 select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
                (@this.HasAttributes) ? (from a in @this.Attributes() select a) : null);
        }

      


    }

    public class GestionarLIstasDeDatos
    {

        GestionListaDirecciones listaDirecciones = new GestionListaDirecciones();
        GestionProgramList gestionProgramList = new GestionProgramList();
        GestionListaAkas gestionListaAkas = new GestionListaAkas();
        GestionListaCiudadanias gestionListaCiudadanias = new GestionListaCiudadanias();
        GestionListaFechasNacimiento gestionListaFechasNacimiento = new GestionListaFechasNacimiento();
        GestionListasLugarNacimiento GestionListasLugarNacimiento = new GestionListasLugarNacimiento();
        GestionListasNacionalidad gestionListasNacionalidad = new GestionListasNacionalidad();
        GestionListasDocumentos gestionListasDocumentos = new GestionListasDocumentos();

        private XDocument sndList;
        private XDocument listadirecciones;
        private XDocument listaprogramas;
        private XDocument listaakas;
        private XDocument listaciudadanias;
        private XDocument listafechasnacimiento;
        private XDocument listaslugarnacimiento;
        private XDocument listasnacionalidaes;
        private XDocument listasdocumentos;


        public string listaOfacXML;
        string listaOnu = "ONU";

        public static XElement RemoveAllNamespaces(XElement e)
        {
            return new XElement(e.Name.LocalName,
               (from n in e.Nodes()
                select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
               (e.HasAttributes) ? (from a in e.Attributes()
                                    where (!a.IsNamespaceDeclaration)
                                    select new XAttribute(a.Name.LocalName, a.Value)) : null);
        }

        public static XDocument RemoveXmlns(XDocument doc)
        {
           // XDocument doc = XDocument.Load(xml);
            // All elements with an empty namespace...
            foreach (var node in doc.Root.Descendants()
                                    .Where(n => n.Name.NamespaceName == "xmlns"))
            {
                // Remove the xmlns='' attribute. Note the use of
                // Attributes rather than Attribute, in case the
                // attribute doesn't exist (which it might not if we'd
                // created the document "manually" instead of loading
                // it from a file.)
                node.Attributes("xmlns").Remove();
                // Inherit the parent namespace instead
                node.Name = node.Parent.Name.Namespace + node.Name.LocalName;
            }

            return doc;
        }

        public static string RemoveAllXmlNamespace(string xmlData)
        {
            string xmlnsPattern = "\\s+xmlns\\s*(:\\w)?\\s*=\\s*\\\"(?<url>[^\\\"]*)\\\"";
            MatchCollection matchCol = Regex.Matches(xmlData, xmlnsPattern);

            foreach (Match m in matchCol)
            {
                xmlData = xmlData.Replace(m.ToString(), "");
            }
            return xmlData;
        }

        public void FormatXMLListas()
        {

            XmlDocument listXML = new XmlDocument();
            
            //Regex below finds strings that start with xmlns, may or may not have :and some text, then continue with =
            //and ", have a streach of text that does not contain quotes and end with ". similar, will happen to an attribute
            // that starts with xsi.
            string strXMLPattern = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";
            listaOfacXML = Regex.Replace(listaOfacXML, strXMLPattern, "");

            listXML.LoadXml(listaOfacXML);

            sndList = XDocument.Parse(listXML.OuterXml);
            sndList.Root.Elements("sdnEntry")
            .Where(e => e.Element("sdnType").Value == "Entity")
            .Remove();


        }

        protected virtual int LoadXmlDataDB( string origen, string tipoLista, XDocument xmlList)
        {


            string StrSql = "sa.PKG_GESTOR_LST_RESTICTIVAS.spi_lst_carga_lista_xml";
            string DescError;
            int CodError;

            XmlDocument listToSend = xmlList.ToXmlDocument();

            try
            {
                using (OracleConnection con = new OracleConnection(DataBaseConnections.ORACLEConnection()))
                {
                    using (OracleCommand OraSentenBanca = new OracleCommand(StrSql, con))
                    {
                        con.Open();

                        OraSentenBanca.CommandTimeout = 120000;
                        OraSentenBanca.CommandType = CommandType.StoredProcedure; 

                        OraSentenBanca.Parameters.Add(":P_ORIGEN", OracleDbType.Varchar2).Value = origen;
                        OraSentenBanca.Parameters.Add(":P_TIPO_LISTA", OracleDbType.Varchar2).Value = tipoLista;
                        OraSentenBanca.Parameters.Add(":P_LISTA_XML", OracleDbType.Clob).Value = xmlList;
                        //OraSentenBanca.Parameters.Add(":P_CODE_ERROR", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
                        //OraSentenBanca.Parameters.Add(":P_ERROR_MESSAGE", OracleDbType.Varchar2).Direction = ParameterDirection.Output;


                        OraSentenBanca.ExecuteNonQuery();

                        //DescError = OraSentenBanca.Parameters[":P_ERROR_MESSAGE"].Value.ToString();
                        //int.TryParse(OraSentenBanca.Parameters[":P_CODE_ERROR"].Value.ToString(), out CodError);
                        CodError = 0;
                        return CodError;
                    }
                }
            }
            catch (Exception ex)
            {
                return 9;
                //escribirLog.WriteLog(1, ex.Message);
                //throw new Exception(ex.Message, ex);
            }
        }

        private int CargarListaDirecciones()
        {
            //int CodError;
            //string DescError;
            
            string tipoLista = "ADDRESS";
            listadirecciones = listaDirecciones.CrearXmlDirecciones(sndList);
            LoadXmlDataDB(listaOnu,tipoLista, listadirecciones);

            return 0;
        }

        private int CargarListaProgramas()
        {
            //int CodError;
            //string DescError;

            string tipoLista = "PROGRAMS";
            listaprogramas = gestionProgramList.CrearXmlProgramas(sndList);
            LoadXmlDataDB(listaOnu,tipoLista, listaprogramas);

            return 0;
        }

        private int CargarListaAkas()
        {
            //int CodError;
            //string DescError;

            string tipoLista = "AKAS";
            listaakas = gestionListaAkas.CrearXmlAkas(sndList);
            LoadXmlDataDB(listaOnu,tipoLista, listaakas);

            return 0;
        }

        private int CargarListaCiudadanias()
        {
            //int CodError;
            //string DescError;

            string tipoLista = "CITIZENSHIP";
            listaciudadanias = gestionListaCiudadanias.CrearXmlCiudadanias(sndList);
            LoadXmlDataDB(listaOnu,tipoLista, listaciudadanias);

            return 0;
        }

        private int CargarListaFechasNacimiento()
        {
            //int CodError;
            //string DescError;

            string tipoLista = "BDAY";
            listafechasnacimiento = gestionListaFechasNacimiento.CrearXmlFechasNacimiento(sndList);
            LoadXmlDataDB(listaOnu,tipoLista, listafechasnacimiento);

            return 0;
        }

        private int CargarListaLugarNacimiento()
        {
            //int CodError;
            //string DescError;

            string tipoLista = "PBIRTH";
            listaslugarnacimiento = GestionListasLugarNacimiento.CrearXmlLugaresNacimiento(sndList);
            LoadXmlDataDB(listaOnu,tipoLista, listaslugarnacimiento);

            return 0;
        }

        private int CargarListaNaciondalidades()
        {
            //int CodError;
            //string DescError;

            string tipoLista = "NATION";
            listasnacionalidaes = gestionListasNacionalidad.CrearXmlNacionalidades(sndList);
            LoadXmlDataDB(listaOnu,tipoLista, listasnacionalidaes);

            return 0;
        }

        private int CargarListaDocumentos()
        {
            //int CodError;
            //string DescError;

            string tipoLista = "IDS";
            listasdocumentos = gestionListasDocumentos.CrearXmlDocumentos(sndList);
            LoadXmlDataDB(listaOnu,tipoLista, listasdocumentos);

            return 0;
        }

        public string CargarListasONU()
        {

            FormatXMLListas();

            CargarListaDirecciones();

            CargarListaProgramas();

            CargarListaAkas();

            CargarListaCiudadanias();

            CargarListaFechasNacimiento();

            CargarListaLugarNacimiento();

            CargarListaNaciondalidades();

            CargarListaDocumentos();

            return "ok";
        }



    }

}