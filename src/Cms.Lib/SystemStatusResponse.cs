using System;
using System.Xml.Serialization;

namespace Cms.Lib
{
    [Serializable, XmlRoot("status")]
    public class SystemStatusResponse
    {
        [XmlElement("softwareVersion")]
        public string SoftwareVersion { get; set; }
        [XmlElement("uptimeSeconds")]
        public int UptimeSeconds { get; set; }
        [XmlElement("cdrTime")]
        public string CdrTime { get; set; }
        [XmlElement("activated")]
        public bool Activated { get; set; }
        [XmlElement("clusterEnabled")]
        public bool ClusterEnabled { get; set; }
        [XmlElement("cdrCorrelatorIndex")]
        public int CdrCorrelatorIndex { get; set; }
        [XmlElement("callLegsActive")]
        public int CallLegsActive { get; set; }
        [XmlElement("callLegsMaxActive")]
        public int CallLegsMaxActive { get; set; }
        [XmlElement("callLegsCompleted")]
        public int CallLegsCompleted { get; set; }
        [XmlElement("audioBitRateOutgoing")]
        public int AudioBitRateOutgoing { get; set; }
        [XmlElement("audioBitRateIncoming")]
        public int AudioBitRateIncoming { get; set; }
        [XmlElement("videoBitRateOutgoing")]
        public int VideoBitRateOutgoing { get; set; }
        [XmlElement("videoBitRateIncoming")]
        public int VideoBitRateIncoming { get; set; }
    }
}
