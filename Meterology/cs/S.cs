using System;
using System.Xml.Serialization;

namespace Meterology;
[XmlRoot("s")]
public class S
{
    [XmlAttribute("id")]
    public int Id {get; set;}
    [XmlAttribute("min")]
    public double Min {get; set;}
    [XmlAttribute("max")]
    public double Max {get; set;}
}
