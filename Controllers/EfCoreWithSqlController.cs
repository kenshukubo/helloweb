// using System;
// using helloweb.Models;
// using helloweb.Repositories;
// using Microsoft.AspNetCore.Mvc;

// namespace helloweb.Controllers {
//     public class EfCoreWithSqlController : Controller {
//         private TutorialWithSqlRepository _repository;

//         public EfCoreWithSqlController (TutorialWithSqlRepository repository) {
//             _repository = repository;
//         }

//         public IActionResult Create (UserEntity user) {
//             var message = _repository.Create (user) > 0 ? "ok" : "ng";
//             return Json (new { Message = message, User = user });
//         }

//         public IActionResult Update (UserEntity user) {
//             var message = _repository.Update (user) > 0 ? "ok" : "ng";
//             return Json (new { Message = message, User = user });
//         }

//         public IActionResult Delete (int id) {
//             var message = _repository.Delete (id) > 0 ? "ok" : "ng";
//             return Json (new { Message = message });
//         }

//         public IActionResult GetOneById (int id) {
//             var user = _repository.GetOneById (id);
//             return Json (new { User = user });
//         }

//         public IActionResult GetAllByAge (int age) {
//             var users = _repository.GetAllByAge (age);
//             return Json (new { User = users });
//         }

//         public IActionResult GetNamesByAge (int age) {
//             var names = _repository.GetNamesByAge (age);
//             return Json (new { Names = names });
//         }

//         public IActionResult GetAllPaging (int pageSize, int page) {
//             var users = _repository.GetAllPaging (pageSize, page);
//             return Json (new { Users = users });
//         }

//         public IActionResult FixAge () {
//             var count = _repository.FixAge ();
//             return Json (new { FixCount = count });
//         }

//     }
// }