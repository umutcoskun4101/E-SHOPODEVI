﻿using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_TİCARET.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        DataContext db=new DataContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User data)
        {
            var bilgiler = db.Users.FirstOrDefault(x => x.Email == data.Email && x.Password == data.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);
                Session["Mail"] = bilgiler.Email.ToString();
                Session["Ad"] = bilgiler.Name.ToString();
                Session["Soyad"] = bilgiler.Surname.ToString();
                Session["userid"] = bilgiler.Id.ToString();
                return RedirectToActionPermanent("Index","Home");  
            }
            ViewBag.hata = "Mail veya şifreniz hatalı";
            return View(data);
        }

        [HttpPost]
        public ActionResult Register(User data) 
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(data);
                data.Role = "User";
                db.SaveChanges();
                return RedirectToActionPermanent("Login");
            }
            ModelState.AddModelError("", "Hatalı");
            return View("Login",data);
        }

        public ActionResult LogOut() 
        { 
            FormsAuthentication.SignOut();
            return RedirectToActionPermanent("Index", "Home");
        }
    }
}