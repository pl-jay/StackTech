using PL.WR.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.WR.BLL
{
    public interface IWeatherRecordBll
    {
        public WeatherVM GetLatestWeather();
    }
}
