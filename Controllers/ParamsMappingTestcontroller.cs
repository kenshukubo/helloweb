using System;
using Microsoft.AspNetCore.Mvc;
// Model使う際に必要なおまじない
using helloweb.Models;
// List使う際に必要なおまじない
using System.Collections.Generic;

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

        public IActionResult GetPerson (Person person) {
            return Json (new { message = "Action params mapping", data = person });
        }

        public IActionResult GetPersonList (List<Person> persons) {
            return Json (new { message = "Action params mapping", data = persons });
        }
    }
}