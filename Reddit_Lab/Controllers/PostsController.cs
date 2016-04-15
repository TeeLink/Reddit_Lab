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

    }
}