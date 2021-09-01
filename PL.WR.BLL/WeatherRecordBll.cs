using PL.WR.DAL;
using PL.WR.DAL.Models;
using PL.WR.VM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PL.WR.BLL
{
    public class WeatherRecordBll : IWeatherRecordBll
    {
        private UnitOfWork<aspnetStackTechTestContext> uow;

        public WeatherRecordBll()
        {
            uow = new UnitOfWork<aspnetStackTechTestContext>();
        }

        public WeatherVM GetLatestWeather()
        {
            try
            {
                var data = uow.WeatherRecord.Get(filter: x => x.Id == 1).Select(y => new WeatherVM
                {
                    Id = y.Id,
                    Humidity = y.Humidity,
                    MaxTemperature = y.MaxTemperature,
                    MinTemperature = y.MinTemperature,
                    Temperature = y.Temperature,
                    Timestamp = y.Timestamp

                }).OrderByDescending(x => x.Id).FirstOrDefault();
                return data;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
           
        }
    }
}
