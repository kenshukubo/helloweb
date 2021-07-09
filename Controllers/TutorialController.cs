using System;
using Microsoft.AspNetCore.Mvc;

namespace helloweb.Controllers {

    public class TutorialController : Controller {

        public IActionResult Index () {
            return Content ("ASP.NET Core Tutorial");
        }

        public IActionResult Welcome (string name, int age) {
            return Content ($"Welcome {name} (age: {age})!");
        }
    }
}