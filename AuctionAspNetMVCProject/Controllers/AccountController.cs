using AuctionAspNetMVCProject.Data.Entities;
using AuctionAspNetMVCProject.Data.Interfaces;
using AuctionAspNetMVCProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuctionAspNetMVCProject.Controllers
{
    public class AccountController : Controller

    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_userRepository.Get(model.Email, model.PassWord) != null)
                    {
                        //User Auth
                        var auth = new ClaimsIdentity(
                            new[] { new Claim(ClaimTypes.Name, model.Email) },
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        //Creating cookie
                        var claim = new ClaimsPrincipal(auth);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claim);

                        //redirect to /Home/Index
                        //VIEW  CONTROLLER
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Message"] = $"Invalid user or password";
                    }
                }
                catch (Exception e)
                {

                    TempData["Message"] = "Erro: " + e.Message;
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            //Delete user cookie
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User();
                    user.Name = model.Name;
                    user.Email = model.Email;
                    user.PassWord = model.PassWord;
                    user.BirthDate = model.BirthDate;

                    //email verification
                    if (_userRepository.Get(user.Email) != null)
                    {
                        TempData["Message"] = $"Email {user.Email} already exists";
                    }
                    else
                    {
                        //creating
                        _userRepository.Create(user);
                        TempData["Message"] = $"User {user.Name} registred successfully";
                        ModelState.Clear();
                    }


                }
                catch (Exception e)
                {

                    TempData["Message"] = "Erro: " + e.Message;
                }


            }
            return View();
        }
    }
}


