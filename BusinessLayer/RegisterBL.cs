using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Innova_TRIAL.Models.Register;


namespace Innova_TRIAL.BusinessLayer
{
    public class RegisterBL
    {
        public CallWebApi cwApi;

        public RegisterBL()
        {
            cwApi = new CallWebApi();
        }
        public string SaveUser (UserRegistration model)
        {
          
            string result = cwApi.WebApiAccess(model, "SaveUser", "Register").Result;
            return result;
        }

    }
}