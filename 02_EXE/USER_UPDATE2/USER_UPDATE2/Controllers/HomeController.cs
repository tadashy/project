using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USER_UPDATE2.Models;

namespace USER_UPDATE2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new Greeting();

            model.Message = "Hello World !";
            
            return this.View(model);
        }
    }
}