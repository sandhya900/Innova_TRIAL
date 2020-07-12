using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Innova_TRIAL
{
    public class CallWebApi
    {
        private string apiUrl = "https://localhost:44398/api/";

        public async Task<string> WebApiAccess(dynamic model,string methodName,string ControllerName)
        {

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                try
                {
                    client.BaseAddress = new Uri(apiUrl + ControllerName + "/" + methodName);
                    var myContent = JsonConvert.SerializeObject(model);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new StringContent(myContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return "Success";
                    }
                }
                catch (Exception ex)
                {
                    //LOG ERROR INTO 
                }
             
            }
            return "failure";
        }
    }
}

