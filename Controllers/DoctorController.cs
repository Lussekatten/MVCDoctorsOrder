using Microsoft.AspNetCore.Mvc;
using MVCEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEmpty.Controllers
{
    public class DoctorController : Controller
    {
        Temperature mytemp = new Temperature();
        public ViewResult Index()
        {
            return View(mytemp);
        }

        public ViewResult CheckTemp(int temperature)
        {
            mytemp.CheckTemperature(temperature);
            return View("Index", mytemp);
        }

        [HttpPost]
        public ViewResult CheckTemp(Temperature temp)
        {
            mytemp.CheckTemperature(temp.TempInCelsius);
            mytemp.TempInCelsius = temp.TempInCelsius;
            return View("Index", mytemp);
        }
    }
}
