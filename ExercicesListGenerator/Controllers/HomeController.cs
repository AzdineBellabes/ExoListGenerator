using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExercicesListGenerator.Models;
using ExercicesListGenerator.ViewModels;

namespace ExercicesListGenerator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "welcome !";
        }
    }
}