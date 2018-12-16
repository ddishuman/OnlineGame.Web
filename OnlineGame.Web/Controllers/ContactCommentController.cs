using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineGame.Web.Models;
using System.Text;

namespace OnlineGame.Web.Controllers
{
    public class ContactCommentController : Controller
    {
        private OnlineGameEntities db = new OnlineGameEntities();

        // GET: ContactComment
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactComments.ToListAsync());
        }

        // GET: ContactComment/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactComment contactComment = await db.ContactComments.FindAsync(id);
            if (contactComment == null)
            {
                return HttpNotFound();
            }
            return View(contactComment);
        }

        // GET: ContactComment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,CommentText")] ContactComment contactComment)
        {
            if (!ModelState.IsValid)
                return View(contactComment);

            StringBuilder sbCommentText = new StringBuilder();

            // HTML Encode the CommentText
            sbCommentText.Append(HttpUtility.HtmlEncode(contactComment.CommentText));
            // Decode <b> and <u>
            sbCommentText.Replace("&lt;b&gt;", "<b>");
            sbCommentText.Replace("&lt;/b&gt;", "</b>");
            sbCommentText.Replace("&lt;u&gt;", "<u>");
            sbCommentText.Replace("&lt;/u&gt;", "</u>");
            contactComment.CommentText = sbCommentText.ToString();
            // HTML Encode the Name
            string strEncodedName = HttpUtility.HtmlEncode(contactComment.Name);
            contactComment.Name = strEncodedName;

            db.ContactComments.Add(contactComment);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: ContactComment/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactComment contactComment = await db.ContactComments.FindAsync(id);
            if (contactComment == null)
            {
                return HttpNotFound();
            }
            return View(contactComment);
        }

        // POST: ContactComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,CommentText")] ContactComment contactComment)
        {
            if (!ModelState.IsValid)
                return View(contactComment);
            StringBuilder sbCommentText = new StringBuilder();
            // HTML Encode the CommentText
            sbCommentText.Append(HttpUtility.HtmlEncode(contactComment.CommentText));
            // Decode <b> and <u>
            sbCommentText.Replace("&lt;b&gt;", "<b>");
            sbCommentText.Replace("&lt;/b&gt;", "</b>");
            sbCommentText.Replace("&lt;u&gt;", "<u>");
            sbCommentText.Replace("&lt;/u&gt;", "</u>");
            contactComment.CommentText = sbCommentText.ToString();
            // HTML Encode the Name
            string strEncodedName = HttpUtility.HtmlEncode(contactComment.Name);
            contactComment.Name = strEncodedName;
            db.Entry(contactComment).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: ContactComment/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactComment contactComment = await db.ContactComments.FindAsync(id);
            if (contactComment == null)
            {
                return HttpNotFound();
            }
            return View(contactComment);
        }

        // POST: ContactComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactComment contactComment = await db.ContactComments.FindAsync(id);
            db.ContactComments.Remove(contactComment);
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
