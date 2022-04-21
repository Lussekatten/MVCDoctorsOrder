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

        public string userGuess { get; set; }
        public string Message { get; set; }
        public int NoOfGuesses { get; set; } = 0;
    }
}
