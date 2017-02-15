using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppo.Models
{
    public class tblPatientDetailsController : Controller
    {
        private doctorappoEntities4 db = new doctorappoEntities4();

        // GET: tblPatientDetails
        public ActionResult Index()
        {
            return View(db.tblPatientDetails.ToList());
        }

        // GET: tblPatientDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatientDetail tblPatientDetail = db.tblPatientDetails.Find(id);
            if (tblPatientDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblPatientDetail);
        }

        // GET: tblPatientDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblPatientDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iId,cName,cUserName,vPassword,vAddress,dDateOfBirth,cGender,vEmail,iPhone,Security_Question,Answer")] tblPatientDetail tblPatientDetail)
        {
            if (ModelState.IsValid)
            {
                db.tblPatientDetails.Add(tblPatientDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPatientDetail);
        }

        // GET: tblPatientDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatientDetail tblPatientDetail = db.tblPatientDetails.Find(id);
            if (tblPatientDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblPatientDetail);
        }

        // POST: tblPatientDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iId,cName,cUserName,vPassword,vAddress,dDateOfBirth,cGender,vEmail,iPhone,Security_Question,Answer")] tblPatientDetail tblPatientDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPatientDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPatientDetail);
        }

        // GET: tblPatientDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatientDetail tblPatientDetail = db.tblPatientDetails.Find(id);
            if (tblPatientDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblPatientDetail);
        }

        // POST: tblPatientDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPatientDetail tblPatientDetail = db.tblPatientDetails.Find(id);
            db.tblPatientDetails.Remove(tblPatientDetail);
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
