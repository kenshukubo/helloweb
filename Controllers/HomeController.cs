using System;
// 1.MVC名前空間を追加
using Microsoft.AspNetCore.Mvc;

namespace helloweb.Controllers {

    // 2. Controllerを継承
    public class HomeController : Controller {

        // 3. Action Methodの定義
        public IActionResult Index () {
            ViewBag.Title = "Home";
            ViewBag.Message = "Hello world ! - dongsu";
            return View();
        }
    }
}