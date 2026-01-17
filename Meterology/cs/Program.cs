using System;
using System.Text.Json;
using MySqlConnector;
using Dapper;
using Meterology;

namespace MyApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while(true)
            {
                await ExecuteTask();
                await Task.Delay(TimeSpan.FromHours(1));
            }
        }

        static async Task ExecuteTask()
        {
            WeatherLog log = new WeatherLog
            {
                DownloadedTime = DateTime.Now
            };
            string url = "https://pastebin.com/raw/PMQueqDV";

            using (HttpClient client = new  HttpClient())
            {
                try
                {
                    string xmlContent = await client.GetStringAsync(url);

                    Wario data = Wario.FromXml(xmlContent);
                    log.Data = data;
                    log.isSuccess = true;
                }
                catch(Exception ex)
                {
                    log.isSuccess = false;
                    log.ErrorMessage = ex.Message;
                }
            }

            SaveWeatherLog(log);

        }
        public static void SaveWeatherLog(WeatherLog log)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string? jsonString = log.isSuccess ? JsonSerializer.Serialize(log.Data, options) : null;
            string conn = " Server = localhost; Database = weather_logs; Uid = root; Pwd = ";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                string sql = @"INSERT INTO weatherlogs (downloadedAt, isSuccess, jsonData, errorMessage)
                                VALUES (@DownloadedTime, @isSuccess, @JsonData, @ErrorMessage)";

                connection.Execute(sql, new
                {
                    log.DownloadedTime,
                    log.isSuccess,
                    JsonData= jsonString,
                    log.ErrorMessage
                });
            }
        }
    }
}