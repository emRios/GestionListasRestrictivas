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

        public XDocument CrearXmlDocumentosOFAC(XDocument sndList)
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

        public XDocument CrearXmlDocumentosONU(XDocument sndList)
        {

            XDocument documentsList = new XDocument(
                  new XElement("INDIVIDUAL_DOCUMENT_LIST",
                  from individual in sndList.Descendants("INDIVIDUAL")
                  from address in individual.Descendants("INDIVIDUAL_DOCUMENT")
                  select new XElement("INDIVIDUAL_DOCUMENT",
                          new XElement("DATAID", individual.Element("DATAID").Value),
                          new XElement("TYPE_OF_DOCUMENT", address.SingleElementExists("TYPE_OF_DOCUMENT").Value),
                          new XElement("NUMBER", address.SingleElementExists("NUMBER").Value),
                          new XElement("CITY_OF_ISSUE", address.SingleElementExists("CITY_OF_ISSUE").Value),
                          new XElement("DATE_OF_ISSUE", address.SingleElementExists("DATE_OF_ISSUE").Value),
                          new XElement("ISSUING_COUNTRY", address.SingleElementExists("ISSUING_COUNTRY").Value),
                          new XElement("NOTE", address.SingleElementExists("NOTE").Value),
                          new XElement("COUNTRY_OF_ISSUE", address.SingleElementExists("COUNTRY_OF_ISSUE").Value)
                  )));

            return documentsList;
           
        }
    }

}