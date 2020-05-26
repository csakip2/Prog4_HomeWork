using CalorieCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalorieCounter.Controllers
{
    public class CalorieCounterController : Controller
    {
        List<Exercise> exercises = new List<Exercise>();
        public void FillList()
        {
            exercises.Add(new Exercise("Running", 1000));
            exercises.Add(new Exercise("Yoga", 400));
            exercises.Add(new Exercise("Pilates", 472));
            exercises.Add(new Exercise("Hiking", 700));
            exercises.Add(new Exercise("Swimming", 1000));
            exercises.Add(new Exercise("Bicycle", 600));
        } 

        //GET: /CalorieCounter/Calories
        public ActionResult Calories()
        {

            FillList();

            return View("CalorieInput", exercises);
        }

        // POST: /CalorieCounter/Calories
        [HttpPost]
        public ActionResult Calories(CalorieInput input)
        {
            FillList();
            CalorieResult cr = new CalorieResult()
            {
                Name = input.Name,
                Weight = input.Weight,
                Exercise = input.Exercise,
                Duration = input.Duration,
                Calories = (input.Weight / 100) * exercises.Where(x => x.ExName == input.Exercise).Select(x => x.Calories).Single() * input.Duration / 60
            };

            return View("CalorieResult", cr);
        }
    }
}