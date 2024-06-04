using Microsoft.AspNetCore.Mvc;
using ProductModel.Models;
using System;
using System.Linq;

namespace ProductModel.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login data)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index","Home");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Register(Register data)
        {
            if (data.UserName==data.Password) 
            {
                ModelState.AddModelError("","Пароль и логин не должны совпадать!");
            }
            if (ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            //ModelState.AddModelError("", String.Join("\n", ModelState.Values.SelectMany(e=>e.Errors).Select(e=>e.ErrorMessage)));
            return View("RegForm");
        }
    }
}
