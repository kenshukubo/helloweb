using System;
using Microsoft.AspNetCore.Mvc;
using helloweb.Models;
using helloweb.Models.Interface;

namespace helloweb.Controllers {

    public class GreetController : Controller {
        private IGreeting _greeting;

        // DIしたインスタンスはここで取り出し
        public GreetController(IGreeting greeting) {
            this._greeting = greeting;
        }

        public IActionResult Index()
        {
            this.ViewBag.Greet = this._greeting.Greet();
            return View();
        }
    }
}