using Innova_TRIAL.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Innova_TRIAL.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterBL register;
        public RegisterController()
        {
            register = new RegisterBL();
        }
        // GET: Register
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(Innova_TRIAL.Models.Register.UserRegistration model)
        {

            if (ModelState.IsValid)
            {
                string result = register.SaveUser(model);

                if (result == "success") //we can also use bool
                {
                    Guid guid = new Guid();
                    //Send verification mail to the user with verification code 

                    MailSystem ms = new MailSystem();
                    bool isSuccess = ms.SendMail(model.FirstName, model.Email, guid.ToString());

                    if (isSuccess)
                    {
                        ViewBag.Message = "Mail is sent  with a Verification code to your email id ,please enter the verification code to complete the registration process";
                        TempData["verificationcode"] = guid;
                        TempData["EmailID"] = model.Email;

                        return View("RegisterUserStep2");
                    }

                }
              
            }


            return View(model);
        }

        public ActionResult RegisterUserStep2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUserStep2(Innova_TRIAL.Models.Register.UserRegistration model)
        {

            if (model.Verficationcode == Convert.ToString(TempData["verificationcode"]))
            {
                model.IsVerified = true;
                model.Email = (string)TempData["EmailID"];
                string result = register.SaveUser(model);
                if (result == "success")
                {
                    ViewBag.Message = "Successfully registered";
                    RedirectToAction("Welcome");
                }
            }
            else
            {
                ViewBag.Message = "Verfication code entered is invalid.Please enter a valid code";
               
            }

            return View(model);
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}