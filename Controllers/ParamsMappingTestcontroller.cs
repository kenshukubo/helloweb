using System;
using Microsoft.AspNetCore.Mvc;

namespace helloweb.Controllers {
    public class ParamsMappingTestcontroller : Controller {
        public IActionResult GetId (int id) {
            return Content ($"Action params mapping id : {id}");
        }

        public IActionResult GetArray (string[] id) {
            var message = "Action params mapping";
            if (id != null) {
                message += string.Join (",", id);
            }

            return Content (message);
        }
    }
}