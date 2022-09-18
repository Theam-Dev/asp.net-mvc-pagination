using AspPaging.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace AspPaging.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Post
        public ActionResult Index(string searchString, int? page)
        {
            var branddb = db.Post.Where(c => c.Title.Contains(searchString) || searchString == null).ToList();
            var brand = branddb.OrderByDescending(s => s.Id);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(brand.ToPagedList(pageNumber, pageSize));
        }
    }
}