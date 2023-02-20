using GestionListasRestrictivas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GestionListasRestrictivas.GestionListas
{
    [XmlRoot(ElementName = "aka")]
    public class Aka
    {
        [XmlElement(ElementName = "sdnEntry_Id")]
        public int sdnEntry_Id { get; set; }

        [XmlElement(ElementName = "aka_uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "category")]  
        public string Category { get; set; }

        [XmlElement(ElementName = "lastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "firstName")]
        public string FirstName { get; set; }
    }

    public class GestionListaAkas
    {

        public XDocument CrearXmlAkasOFAC(XDocument sndList)
        {

            XDocument akasList =
                  new XDocument(
                          new XElement("sdnakaList",
                                      from sndE in sndList.Element("sdnList").Elements("sdnEntry")
                                      from adresses in sndE.ElementExists("akaList").Elements("aka")
                                      select new XElement("akaList",
                                                    new XElement("sdnEntry_Id", Convert.ToInt32(sndE.Element("uid").Value)),
                                                    new XElement("aka_Id", Convert.ToInt32(adresses.SingleElementExists("uid").Value)),
                                                    new XElement("type", adresses.SingleElementExists("type").Value),
                                                    new XElement("category", adresses.SingleElementExists("category").Value),
                                                    new XElement("lastName", adresses.SingleElementExists("lastName").Value),
                                                    new XElement("firstName", adresses.SingleElementExists("firstName").Value)
                                       )));

            return akasList;

        }

        public XDocument CrearXmlAliasONU(XDocument sndList) {

            XDocument aliasList = new XDocument(
                            new XElement("INDIVIDUAL_ALIAS_LIST",
                            from interval in sndList.Descendants("INDIVIDUAL")
                            from alias in interval.Descendants("INDIVIDUAL_ALIAS")
                            select new XElement("INDIVIDUAL_ALIAS",
                                    new XElement("DATAID", interval.Element("DATAID").Value),
                                    new XElement("QUALITY", alias.SingleElementExists("QUALITY").Value),
                                    new XElement("ALIAS_NAME", alias.SingleElementExists("ALIAS_NAME").Value),
                                    new XElement("NOTE", alias.SingleElementExists("NOTE").Value)
                            )));

            return aliasList;

        }
    }
}