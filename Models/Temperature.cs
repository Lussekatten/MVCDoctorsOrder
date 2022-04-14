using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEmpty.Models
{
    public class Temperature : ITemperature
    {
        //public Temperature()
        //{
        //    TempInCelsius = 30;
        //}
        public int TempInCelsius { get; set; }
        public string Message { get; set; }
        readonly int _tempReference = 36;
        public string CheckTemperature(int temp)
        {
            if (temp > _tempReference)
            {
                Message = "You have a fever";
                return Message;
            }
            else if (temp < _tempReference)
            {
                Message = "You have hypothermia";
                return Message;
            }
            else
            {
                Message = "You are just fine";
                return Message;
            }
        }
    }
}
