using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicesListGenerator.ViewModels
{
    public class AccueilViewModel
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public List<Models.Exo> ListDesExercices { get; set; }
    }
}