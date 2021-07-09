using System;
using helloweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ds.Tutorial.web.Controllers {
    public class RenderDataController : Controller {
        public IActionResult ViewDataDemo () {
            ViewData["title"] = "ViewData Demo";
            ViewData["name"] = "dongsu";
            ViewData["birthday"] = new DateTime (2000, 3, 10);
            ViewData["hobby"] = new string[] { "筋トレ", "映画鑑賞", "Coding" };
            return View ();
        }

        public IActionResult ViewBagDemo () {
            ViewBag.title = "ViewBag Demo";
            ViewBag.name = "dongsu";
            ViewBag.birthday = new DateTime (2000, 3, 10);
            ViewBag.hobby = new string[] { "筋トレ", "映画鑑賞", "Coding" };
            return View ();
        }

        public IActionResult ViewModelDemo () {
            ViewBag.title = "ViewModel Demo";
            var person = new Person {
                Name = "dongsu",
                Birthday = new DateTime (2000, 3, 10),
                Hobby = new string[] { "筋トレ", "映画鑑賞", "Coding" }

            };
            return View (person);
        }
    }
}