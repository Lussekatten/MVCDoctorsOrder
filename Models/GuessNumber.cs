using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEmpty.Models
{
    public class GuessNumber
    {
        public GuessNumber()
        {
            //_guessGameId = id;
            if (String.IsNullOrEmpty(_rndGeneratedNumber))
            {
                Random rnd = new Random();
                _rndGeneratedNumber = rnd.Next(1,99).ToString();
            }
        }
        private static string _guessGameId;
        private static string _rndGeneratedNumber;
        public string userGuess { get; set; }
        public string Message { get; set; }

        //public static GuessNumber GetGame(IServiceProvider services)
        //{
        //    ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        //    string gameId = session.GetString("GameId") ?? Guid.NewGuid().ToString();
        //    session.SetString("GameId", gameId);
            
        //    return new GuessNumber(gameId);
        //}

        public bool CheckTheGuess()
        {
            if (int.Parse(userGuess) == int.Parse(_rndGeneratedNumber))
            {
                Message = "Your guessed correctly. Congratulations!";
                return true;
            }
            else if (int.Parse(userGuess) > int.Parse(_rndGeneratedNumber))
            {
                Message = "Your guess is too high";
                return false;
            }
            else
            {
                Message = "Your guess is too low";
                return false;
            }
        }

        //private void ResetGame(IServiceProvider services)
        //{
        //    ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        //    session.Remove("GameId");
        //}
    }
}
