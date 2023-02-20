using GestionListasRestrictivas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionListasRestrictivas.GestionListas
{
    public class GetionListasFechaActualizacion
    {

        public XDocument CrearXmlFechaActulizacionONU(XDocument sndList)
        {


            XDocument lastdayUp = new XDocument(
                  new XElement("LAST_DAY_UPDATED_LIST",
                              from interval in sndList.Descendants("INDIVIDUAL")
                              from lastDay in interval.ElementExists("LAST_DAY_UPDATED").Elements("VALUE")
                              select new XElement("LAST_DAY_UPDATED",
                                           new XElement("DATAID", interval.Element("DATAID").Value),
                                           new XElement("VALUE", lastDay.SingleElementEmpty("VALUE")))
                      ));

            return lastdayUp;
        }

    }
}