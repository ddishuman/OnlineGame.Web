using System.Web.Mvc;
//[RequireHttps] attribute will enforce to redirect to https
//It can apply to controller level or action level
//[RequireHttps]
namespace OnlineGame.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public string Index2()
        {
            return "Index2 is accessible via HTTP or HTTPS";
        }
        public ActionResult Index3()
        {
            return View();
        }
        //[RequireHttps] attribute will enforce to redirect to https
        [RequireHttps]
        public string Index4()
        {
            return "Index4 is accessible via HTTPS";
        }
        [RequireHttps]
        public ActionResult Index5()
        {
            return View();
        }
    }
}

