using System;
using System.Web.Mvc;
namespace OnlineGame.Web.Controllers
{
    public class Home3Controller : Controller
    {
        // GET: Home3
        [HttpGet]   //Home3/Index
        public ActionResult Index()
        {
            throw new Exception("Exception occurs");
        }
    }
}