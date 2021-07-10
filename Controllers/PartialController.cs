using System;
using Microsoft.AspNetCore.Mvc;

namespace ds.Tutorial.web.Controllers {
    public class PartialController : Controller {
        public IActionResult Demo () {
            return View ();
        }
    }
}