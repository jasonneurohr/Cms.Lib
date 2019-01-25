using System;
using System.Xml.Serialization;

namespace Cms.Lib
{
    [Serializable, XmlRoot("node")]
    public class SystemDatabaseNode
    {
        [XmlAttribute("hostname")]
        public string Hostname { get; set; }
        [XmlAttribute("syncBehind")]
        public string SyncBehind { get; set; }
        [XmlAttribute("master")]
        public string Master { get; set; }
        [XmlAttribute("up")]
        public string Up { get; set; }
    }
}
