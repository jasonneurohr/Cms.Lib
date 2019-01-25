using System;
using System.Xml.Serialization;

namespace Cms.Lib
{
    [Serializable, XmlRoot("alarm")]
    public class SystemAlarm
    {
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("activeTimeSeconds")]
        public string ActiveTimeSeconds { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}
