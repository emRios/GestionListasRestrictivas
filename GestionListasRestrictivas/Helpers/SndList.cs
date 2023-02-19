using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace testList
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(SdnList));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (SdnList)serializer.Deserialize(reader);
    // }
    [XmlRoot(ElementName = "publshInformation")]
    public class PublshInformation
    {

        [XmlElement(ElementName = "Publish_Date")]
        public DateTime PublishDate { get; set; }

        [XmlElement(ElementName = "Record_Count")]
        public int RecordCount { get; set; }
    }

    [XmlRoot(ElementName = "programList")]
    public class ProgramList
    {

        [XmlElement(ElementName = "program")]
        public List<string> Program { get; set; }
    }

    [XmlRoot(ElementName = "id")]
    public class Id
    {

        [XmlElement(ElementName = "uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "idType")]
        public string IdType { get; set; }

        [XmlElement(ElementName = "idNumber")]
        public string IdNumber { get; set; }

        [XmlElement(ElementName = "idCountry")]
        public string IdCountry { get; set; }

        [XmlElement(ElementName = "issueDate")]
        public DateTime IssueDate { get; set; }

        [XmlElement(ElementName = "expirationDate")]
        public DateTime ExpirationDate { get; set; }
    }

    [XmlRoot(ElementName = "idList")]
    public class IdList
    {

        [XmlElement(ElementName = "id")]
        public List<Id> Id { get; set; }
    }

    [XmlRoot(ElementName = "aka")]
    public class Aka
    {

        [XmlElement(ElementName = "uid")]
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

    [XmlRoot(ElementName = "akaList")]
    public class AkaList
    {

        [XmlElement(ElementName = "aka")]
        public List<Aka> Aka { get; set; }
    }

    [XmlRoot(ElementName = "address")]
    public class Address
    {

        [XmlElement(ElementName = "uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "address1")]
        public string Address1 { get; set; }
        [XmlElement(ElementName = "address2")]
        public string Address2 { get; set; }
        [XmlElement(ElementName = "address3")]
        public string Address3 { get; set; }
        [XmlElement(ElementName = "address4")]
        public string Address4 { get; set; }

        [XmlElement(ElementName = "city")]
        public string City { get; set; }

        [XmlElement(ElementName = "postalCode")]
        public string postalCode { get; set; }

        [XmlElement(ElementName = "country")]
        public string country { get; set; }
    }

    [XmlRoot(ElementName = "addressList")]
    public class AddressList
    {

        [XmlElement(ElementName = "pUid")]
        public int pUid { get; set; }

        [XmlElement(ElementName = "address")]
        public List<Address> Address { get; set; }
    }


    [XmlRoot(ElementName = "sdnEntry")]
    public class SdnEntry
    {

        [XmlElement(ElementName = "uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "lastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "sdnType")]
        public string SdnType { get; set; }

        [XmlElement(ElementName = "remarks")]
        public string Remarks { get; set; }

        [XmlElement(ElementName = "programList")]
        public ProgramList ProgramList { get; set; }

        [XmlElement(ElementName = "idList")]
        public IdList IdList { get; set; }

        [XmlElement(ElementName = "akaList")]
        public AkaList AkaList { get; set; }

        [XmlElement(ElementName = "addressList")]
        public AddressList AddressList { get; set; }

        [XmlElement(ElementName = "firstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "citizenshipList")]
        public CitizenshipList CitizenshipList { get; set; }

        [XmlElement(ElementName = "dateOfBirthList")]
        public DateOfBirthList DateOfBirthList { get; set; }

        [XmlElement(ElementName = "placeOfBirthList")]
        public PlaceOfBirthList PlaceOfBirthList { get; set; }

        [XmlElement(ElementName = "nationalityList")]
        public NationalityList NationalityList { get; set; }

        [XmlElement(ElementName = "vesselInfo")]
        public VesselInfo VesselInfo { get; set; }
    }

    [XmlRoot(ElementName = "citizenship")]
    public class Citizenship
    {

        [XmlElement(ElementName = "uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "mainEntry")]
        public bool MainEntry { get; set; }
    }

    [XmlRoot(ElementName = "citizenshipList")]
    public class CitizenshipList
    {

        [XmlElement(ElementName = "citizenship")]
        public List<Citizenship> Citizenship { get; set; }
    }

    [XmlRoot(ElementName = "dateOfBirthItem")]
    public class DateOfBirthItem
    {

        [XmlElement(ElementName = "uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [XmlElement(ElementName = "mainEntry")]
        public bool MainEntry { get; set; }
    }

    [XmlRoot(ElementName = "dateOfBirthList")]
    public class DateOfBirthList
    {

        [XmlElement(ElementName = "dateOfBirthItem")]
        public DateOfBirthItem DateOfBirthItem { get; set; }
    }

    [XmlRoot(ElementName = "placeOfBirthItem")]
    public class PlaceOfBirthItem
    {

        [XmlElement(ElementName = "uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "placeOfBirth")]
        public string PlaceOfBirth { get; set; }

        [XmlElement(ElementName = "mainEntry")]
        public bool MainEntry { get; set; }
    }

    [XmlRoot(ElementName = "placeOfBirthList")]
    public class PlaceOfBirthList
    {

        [XmlElement(ElementName = "placeOfBirthItem")]
        public List<PlaceOfBirthItem> PlaceOfBirthItem { get; set; }
    }

    [XmlRoot(ElementName = "nationality")]
    public class Nationality
    {

        [XmlElement(ElementName = "uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "mainEntry")]
        public bool MainEntry { get; set; }
    }

    [XmlRoot(ElementName = "nationalityList")]
    public class NationalityList
    {

        [XmlElement(ElementName = "nationality")]
        public List<Nationality> Nationality { get; set; }
    }

    [XmlRoot(ElementName = "vesselInfo")]
    public class VesselInfo
    {

        [XmlElement(ElementName = "callSign")]
        public string CallSign { get; set; }

        [XmlElement(ElementName = "vesselType")]
        public string VesselType { get; set; }

        [XmlElement(ElementName = "vesselFlag")]
        public string VesselFlag { get; set; }

        [XmlElement(ElementName = "tonnage")]
        public int Tonnage { get; set; }

        [XmlElement(ElementName = "grossRegisteredTonnage")]
        public int GrossRegisteredTonnage { get; set; }
    }

    [XmlRoot(ElementName = "sdnList")]
    public class SdnList
    {

        [XmlElement(ElementName = "publshInformation")]
        public PublshInformation PublshInformation { get; set; }

        [XmlElement(ElementName = "sdnEntry")]
        public List<SdnEntry> SdnEntry { get; set; }

        [XmlAttribute(AttributeName = "xsi")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    public class SdnEntryElement
    {

        [XmlElement(ElementName = "uid")]
        public int Uid { get; set; }

        [XmlElement(ElementName = "lastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "sdnType")]
        public string SdnType { get; set; }

        [XmlElement(ElementName = "address1")]
        public string Address1 { get; set; }
        [XmlElement(ElementName = "address2")]
        public string Address2 { get; set; }
        [XmlElement(ElementName = "address3")]
        public string Address3 { get; set; }
        [XmlElement(ElementName = "address4")]
        public string Address4 { get; set; }

        [XmlElement(ElementName = "city")]
        public string City { get; set; }

        [XmlElement(ElementName = "postalCode")]
        public string postalCode { get; set; }

        [XmlElement(ElementName = "country")]
        public string country { get; set; }

    }


}
