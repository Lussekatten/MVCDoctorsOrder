using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using MVCEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MVCEmpty.Controllers
{
    public class GuessController : Controller
    {
        private readonly GuessNumber _guessNumberGame = new GuessNumber();

        public ViewResult Index()
        {
            return View(_guessNumberGame);
        }

        [HttpPost]
        public ViewResult CheckNumber(GuessNumber gn)
        {
            if (gn.CheckTheGuess())
            {
                //Kill the session somehow
                //ISession session = null;
            }                     
            return View("Index", gn);
        }
    }
}
