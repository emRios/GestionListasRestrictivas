using GestionListasRestrictivas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GestionListasRestrictivas.GestionListas
{
    [XmlRoot(ElementName = "citizenship")]
    public class Citizenship
    {

        [XmlElement(ElementName = "sdnEntry_Id")]
        public int sdnEntry_Id { get; set; }

        [XmlElement(ElementName = "citizenship_uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "mainEntry")]
        public bool MainEntry { get; set; }
    }

    public class GestionListaCiudadanias
    {

        public XDocument CrearXmlCiudadanias(XDocument sndList)
        {

            XDocument citizenShipList =
                  new XDocument(
                          new XElement("sdncitizenshipList",
                                      from sndE in sndList.Element("sdnList").Elements("sdnEntry")
                                      from adresses in sndE.ElementExists("citizenshipList").Elements("citizenship")
                                      select new XElement("citizenshipList",
                                                    new XElement("sdnEntry_Id", Convert.ToInt32(sndE.Element("uid").Value)),
                                                    new XElement("citizen_Id", Convert.ToInt32(adresses.SingleElementExists("uid").Value)),
                                                    new XElement("country", adresses.SingleElementExists("country").Value),
                                                    new XElement("mainEntry", adresses.SingleElementExists("mainEntry").Value)
                                       )));

            return citizenShipList;

        }
    }

}