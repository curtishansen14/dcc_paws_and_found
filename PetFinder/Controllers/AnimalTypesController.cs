﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetFinder.Models;

namespace PetFinder.Controllers
{
    public class AnimalTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AnimalTypes
        public ActionResult Index()
        {
            return View(db.AnimalType.ToList());
        }

        // GET: AnimalTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalType.Find(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // GET: AnimalTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalTypeID,Species")] AnimalType animalType)
        {
            if (ModelState.IsValid)
            {
                db.AnimalType.Add(animalType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animalType);
        }

        // GET: AnimalTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalType.Find(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // POST: AnimalTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalTypeID,Species")] AnimalType animalType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animalType);
        }

        // GET: AnimalTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalType.Find(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // POST: AnimalTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalType animalType = db.AnimalType.Find(id);
            db.AnimalType.Remove(animalType);
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
