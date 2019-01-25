using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cms.Lib
{
    [Serializable, XmlRoot("database")]
    public class SystemDatabaseStatusResponse
    {
        [XmlElement("cluster")]
        public List<SystemDatabaseCluster> Cluster { get; set; }
        [XmlAttribute("clustered")]
        public string Clustered { get; set; }
    }
}
