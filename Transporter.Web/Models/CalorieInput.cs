using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalorieCounter.Models
{
    public class CalorieInput
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Exercise { get; set; }
        public double Duration { get; set; }
    }
}