using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalorieCounter.Models
{
    public class Exercise
    {
        public string ExName { get; set; }
        public double Calories { get; set; } // 100kg/1h

        public Exercise(string exName, double calories)
        {
            ExName = exName;
            Calories = calories;
        }
    }
}