using GestionListasRestrictivas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GestionListasRestrictivas.GestionListas
{
    public class GestionListasLugarNacimiento
    {
        [XmlRoot(ElementName = "placeOfBirthItem")]
        public class PlaceOfBirthItem
        {
            [XmlElement(ElementName = "sdnEntry_Id")]
            public int sdnEntry_Id { get; set; }

            [XmlElement(ElementName = "placeOfBirth_uid")]
            public int Uid { get; set; }

            [XmlElement(ElementName = "placeOfBirth")]
            public string PlaceOfBirth { get; set; }

            [XmlElement(ElementName = "mainEntry")]
            public bool MainEntry { get; set; }
        }

        public XDocument CrearXmlLugaresNacimiento(XDocument sndList)
        {

            XDocument placeOfBirthList =
                  new XDocument(
                          new XElement("sdnplaceOfBirthList",
                                      from sndE in sndList.Element("sdnList").Elements("sdnEntry")
                                      from adresses in sndE.ElementExists("placeOfBirthList").Elements("placeOfBirthItem")
                                      select new XElement("placeOfBirthList",
                                                    new XElement("sdnEntry_Id", Convert.ToInt32(sndE.Element("uid").Value)),
                                                    new XElement("pbirth_Id", Convert.ToInt32(adresses.SingleElementExists("uid").Value)),
                                                    new XElement("placeOfBirth", adresses.SingleElementExists("placeOfBirth").Value),
                                                    new XElement("mainEntry", adresses.SingleElementExists("mainEntry").Value)
                                       )));

            return placeOfBirthList;

        }
    }
}