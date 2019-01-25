using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cms.Lib
{
    [Serializable, XmlRoot("alarms")]
    public class SystemAlarStatusResponse
    {
        [XmlElement("alarm")]
        public List<SystemAlarm> Alarm { get; set; }
        [XmlAttribute("total")]
        public string Total { get; set; }
    }
}