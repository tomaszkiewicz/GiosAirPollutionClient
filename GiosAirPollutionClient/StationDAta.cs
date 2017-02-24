using System;
using System.Collections.Generic;

namespace GiosAirPollutionClient
{
    public class StationData
    {
        public string CityName { get; set; }
        public string StationName { get; set; }
        public int AirQualityIndex { get; set; }
        public Dictionary<string, decimal> Measurements { get; set; }
        public DateTime Time { get; set; }
    }
}