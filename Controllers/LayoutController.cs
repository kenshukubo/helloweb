using System;
using Microsoft.AspNetCore.Mvc;

namespace helloweb.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult SectionDemo()
        {
            return View();
        } 
    }
}