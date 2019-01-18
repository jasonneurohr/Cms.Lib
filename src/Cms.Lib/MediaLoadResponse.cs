using System;
using System.Xml.Serialization;

namespace Cms.Lib
{
    [Serializable, XmlRoot("load")]
    public class MediaLoadResponse
    {
        [XmlElement("mediaProcessingLoad")]
        public int MediaProcessingLoad { get; set; }
    }
}
