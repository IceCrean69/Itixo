using System.Xml.Serialization;

namespace Meterology;

public class MinMax
{
    [XmlElement("s")]
    public List<S> S {get; set;} = new List<S>();
}
