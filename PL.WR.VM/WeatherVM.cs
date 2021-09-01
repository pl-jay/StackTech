using System;
using System.Collections.Generic;
using System.Text;

namespace PL.WR.VM
{
    public class WeatherVM
    {
        public int Id { get; set; }
        public int Humidity { get; set; }
        public int Temperature { get; set; }
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
