﻿using GestionListasRestrictivas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GestionListasRestrictivas.GestionListas
{
    public class GestionListasFechaNacimiento
    {

        [XmlRoot(ElementName = "dateOfBirthItem")]
        public class DateOfBirthItem
        {


            [XmlElement(ElementName = "sdnEntry_Id")]
            public int sdnEntry_Id { get; set; }

            [XmlElement(ElementName = "dateBirth_uid")]
            public int Uid { get; set; }

            [XmlElement(ElementName = "dateOfBirth")]
            public DateTime DateOfBirth { get; set; }

            [XmlElement(ElementName = "mainEntry")]
            public bool MainEntry { get; set; }
        }
    }

    public class GestionListaFechasNacimiento
    {

        public XDocument CrearXmlFechasNacimientoOFAC(XDocument sndList)
        {



            XDocument dateOfBirthList =
                  new XDocument(
                          new XElement("sdndateOfBirthList",
                                      from sndE in sndList.Element("sdnList").Elements("sdnEntry")
                                      from adresses in sndE.ElementExists("dateOfBirthList").Elements("dateOfBirthItem")
                                      select new XElement("dateOfBirthList",
                                                    new XElement("sdnEntry_Id", Convert.ToInt32(sndE.Element("uid").Value)),
                                                    new XElement("bday_Id", Convert.ToInt32(adresses.SingleElementExists("uid").Value)),
                                                    new XElement("dateOfBirth", adresses.SingleElementExists("dateOfBirth").Value),
                                                    new XElement("mainEntry", adresses.SingleElementExists("mainEntry").Value)
                                       )));

            return dateOfBirthList;

        }

        public XDocument CrearXmlFechasNacimientoONU(XDocument sndList) {

            XDocument dbirthList = new XDocument(
            new XElement("INDIVIDUAL_DATE_OF_BIRTH_LIST",
            from individual in sndList.Descendants("INDIVIDUAL")
            from address in individual.Descendants("INDIVIDUAL_DATE_OF_BIRTH")
            select new XElement("INDIVIDUAL_DATE_OF_BIRTH",
                    new XElement("DATAID", individual.Element("DATAID").Value),
                    new XElement("TYPE_OF_DATE", address.SingleElementExists("TYPE_OF_DATE").Value),
                    new XElement("DATE", address.SingleElementExists("DATE").Value)
            )));


            return dbirthList;
        }

    }
}