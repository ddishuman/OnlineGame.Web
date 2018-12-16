using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using OnlineGame.Web.Models;
using PagedList;

namespace OnlineGame.Web.Controllers
{
    public class GamerController : Controller
    {
        private OnlineGameEntities db = new OnlineGameEntities();

        [HttpGet]
        public async Task<ActionResult> Index(string searchBy, string searchText, int? pageNumber, string sortBy)
        {
            ViewBag.NameSort = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.GenderSort = sortBy == "Gender" ? "Gender desc" : "Gender";

            List<Gamer> gamers = await db.Gamers.ToListAsync();
            if (searchBy == "Gender")
            {
                gamers = await db.Gamers
                    .Where(x => x.Gender == searchText || searchText == null)
                    .ToListAsync();
            }
            if (searchBy == "Name")
            {
                gamers = await db.Gamers
                    .Where(x => x.Name.Contains(searchText) || searchText == null)
                    .ToListAsync();
            }

            IOrderedEnumerable<Gamer> gamersOrderedEnumerable;
            switch (sortBy)
            {
                case "Name desc":
                    gamersOrderedEnumerable = gamers.OrderByDescending(x => x.Name);
                    break;
                case "Gender desc":
                    gamersOrderedEnumerable = gamers.OrderByDescending(x => x.Gender);
                    break;
                case "Gender":
                    gamersOrderedEnumerable = gamers.OrderBy(x => x.Gender);
                    break;
                default:
                    gamersOrderedEnumerable = gamers.OrderBy(x => x.Name);
                    break;
            }


            //IPagedList<Gamer> gamerPagedList = gamers.ToPagedList(pageNumber ?? 1, 5);
            IPagedList<Gamer> gamerPagedList = gamersOrderedEnumerable.ToPagedList(pageNumber ?? 1, 5);
            return View(gamerPagedList);
        }


        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index3()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index4()
        {
            Gamer gamer = new Gamer
            {
                Id = 1,
                Name = "Name1",
                Gender = "Male",
                Score = 2000
            };
            return View(gamer);
        }
        public ActionResult Details()
        {
            Gamer gamer = new Gamer
            {
                Id = 1,
                Name = "Name1",
                Gender = "Male",
                Score = 2000
            };
            return View("_GamerDetails", gamer);
        }
        //In order to prevent layout view apply to partial view.
        //A. Return type is PartialViewResult.
        //B. return PartialView("_PartialViewName", ModelObject);
        public PartialViewResult Details2()
        {
            Gamer gamer = new Gamer
            {
                Id = 1,
                Name = "Name1",
                Gender = "Male",
                Score = 2000
            };
            return PartialView("_GamerDetails", gamer);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteMultiple(IEnumerable<int> GamerIdsToDelete, 
            string searchBy, string searchText, int? pageNumber, string sortBy)
        {
            List<Gamer> gamers = await db.Gamers.Where(g => GamerIdsToDelete.Contains(g.Id)).ToListAsync();
            gamers.ForEach(g => db.Gamers.Remove(g));
            await db.SaveChangesAsync();
            return RedirectToAction("Index", new { searchBy, searchText, pageNumber, sortBy });
        }
    }
}