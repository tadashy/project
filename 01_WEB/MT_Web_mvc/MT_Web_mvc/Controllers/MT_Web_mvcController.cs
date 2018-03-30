using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MT_Web_mvc.Controllers
{
    public class MT_Web_mvcController : Controller
    {
        // GET: MT_Web_mvc
        public ActionResult Index()
        {
            ViewData["msg"] = "こんにちは！ MVC頑張ろう！";
            return View();
        }
    }
}