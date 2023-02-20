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

        public XDocument CrearXmlLugaresNacimientoOFAC(XDocument sndList)
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

        public XDocument CrearXmlLugaresNacimientoONU(XDocument sndList)
        {

            XDocument pbirthList = new XDocument(
                new XElement("INDIVIDUAL_PLACE_OF_BIRTH_LIST",
                from individual in sndList.Descendants("INDIVIDUAL")
                from address in individual.Descendants("INDIVIDUAL_PLACE_OF_BIRTH")
                select new XElement("INDIVIDUAL_PLACE_OF_BIRTH",
                        new XElement("DATAID", individual.Element("DATAID").Value),
                        new XElement("STATE_PROVINCE", address.SingleElementExists("STATE_PROVINCE").Value),
                        new XElement("COUNTRY", address.SingleElementExists("COUNTRY").Value)
                )));

            return pbirthList;

        }
    }
}