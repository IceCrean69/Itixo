using System;
using System.Xml.Serialization;

namespace Meterology;

public class Output
{
    [XmlElement("sensor")]
    public List<Sensor> Sensors {get; set;}= new List<Sensor>();
}
