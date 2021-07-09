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
    }
}