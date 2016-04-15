using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reddit_Lab.Models;

namespace Reddit_Lab.Controllers
{
    public class PostsController : Controller
    {
        private Reddit_LabDbContext db = new Reddit_LabDbContext();
        
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        [HttpGet]
        public ActionResult Details(int Id=0)
        {
            Post post = db.Posts.Find(Id);
            return View(post);
        }
        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post newPost)
        {

            if (ModelState.IsValid)
            {
                db.Posts.Add(newPost);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newPost);
            }
        }

    }
}