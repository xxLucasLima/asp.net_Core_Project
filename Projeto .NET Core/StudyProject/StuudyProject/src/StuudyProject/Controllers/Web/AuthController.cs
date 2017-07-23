using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StuudyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuudyProject.Controllers.Web
{
    public class AuthController: Controller
    {
        private SignInManager<WorldUser> _manager;

        public AuthController(SignInManager<WorldUser> manager)
        {
            _manager = manager;
        }
        public  IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Trips", "App");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var managerResult = await _manager.PasswordSignInAsync(vm.Username, vm.Password, true, false);

                if (managerResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Trips", "App");

                    }
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Incorrect");
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _manager.SignOutAsync();
            }

            return RedirectToAction("Index", "App");
        }
    }
}
