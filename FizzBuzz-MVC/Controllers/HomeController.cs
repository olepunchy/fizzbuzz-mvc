// using System;
using System.Collections.Generic;
using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzBuzz_MVC.Models;

namespace FizzBuzz_MVC.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult Application() {
            FizzBuzz model = new();

            model.StartValue = 1;
            model.EndValue = 100;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Application(FizzBuzz fizzBuzz) {
            List<string> results = new();

            bool fizz;
            bool buzz;

            for (int index = fizzBuzz.StartValue; index <= fizzBuzz.EndValue; index++) {
               fizz = (index % 3) == 0;
               buzz = (index % 5) == 0;

               string className = string.Empty;

               if (fizz && buzz) {
                   className = "fizzbuzz";
               } else if (fizz) {
                   className = "fizz";
               } else if (buzz) {
                   className = "buzz";
               } else {
                   className = "";
               }

               fizzBuzz.Results.Add((className, index.ToString()));
            }
            
            return View(fizzBuzz);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
