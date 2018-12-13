using System.Collections.Generic;
using System.Web.Mvc;
namespace OnlineGame.Web.Controllers
{
    public class HomeController : Controller
    {
        //http://localhost/OnlineGame.Web/home/index/aa?name=bbb
        //http://localhost/OnlineGame.Web/home/index/aa?name2=bbb
        //public string Index(string id, string name)
        //{
        //    // return string.Format("Hey, Id ={0} , name ={1}", id, name);
        //    return $"Hey, Id ={id} , name ={name}";
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult Index()
        //{
        //    ViewBag.Names = new List<string>
        //        {
        //            "Name01",
        //            "Name02",
        //            "Name03"
        //        };
        //    return View();
        //}

        public ActionResult Index()
        {
            ////1.
            //ViewBag.Names = new List<string>
            //{
            //    "ViewBag.Names01",
            //    "ViewBag.Names02",
            //    "ViewBag.Names03"
            //};
            ////2.
            //ViewData["Names"] = new List<string>
            //{
            //    "ViewData[\"Names\"]01",
            //    "ViewData[\"Names\"]02",
            //    "ViewData[\"Names\"]03"
            //};
            //3.
            ViewBag.Names = new List<string>
            {
                "ViewBag.Names01",
                "ViewBag.Names02",
                "ViewBag.Names03"
            };
            ViewData["Names"] = new List<string>
            {
                "ViewData[\"Names\"]01",
                "ViewData[\"Names\"]02",
                "ViewData[\"Names\"]03"
            };
            //4.
            //ViewBag.Names = new List<string>
            //{
            //    "ViewBag.Names01",
            //    "ViewBag.Names02",
            //    "ViewBag.Names03"
            //};
            //ViewData["Names2"] = new List<string>
            //{
            //    "ViewData[\"Names\"]01",
            //    "ViewData[\"Names\"]02",
            //    "ViewData[\"Names\"]03"
            //};
            return View();
        }


        public string GetStringA()
        {
            return "AAAAAA";
        }
    }
}