using System;
using System.Collections.Generic;

#nullable disable

namespace PL.WR.DAL.Models
{
    public partial class WeatherRecord
    {
        public int Id { get; set; }
        public int Humidity { get; set; }
        public int Temperature { get; set; }
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
