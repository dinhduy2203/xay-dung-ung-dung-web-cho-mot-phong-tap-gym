using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYM_MANAGER_PROJECTFSOFT.Models;
using PagedList;

namespace GYM_MANAGER_PROJECTFSOFT.Controllers
{
    public class ServicesController : Controller
    {
        GYM_Manager_DBEntities db = new GYM_Manager_DBEntities(); 
        // GET: Services

        public ActionResult ServiceDetail(int? MaDichVu)
        {
            var phong = db.Phong.FirstOrDefault(x => x.MaDichVu == MaDichVu);

            int maphong = phong.MaPhong;

            var thietbi = db.THIETBI.Where(x => x.MaPhong == maphong);

            ViewBag.ThietBi = thietbi;

            if (MaDichVu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var goitap = db.GOITAP.Where(x => x.MaDichVu == MaDichVu);
            return View(goitap);
        }
    }
}