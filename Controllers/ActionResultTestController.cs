using System;
using Microsoft.AspNetCore.Mvc;

namespace helloweb.Controllers{
    public class ActionResultTestController : Controller{

        public IActionResult ContentTest () {
            return Content ("Content Resutl Test");
        }

        public IActionResult JsonTest () {
            return Json (new { Message = "Json Result", Author = "dongsu" });
        }

        // public IActionResult FileTest () {
        //     var bytes = Encoding.Default.GetBytes ("FileResult Test");
        //     return File (bytes, "application/text", "filetest.txt");
        // }

        public IActionResult RedirectTest () {
            return Redirect ("https://dongsu.dev");
        }

        public IActionResult RedirectToActionTest () {
            return RedirectToAction ("jsontest");
        }

        public IActionResult RedirectToRouteTest () {
            return RedirectToRoute ("Default", new { Controller = "home", Action = "index" });
        }
    }
}