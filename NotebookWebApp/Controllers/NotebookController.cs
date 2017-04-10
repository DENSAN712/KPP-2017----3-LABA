using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotebookWebApp.Models;
using NotebookWebApp.ViewModels;
using System.Web.Http;

namespace NotebookWebApp.Controllers
{
    public class NotebookController : ApiController
    {
        private NotebookContext db = new NotebookContext();

        public ICollection<Notebook> Get()
        {
            return db.Notebooks.ToList();
        }

        public Notebook Get(int id)
        {
            return db.Notebooks.Find(id);
        }

        public void Put(Notebook notebook)
        {
            db.Notebooks.Add(notebook);
            db.SaveChanges();
        }

        public void Post(Notebook notebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notebook).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Notebook notebook = db.Notebooks.Find(id);
            db.Notebooks.Remove(notebook);
            db.SaveChanges();
        }
    }
}