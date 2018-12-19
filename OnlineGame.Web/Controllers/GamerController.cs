using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using System.Web.UI;
using OnlineGame.Web.Models;
using OnlineGame.Web.WebShared;
using PagedList;

namespace OnlineGame.Web.Controllers
{
    public class GamerController : Controller
    {
        private OnlineGameEntities db = new OnlineGameEntities();
        // GET: Gamer
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await db.Gamers.ToListAsync());
        }
        // GET: Gamer
        [HttpGet]
        [OutputCache(Duration = 10)]
        //[OutputCache(Duration = 10, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient)]
        //[OutputCache(Duration = 10, VaryByParam = "None", Location = OutputCacheLocation.Client)]
        public async Task<ActionResult> Index2()
        {
            System.Threading.Thread.Sleep(3000);
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View(await db.Gamers.ToListAsync());
        }

        // GET: Gamer
        [HttpGet]
        public async Task<ActionResult> Index3()
        {
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View(await db.Gamers.ToListAsync());
        }

        // GET: Gamer
        [HttpGet]
        public async Task<ActionResult> Index3V2()
        {
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View(await db.Gamers.ToListAsync());
        }

        //[ChildActionOnly] make the action to be accessible only by a child request,
        //so no one can make a direct URL request to this action.
        [ChildActionOnly]
        [HttpGet]
        [OutputCache(Duration = 10)]
        public string GetGamerCount()
        {
            System.Threading.Thread.Sleep(3000);
            return $"Gamer Count = {db.Gamers.Count()} At {DateTime.Now}";
        }

        [HttpGet]
        //[OutputCache(Duration = 60)]
        [OutputCache(CacheProfile = "outputCacheProfile1")]
        public async Task<ActionResult> Index4()
        {
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View(await db.Gamers.ToListAsync());
        }
        //[ChildActionOnly] make the action to be accessible only by a child request,
        //so no one can make a direct URL request to this action.
        [ChildActionOnly]
        [HttpGet]
        //[OutputCache(Duration = 60)]
        //[OutputCache(CacheProfile = "outputCacheProfile1")]   //This will throw exception
        [CustomizeCache("outputCacheProfile1")]
        public string GetGamerCount2()
        {
            System.Threading.Thread.Sleep(3000);
            return $"Gamer Count = {db.Gamers.Count()} At {DateTime.Now}";
        }

        [OutputCache(Duration = 5, VaryByParam = "none")]
        //[OutputCache(Duration = 60, VaryByParam = "gamerName")]
        public ActionResult Index5(string gamerName)
        {
            ViewBag.GamerName = gamerName ?? string.Empty;
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View();
        }
        //From T013
        // GET: Gamer
        [HttpGet]
        ////1.
        //[OutputCache(Duration = 5, VaryByParam = "none")]
        ////It means always cache the same contents.
        ////2.
        //[OutputCache(Duration = 60, VaryByParam = "*")]
        ////It means for cache for every parameters,
        ////this is dangerous becuase of the view might have too many parameters.
        ////3.
        [OutputCache(Duration = 60, VaryByParam = "searchBy;searchText;pageNumber;sortBy")]
        public async Task<ActionResult> Index6(string searchBy, string searchText, int? pageNumber, string sortBy)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortBy) ? "Name desc" : "";
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
            //1.
            //The first parameter is pagenumber
            //pageNumber ?? 1 means if the pageNumber==null, then pageNumber==1
            //2.
            //The 2nd parameter is page size.
            //We set page size is 5.
            //IPagedList<Gamer> gamerPagedList = gamers.ToPagedList(pageNumber ?? 1, 5);
            IPagedList<Gamer> gamerPagedList = gamersOrderedEnumerable.ToPagedList(pageNumber ?? 1, 5);
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View(gamerPagedList);
        }
        //From T013
        [HttpPost]
        public async Task<ActionResult> DeleteMultiple(IEnumerable<int> GamerIdsToDelete, string searchBy, string searchText, int? pageNumber, string sortBy)
        {
            //Delete a list of gamers
            List<Gamer> gamers = await db.Gamers.Where(g => GamerIdsToDelete.Contains(g.Id)).ToListAsync();
            gamers.ForEach(g => db.Gamers.Remove(g));
            await db.SaveChangesAsync();

            //Remove OutputCache
            //Reference:
            //http://www.c-sharpcorner.com/code/1994/how-to-clear-output-cache-in-asp-net-mvc.aspx
            //https://forums.asp.net/t/2077235.aspx?How+to+clear+OutPutCache+Asp+net+Mvc
            //1. Get the url for the action method:
            string staleItem = Url.Action("Index6", "Gamer");
            //2. Remove the item from cache
            if (staleItem != null) Response.RemoveOutputCacheItem(staleItem);
            return RedirectToAction("Index6", new { searchBy, searchText, pageNumber, sortBy });
        }

        [HttpGet]
        //[OutputCache(Duration = 10, VaryByParam = "None", Location = OutputCacheLocation.None)]
        //[OutputCache(Duration = 10, VaryByParam = "None", Location= OutputCacheLocation.Server)]
        [OutputCache(Duration = 10, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index7()
        {
            ViewBag.ServerTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return View();
        }
        // GET: Gamer/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }
        // GET: Gamer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gamer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,EmailAddress")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                db.Gamers.Add(gamer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gamer);
        }
        // GET: Gamer/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }
        // POST: Gamer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Gender,EmailAddress")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gamer);
        }
        // GET: Gamer/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }
        // POST: Gamer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Gamer gamer = await db.Gamers.FindAsync(id);
            db.Gamers.Remove(gamer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}