using GestionListasRestrictivas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GestionListasRestrictivas.GestionListas
{

    [XmlRoot(ElementName = "programList")]
    public class ProgramList
    {

        [XmlElement(ElementName = "sdnEntry_Id")]
        public int sdnEntry_Id { get; set; }

        [XmlElement(ElementName = "program")]
        public string Program { get; set; }
    }


    public class GestionProgramList
    {

        public XDocument CrearXmlProgramasOFAC(XDocument sndList)
        {



            XDocument programsList =
                  new XDocument(
                          new XElement("sdnprogramList",
                                      from sndE in sndList.Element("sdnList").Elements("sdnEntry")
                                      from programs in sndE.ElementExists("programList").Elements("program")
                                      select new XElement("programList",
                                                    new XElement("sdnEntry_Id", Convert.ToInt32(sndE.Element("uid").Value)),
                                                    new XElement("program", programs.Value))
                                       ));

            return programsList;

        }

    }
}