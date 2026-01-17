using System;
using System.Xml.Serialization;

namespace Meterology;

public class Input
{
    [XmlElement("sensor")]
    public List<Sensor> Sensors {get;set;} = new List<Sensor>();
}
