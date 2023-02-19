using GestionListasRestrictivas.Helpers;
using GestionListasRestrictivas.Helpers.GestionListasRestrictivas;
using Oracle.ManagedDataAccess.Client;
using OracleUDTSample;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GestionListasRestrictivas.GestionListas
{
    public class AddressList
    {

        [XmlElement(ElementName = "sdnEntry_Id")]
        public int sdnEntry_Id { get; set; }

        [XmlElement(ElementName = "address_Id")]
        public int address_Id { get; set; }

        [XmlElement(ElementName = "Adress1")]
        public string Adress1 { get; set; }

        [XmlElement(ElementName = "Adress2")]
        public string Adress2 { get; set; }

        [XmlElement(ElementName = "Adress3")]
        public string Adress3 { get; set; }

        [XmlElement(ElementName = "Adress4")]
        public string Adress4 { get; set; }

        [XmlElement(ElementName = "City")]
        public string City { get; set; }

        [XmlElement(ElementName = "PostalCode")]
        public string PostalCode { get; set; }

        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }

    }

    public class GestionListaDirecciones
    {

        public XDocument CrearXmlDirecciones(XDocument sndList) 
        {

           

            XDocument addressesList =
                  new XDocument(
                          new XElement("sdnaddressList",
                                      from sndE in sndList.Element("sdnList").Elements("sdnEntry")
                                      from adresses in sndE.ElementExists("addressList").Elements("address")
                                      select new XElement("addressList",
                                                    new XElement("sdnEntry_Id", Convert.ToInt32(sndE.Element("uid").Value)),
                                                    new XElement("address_Id", Convert.ToInt32(adresses.SingleElementExists("uid").Value)),
                                                    new XElement("Adress1", adresses.SingleElementExists("address1").Value),
                                                    new XElement("Adress2", adresses.SingleElementExists("address2").Value),
                                                    new XElement("Adress3", adresses.SingleElementExists("address3").Value),
                                                    new XElement("Adress4", adresses.SingleElementExists("address4").Value),
                                                    new XElement("city", adresses.SingleElementExists("city").Value),
                                                    new XElement("postalCode", adresses.SingleElementExists("postalCode").Value),
                                                    new XElement("country", adresses.SingleElementExists("country").Value)
                                       )));

            return addressesList;

        }
    }
}