using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JapaneseWeb.DAO;
using JapaneseWeb.Models;

namespace JapaneseWeb.Controllers
{
    public class TopicvocabulariesController : Controller
    {
        private DbEduContext db = new DbEduContext();

        // GET: Topicvocabularies
        public ActionResult Index()
        {
            return View(db.Topicvocabularies.ToList());
        }

        // GET: Topicvocabularies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topicvocabulary topicvocabulary = db.Topicvocabularies.Find(id);
            if (topicvocabulary == null)
            {
                return HttpNotFound();
            }
            return View(topicvocabulary);
        }

        // GET: Topicvocabularies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topicvocabularies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idtopic,Name,Description")] Topicvocabulary topicvocabulary)
        {
            if (ModelState.IsValid)
            {
                db.Topicvocabularies.Add(topicvocabulary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topicvocabulary);
        }

        // GET: Topicvocabularies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topicvocabulary topicvocabulary = db.Topicvocabularies.Find(id);
            if (topicvocabulary == null)
            {
                return HttpNotFound();
            }
            return View(topicvocabulary);
        }

        // POST: Topicvocabularies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idtopic,Name,Description")] Topicvocabulary topicvocabulary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topicvocabulary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topicvocabulary);
        }

        // GET: Topicvocabularies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topicvocabulary topicvocabulary = db.Topicvocabularies.Find(id);
            if (topicvocabulary == null)
            {
                return HttpNotFound();
            }
            return View(topicvocabulary);
        }

        // POST: Topicvocabularies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topicvocabulary topicvocabulary = db.Topicvocabularies.Find(id);
            db.Topicvocabularies.Remove(topicvocabulary);
            db.SaveChanges();
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
