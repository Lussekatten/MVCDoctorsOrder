using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEmpty.Models
{
    public interface ITemperature
    {      
        string CheckTemperature(int temp);
    }
}
