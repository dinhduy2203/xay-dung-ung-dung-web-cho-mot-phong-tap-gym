using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYM_MANAGER_PROJECTFSOFT.Models;

namespace GYM_MANAGER_PROJECTFSOFT.Controllers
{
    public class BlogController : Controller
    {
        GYM_Manager_DBEntities db = new GYM_Manager_DBEntities();
        // GET: Blog
        public ActionResult BlogList()
        {
            var lstblog = db.BLOG;
            return View(lstblog);
        }

        public ActionResult BlogDetail(int? MaBlog)
        {
            var blogDetail = db.BLOG.SingleOrDefault(x => x.MaBlog == MaBlog);

            return View(blogDetail);
        }




    }
}