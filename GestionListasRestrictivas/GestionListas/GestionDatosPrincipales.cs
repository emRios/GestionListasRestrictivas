using GestionListasRestrictivas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionListasRestrictivas.GestionListas
{
    public class GestionDatosPrincipales
    {



        public XDocument CrearXmlDatosPrincipalesOFAC(XDocument sndList)
        {



            XDocument individualPList =
                  new XDocument(
                          new XElement("individualsPList",
                                      from sndE in sndList.Element("sdnList").Elements("sdnEntry")
                                      select new XElement("individual",
                                                    new XElement("sdnEntry_Id", Convert.ToInt32(sndE.Element("uid").Value)),
                                                    new XElement("firstName", sndE.SingleElementExists("firstName").Value),
                                                    new XElement("lastName", sndE.SingleElementExists("lastName").Value),
                                                    new XElement("title", sndE.SingleElementExists("title").Value),
                                                    new XElement("remarks", sndE.SingleElementExists("remarks").Value)
                                       )));

            return individualPList;

        }


        public XDocument CrearXmlDatosPrincipalesONU(XDocument sndList)
        {


            XDocument individualList = new XDocument(
            new XElement("INDIVIDUAL_LIST",
            from interval in sndList.Descendants("INDIVIDUAL")
            select new XElement("INDIVIDUAL",
                    new XElement("DATAID", interval.Element("DATAID").Value),
                    new XElement("VERSIONNUM", interval.SingleElementExists("VERSIONNUM").Value),
                    new XElement("NAME_ORIGINAL_SCRIPT", interval.SingleElementExists("NAME_ORIGINAL_SCRIPT").Value),
                    new XElement("FIRST_NAME", interval.SingleElementExists("FIRST_NAME").Value),
                    new XElement("FOURTH_NAME", interval.SingleElementExists("FOURTH_NAME").Value),
                    new XElement("SECOND_NAME", interval.SingleElementExists("SECOND_NAME").Value),
                    new XElement("THIRD_NAME", interval.SingleElementExists("THIRD_NAME").Value),
                    new XElement("UN_LIST_TYPE", interval.SingleElementExists("UN_LIST_TYPE").Value),
                    new XElement("REFERENCE_NUMBER", interval.SingleElementExists("REFERENCE_NUMBER").Value),
                    new XElement("LISTED_ON", interval.SingleElementExists("LISTED_ON").Value),
                    new XElement("COMMENTS1", interval.SingleElementExists("COMMENTS1").Value),
                    new XElement("GOODQUALITY", interval.SingleElementExists("GOODQUALITY").Value),
                    new XElement("COMMENTS1", interval.SingleElementExists("COMMENTS1").Value)
            )));

            return individualList;

        }


    }
}