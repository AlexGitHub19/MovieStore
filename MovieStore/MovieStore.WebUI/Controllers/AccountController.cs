﻿using System.Web.Mvc;
using MovieStore.WebUI.Infrastructure.Abstract;
using MovieStore.WebUI.Models;


namespace MovieStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Not corrext login or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}