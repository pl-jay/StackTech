using Microsoft.AspNetCore.Mvc;
using PL.WR.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherReport.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherRecordBll weatherRecordBll;
        public WeatherController()
        {
            weatherRecordBll = new WeatherRecordBll();
        }
        
        [HttpGet]
        public JsonResult Index()
        
        {
            
            var data = weatherRecordBll.GetLatestWeather();
            return Json(data);
        }
    }
}
