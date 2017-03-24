using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (base.Request.AcceptTypes != null && base.Request.AcceptTypes.Any(x => x == "text/html"))
            {
                return View();
            }
            
            string uri = base.Request.UserAgent.ToLower().Contains("powershell") 
            ? "https://raw.githubusercontent.com/dotnetzero/script/feature/adds-bash-support/init.ps1" 
            : "https://raw.githubusercontent.com/dotnetzero/script/feature/adds-bash-support/init.sh" ;

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(uri);
            var responseMessage = httpClient.GetAsync("").Result;
            
            var result = new ContentResult(){ };

            var content = responseMessage.Content.ReadAsStringAsync().Result;

            result.Content =  content;
            return result;
        }
    }
}