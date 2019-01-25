using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cms.Lib
{
    [Serializable, XmlRoot("cluster")]
    public class SystemDatabaseCluster
    {
        [XmlElement("node")]
        public List<SystemDatabaseNode> Nodes { get; set; }
        [XmlAttribute("error")]
        public string Error { get; set; }
        [XmlAttribute("totalNodes")]
        public string TotalNodes { get; set; }
        [XmlAttribute("nodeInUse")]
        public string NodeInUse { get; set; }
    }
}
