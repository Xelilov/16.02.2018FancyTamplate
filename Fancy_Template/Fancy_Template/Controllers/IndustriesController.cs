using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fancy_Template.Models;

namespace Fancy_Template.Controllers
{
    public class IndustriesController : Controller
    {
        private Fancy_TemplateEntities db = new Fancy_TemplateEntities();

        // GET: Industries
        public ActionResult Index()
        {
            if (!Check_Login_Session())
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.Industries.ToList());
        }

        // GET: Industries/Details/5
        public ActionResult Details(int? id)
        {
            if (!Check_Login_Session())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Industry industry = db.Industries.Find(id);
            if (industry == null)
            {
                return HttpNotFound();
            }
            return View(industry);
        }

        // GET: Industries/Create
        public ActionResult Create()
        {
            if (!Check_Login_Session())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: Industries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "industries_id,industries_title,industries_content,industries_img,industries_url")] Industry industry, HttpPostedFileBase industries_img)
        {
            if (!Check_Login_Session())
            {
                return RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                var file_name = Path.GetFileName(industries_img.FileName);
                if (industries_img.ContentLength > 0)
                {
                    var file_src = Path.Combine(Server.MapPath("/Uploads"), file_name);
                    industries_img.SaveAs(file_src);
                }
                industry.industries_img = file_name;
                db.Industries.Add(industry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(industry);
        }

        // GET: Industries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!Check_Login_Session())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Industry industry = db.Industries.Find(id);
            if (industry == null)
            {
                return HttpNotFound();
            }
            return View(industry);
        }

        // POST: Industries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "industries_id,industries_title,industries_content,industries_img,industries_url")] Industry industry)
        {
            if (!Check_Login_Session())
            {
                return RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                db.Entry(industry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(industry);
        }

        // GET: Industries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!Check_Login_Session())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Industry industry = db.Industries.Find(id);
            if (industry == null)
            {
                return HttpNotFound();
            }
            return View(industry);
        }

        // POST: Industries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Check_Login_Session())
            {
                return RedirectToAction("Index", "Login");
            }
            Industry industry = db.Industries.Find(id);
            db.Industries.Remove(industry);
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
        private bool Check_Login_Session()
        {
            if (Session["User_Name"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
