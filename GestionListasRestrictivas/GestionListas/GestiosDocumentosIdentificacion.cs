using GestionListasRestrictivas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GestionListasRestrictivas.GestionListas
{

    public class GestionListasDocumentos
    {
        [XmlRoot(ElementName = "id")]
        public class Id
        {

            [XmlElement(ElementName = "sdnEntry_Id")]
            public int sdnEntry_Id { get; set; }

            [XmlElement(ElementName = "document_uid")]
            public int Uid { get; set; }

            [XmlElement(ElementName = "idType")]
            public string IdType { get; set; }

            [XmlElement(ElementName = "idNumber")]
            public string IdNumber { get; set; }

            [XmlElement(ElementName = "idCountry")]
            public string IdCountry { get; set; }

            [XmlElement(ElementName = "issueDate")]
            public DateTime IssueDate { get; set; }

            [XmlElement(ElementName = "expirationDate")]
            public DateTime ExpirationDate { get; set; }


        }

        public XDocument CrearXmlDocumentos(XDocument sndList)
        {

            XDocument idList =
                  new XDocument(
                          new XElement("sdnidList",
                                      from sndE in sndList.Element("sdnList").Elements("sdnEntry")
                                      from adresses in sndE.ElementExists("idList").Elements("id")
                                      select new XElement("idList",
                                                    new XElement("sdnEntry_Id", Convert.ToInt32(sndE.Element("uid").Value)),
                                                    new XElement("doc_Id", Convert.ToInt32(adresses.SingleElementExists("uid").Value)),
                                                    new XElement("idType", adresses.SingleElementExists("idType").Value),
                                                    new XElement("idNumber", adresses.SingleElementExists("idNumber").Value),
                                                    new XElement("idCountry", adresses.SingleElementExists("idCountry").Value)
                                       )));

            return idList;

        }
    }

}