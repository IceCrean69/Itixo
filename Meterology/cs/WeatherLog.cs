using System;

namespace Meterology;

public class WeatherLog
{
    public DateTime DownloadedTime {get; set;}
    public bool isSuccess {get; set;}
    public string ErrorMessage {get; set;}
    public Wario Data {get; set;}
}
