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
    public class GroupsController : Controller
    {
        private TechShareContext db = new TechShareContext();

        public ActionResult Title()
        {
            return View();
        }

        public ActionResult LeftGroupList(int? groupId)
        
        {
            //Group＿Userから取得
            var groups = db.Group_User.Where(m => m.Group_Id == groupId);

            var users = groups.Select(e => e.Users).ToList();

             return View(users);
            //return View(db.Groups.ToList());

        }

        // GET: Groups
        public ActionResult Index(int? id)
        {
            chat_VM test = new chat_VM();
            
            if (id != null)
            {
                test.Groups.Id = (int)id;
            }

            return View(test);
        }

        public ActionResult Back()
        {
            return View();
        }

        public ActionResult input(int? GroupId, int? UserId)
        {
            chat chat = new chat();
            chat.User = db.Users.Where(e => e.Id == UserId).FirstOrDefault();
            chat.Group = db.Groups.Where(e => e.Id == GroupId).FirstOrDefault();

            return View("input", chat);
        }

        public ActionResult Admin()
        {

            return View("Users/Index");
        }

        public ActionResult GroupList()
        {
            //ここに書く
            return View(db.Groups.ToList());
        }

        public ActionResult GroupChat()
        {
            Group model = new Group();

            return View("Create",model);
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateChats(string id)
        {
            chat chats = new chat();
            chats.Text = "こんにちは";
            chats.Id = 1;
            db.chats.Add(chats);
            db.SaveChanges();
            return RedirectToAction("chats/Index");


            //var chats = db.chats.Where(e => e.Group.Id.ToString() == id).ToList();

            //return View("chats/Index", chats);
        }

       // POST: Groups/Create
       // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
       // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,icon")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("GroupList");
            }

            return View(group);
        }

        public ActionResult Send(chat model)
        {

            chat chat = new chat();
            chat.Text = model.Text;
            chat.Time = DateTime.Now;

            chat.User = db.Users.Find(model.User.Id);
            chat.Group = db.Groups.Find(model.Group.Id);

            //chat.User = model.User; //model.Users;
            //chat.Group = model.Group;//model.Groups;

            db.chats.Add(chat);
            db.SaveChanges();
            return RedirectToAction("input");


        }

        // POST: Groups/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Send([Bind(Include = "Name,Group_Id,Text")] chat_VM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var item in model.Chats)
        //        {
        //            db.chats.Add(item);
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,icon")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
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
