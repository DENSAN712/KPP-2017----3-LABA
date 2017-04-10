using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotebookWebApp.Models;
using System.Net.Http;

namespace NotebookWebApp.Controllers
{
    public class NoteController : Controller
    {
        private NotebookContext db = new NotebookContext();

        //
        // GET: /Note/

        public ActionResult Index()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:2041/api/notebook").Result;
            var notebooks = response.Content.ReadAsAsync<IEnumerable<Notebook>>().Result;
            return View(notebooks);
        }

        //
        // GET: /Note/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Note/Create

        [HttpPost]
        public ActionResult Create(Notebook notebook)
        {
            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                var response = client.GetAsync("http://localhost:2041/api/notebook").Result;
                var notebooks = response.Content.ReadAsAsync<IEnumerable<Notebook>>().Result;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notebook);
        }

        //
        // GET: /Note/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Notebook notebook = db.Notebooks.Find(id);
            if (notebook == null)
            {
                return HttpNotFound();
            }
            return View(notebook);
        }

        //
        // POST: /Note/Edit/5

        [HttpPost]
        public ActionResult Edit(Notebook notebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notebook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notebook);
        }

        //
        // GET: /Note/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Notebook notebook = db.Notebooks.Find(id);
            if (notebook == null)
            {
                return HttpNotFound();
            }
            return View(notebook);
        }

        //
        // POST: /Note/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Notebook notebook = db.Notebooks.Find(id);
            db.Notebooks.Remove(notebook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}