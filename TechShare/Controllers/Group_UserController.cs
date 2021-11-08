using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechShare.Data;
using TechShare.Models;

namespace TechShare.Controllers
{
    public class Group_UserController : Controller
    {
        private TechShareContext db = new TechShareContext();

        // GET: Group_User
        public ActionResult Index()
        {
            return View(db.Group_User.ToList());
        }

        // GET: Group_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group_User group_User = db.Group_User.Find(id);
            if (group_User == null)
            {
                return HttpNotFound();
            }
            return View(group_User);
        }

        // GET: Group_User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group_User/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Group_Id,User_Id")] Group_User group_User)
        {
            if (ModelState.IsValid)
            {
                db.Group_User.Add(group_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group_User);
        }

        // GET: Group_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group_User group_User = db.Group_User.Find(id);
            if (group_User == null)
            {
                return HttpNotFound();
            }
            return View(group_User);
        }

        // POST: Group_User/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Group_Id,User_Id")] Group_User group_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group_User);
        }

        // GET: Group_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group_User group_User = db.Group_User.Find(id);
            if (group_User == null)
            {
                return HttpNotFound();
            }
            return View(group_User);
        }

        // POST: Group_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group_User group_User = db.Group_User.Find(id);
            db.Group_User.Remove(group_User);
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
