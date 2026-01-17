using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Meterology;

[XmlRoot("wario")]
public class Wario
{
    [JsonPropertyName("degree")]
    [XmlAttribute("degree")]
    public string Degree { get; set; }

    [JsonPropertyName("pressure")]
    [XmlAttribute("pressure")]
    public string PressureUnit { get; set; }

    [JsonPropertyName("serial_number")]
    [XmlAttribute("serial_number")]
    public string SerialNumber { get; set; }

    [JsonPropertyName("model")]
    [XmlAttribute("model")]
    public string Model { get; set; }

    [JsonPropertyName("firmware")]
    [XmlAttribute("firmware")]
    public string Firmware { get; set; }

    [JsonPropertyName("runtime")]
    [XmlAttribute("runtime")]
    public int Runtime { get; set; }

    [JsonPropertyName("freemem")]
    [XmlAttribute("freemem")]
    public int FreeMem { get; set; }

    [JsonPropertyName("date")]
    [XmlAttribute("date")]
    public string Date { get; set; }

    [JsonPropertyName("time")]
    [XmlAttribute("time")]
    public string Time { get; set; }

    [JsonPropertyName("language")]
    [XmlAttribute("language")]
    public int Language { get; set; }

    [JsonPropertyName("pressure_type")]
    [XmlAttribute("pressure_type")]
    public int PressureType { get; set; }

    [JsonPropertyName("r")]
    [XmlAttribute("r")]
    public int R { get; set; }

    [JsonPropertyName("bip")]
    [XmlAttribute("bip")]
    public int Bip { get; set; }

    [JsonPropertyName("input")]
    [XmlElement("input")]
    public Input InputContainer { get; set; }

    [JsonPropertyName("output")]
    [XmlElement("output")]
    public Output OutputContainer { get; set; }

    [JsonPropertyName("variable")]
    [XmlElement("variable")]
    public Variable VariableContainer { get; set; }

    [JsonPropertyName("minmax")]
    [XmlElement("minmax")]
    public MinMax MinMaxContainer { get; set; }

    public static Wario FromXml(string xmlContent)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Wario));
        using (StringReader reader = new StringReader(xmlContent))
        {
            return (Wario)serializer.Deserialize(reader);
        }
    }

}
