using System.Web.Mvc;
namespace OnlineGame.Web.Controllers
{
    public class ErrorController : Controller
    {

        //error statusCode="401"
        [HttpGet]
        public ActionResult UnauthorizedError()
        {
            return View();
        }
        //error statusCode="404"
        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
        //error statusCode="500"
        [HttpGet]
        public ActionResult InternalServerError()
        {
            return View();
        }

        //error statusCode="403.4"
        [HttpGet]
        public ActionResult RedirectToHttps()
        {
            return View();
        }
    }
}