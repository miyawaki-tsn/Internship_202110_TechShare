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
using TechShare.Models.VM;

namespace TechShare.Controllers
{
    public class UsersController : Controller
    {
      

        private TechShareContext db = new TechShareContext();
        public ActionResult CreateUser(string test)
        {
            Admin_VM model = new Admin_VM();
            
            //model.user = db.Users.Include(u => u.Role);
            return View(model);
        }


        // GET: Users
        public ActionResult Index()
        {
            Admin_VM model = new Admin_VM();
            Group_User group_user = new Group_User();

          var groupusers =db.Group_User.Where(m => m.Group_Id == 0).ToList();
        var users = groupusers.Select(m=>m.Users).ToList();
        model.user = users;

      return View(model);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
          if (id == null)
          {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          }
          User user = db.Users.Find(id);
      if (user == null)
          {
            return HttpNotFound();
            
          }
        else
        {
        user.deleteflg = 1;
        db.Users.Attach(user);
        db.Entry(user).Property(m => m.deleteflg).IsModified = true;

        //db.Users.Remove(user);
        db.SaveChanges();
        }
      //ViewBag.roleId = new SelectList(db.roles, "Id", "Name", user.roleId);
      Admin_VM admin = new Admin_VM();

      admin.user = db.Users.Where(m => m.deleteflg != 1).ToList();

      return View("Index", admin);
        }

    // GET: Users/Details/5
    public ActionResult Details(int? id)
        {
      int groupId = 0;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
              return HttpNotFound();
            }

            else
            {
        Group_User group_user = new Group_User();
        group_user.Group_Id = groupId;
        group_user.User_Id = user.Id;
        db.Group_User.Add(group_user);
      }

      return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.roleId = new SelectList(db.roles, "Id", "Name");
            return View();
        }

        // POST: Users/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,password,roleId,icon,deleteflg")] User user)
        {
          Admin_VM model = new Admin_VM();

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.roleId = new SelectList(db.roles, "Id", "Name", user.roleId);
            return View(user);
        }

   

        // POST: Users/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,password,roleId,icon,deleteflg")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.roleId = new SelectList(db.roles, "Id", "Name", user.roleId);
            return View(user);
        }

        

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
