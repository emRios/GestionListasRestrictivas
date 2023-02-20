using GestionListasRestrictivas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GestionListasRestrictivas.GestionListas
{
    public class GestionListasNacionalidad
    {
        [XmlRoot(ElementName = "nationality")]
        public class Nationality
        {

            [XmlElement(ElementName = "sdnEntry_Id")]
            public int sdnEntry_Id { get; set; }

            [XmlElement(ElementName = "nationality_uid")]
            public int Uid { get; set; }

            [XmlElement(ElementName = "country")]
            public string Country { get; set; }

            [XmlElement(ElementName = "mainEntry")]
            public bool MainEntry { get; set; }
        }

        public XDocument CrearXmlNacionalidadesOFAC(XDocument sndList)
        {

            XDocument nationalityList =
                  new XDocument(
                          new XElement("sdnnationalityList",
                                      from sndE in sndList.Element("sdnList").Elements("sdnEntry")
                                      from adresses in sndE.ElementExists("nationalityList").Elements("nationality")
                                      select new XElement("nationalityList",
                                                    new XElement("sdnEntry_Id", Convert.ToInt32(sndE.Element("uid").Value)),
                                                    new XElement("nationality_Id", Convert.ToInt32(adresses.SingleElementExists("uid").Value)),
                                                    new XElement("country", adresses.SingleElementExists("country").Value),
                                                    new XElement("mainEntry", adresses.SingleElementExists("mainEntry").Value)
                                       )));

            return nationalityList;

        }


        public XDocument CrearXmlNacionalidadesONU(XDocument sndList) {


            XDocument naciolalityList = new XDocument(
                    new XElement("NATIONALITY_LIST",
                                from interval in sndList.Descendants("INDIVIDUAL")
                                from lastDay in interval.ElementExists("NATIONALITY").Elements("VALUE")
                                select new XElement("LAST_DAY_UPDATED",
                                             new XElement("DATAID", interval.Element("DATAID").Value),
                                             new XElement("VALUE", lastDay.SingleElementEmpty("VALUE")))
                        ));


            return naciolalityList;

        }



    }
}