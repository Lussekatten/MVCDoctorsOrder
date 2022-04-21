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
            GenerateNewSession();
            _guessNumberGame.userGuess = "0";
            return View(_guessNumberGame);
        }


        [HttpPost]
        public ViewResult CheckNumber(GuessNumber gn)
        {
            int test = 0;
            try
            {
                test = int.Parse(gn.userGuess);
            }
            catch (Exception)
            {
                gn.Message = "Try entering a valid number";
                return View("Index", gn);
            }
            string hidden = HttpContext.Session.GetString("_RandomizedInteger");
            if (test == int.Parse(hidden))
            {
                gn.Message = "You guessed correctly. Congratulations! Creatig a new hidden number";
                //Reset session and start all over with a new set of session data
                HttpContext.Session.Clear();
                GenerateNewSession();
                gn.userGuess = "0";
                gn.NoOfGuesses = 0;
            }
            else if (test > int.Parse(hidden))
            {
                gn.Message = "Your guess is too high";
                gn.NoOfGuesses++;
            }
            else
            {
                gn.Message = "Your guess is too low";
                gn.NoOfGuesses++;
            }
            return View("Index", gn);
        }
        private void GenerateNewSession()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("_RandomizedInteger")))
            {
                Random rnd = new Random();
                string _rndGeneratedNumber = rnd.Next(1, 99).ToString();
                HttpContext.Session.SetString("_RandomizedInteger", _rndGeneratedNumber);

            }
        }
    }
}
