using System;
using Microsoft.AspNetCore.Mvc;

namespace helloweb.Controllers {
    public class PartialController : Controller {
        public IActionResult Demo () {
            return View ();
        }

        public IActionResult DemoWithParams () {
            return View ();
        }
    }
}