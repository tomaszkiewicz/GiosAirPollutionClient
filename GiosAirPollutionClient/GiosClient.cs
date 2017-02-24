using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GiosAirPollutionClient
{
    public static class GiosClient
    {
        public static async Task<IEnumerable<StationData>> DownloadData()
        {
            const string url = "http://powietrze.gios.gov.pl/pjp/current/getAQIDetailsList?param=AQI";

            var measurements = new List<StationData>();

            using (var wc = new WebClient { Proxy = null })
            {
                var pageBody = await wc.DownloadDataTaskAsync(url);

                dynamic body = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(pageBody));

                foreach (var item in body)
                {
                    var stationMeasurement = new StationData()
                    {
                        CityName = ((string)item.stationName).CutTo(","),
                        StationName = ((string)item.stationName).CutFrom(",").Trim(),
                        Measurements = new Dictionary<string, decimal>(),
                        AirQualityIndex = item.aqIndex,
                        Time = DateTime.UtcNow
                    };

                    foreach (var value in item.values)
                        stationMeasurement.Measurements.Add((string)value.Name, (decimal)value.Value);

                    measurements.Add(stationMeasurement);
                }
            }

            return measurements;
        }
    }
}