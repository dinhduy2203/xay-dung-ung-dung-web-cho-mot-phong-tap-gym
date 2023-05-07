using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYM_MANAGER_PROJECTFSOFT.Models;
using System.Data.Entity;
using System.Net;
using PagedList;

namespace GYM_MANAGER_PROJECTFSOFT.Controllers
{
    public class StockManagerController : Controller
    {
        GYM_Manager_DBEntities db = new GYM_Manager_DBEntities();   

        public ActionResult DeviceListInStock(int? page)
        {
            var pageNum = page ?? 1;
            var pageSize = 10;
            var khothietbi = db.KHOTHIETBI.Where(x => x.MaThietBi == null);
            return View(khothietbi.OrderBy(x => x.MaThietBiTrongKho).ToPagedList(pageNum, pageSize));
        }

        public List<RoomDeviceInStock> DisplayRoomDeviceInStock()
        {
            List<RoomDeviceInStock> list = new List<RoomDeviceInStock>();
            var listDevice = db.KHOTHIETBI.Where(x => x.MaYeuCauNhap == null);
            foreach(var item in listDevice)
            {
                THIETBI lst = db.THIETBI.SingleOrDefault(x => x.MaThietBi == item.MaThietBi);
                RoomDeviceInStock detail = new RoomDeviceInStock
                {
                    MaThietBiTrongKho = item.MaThietBiTrongKho,
                    TenThietBi = lst.TenThietBi,
                    HinhThietBi = lst.HinhThietBi,
                    TrangThaiThietBi = lst.TrangThaiThietBi,
                    TrangThaiTonKho = item.TrangThaiTonKho,
                };
                list.Add(detail);
            }
            return list;
        }

        public ActionResult RoomDeviceInStock(int? page)
        {
            var pageNum = page ?? 1;
            var pageSize = 10;
            List<RoomDeviceInStock> list = DisplayRoomDeviceInStock();
            return View(list.OrderBy(x => x.MaThietBiTrongKho).ToPagedList(pageNum, pageSize));
        }

        public ActionResult EditDeviceInStock(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOTHIETBI kHOTHIETBI = db.KHOTHIETBI.Find(id);
            if (kHOTHIETBI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaThietBi = new SelectList(db.THIETBI, "MaThietBi", "TenThietBi", kHOTHIETBI.MaThietBi);
            ViewBag.MaYeuCauNhap = new SelectList(db.NHAPTHIETBI, "MaYeuCauNhap", "TenThietBi", kHOTHIETBI.MaYeuCauNhap);
            return View(kHOTHIETBI);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDeviceInStock([Bind(Include = "MaThietBiTrongKho,MaThietBi,MaYeuCauNhap,TrangThaiTonKho")] KHOTHIETBI kHOTHIETBI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHOTHIETBI).State = EntityState.Modified;
                db.SaveChanges();
                THIETBI thietbi = db.THIETBI.SingleOrDefault(x => x.MaThietBi == kHOTHIETBI.MaThietBi);
                if(thietbi != null)
                {
                    thietbi.TrangThaiThietBi = true;
                    db.SaveChanges();
                    db.KHOTHIETBI.Remove(kHOTHIETBI);
                    db.SaveChanges();
                    return RedirectToAction("RoomDeviceInStock");
                }
                
                return RedirectToAction("DeviceListInStock");
            }
            ViewBag.MaThietBi = new SelectList(db.THIETBI, "MaThietBi", "TenThietBi", kHOTHIETBI.MaThietBi);
            ViewBag.MaYeuCauNhap = new SelectList(db.NHAPTHIETBI, "MaYeuCauNhap", "TenThietBi", kHOTHIETBI.MaYeuCauNhap);
            return View(kHOTHIETBI);
        }

        public ActionResult DeleteDeviceInStock(int? id)
        {
            KHOTHIETBI khothietbi = db.KHOTHIETBI.SingleOrDefault(x => x.MaThietBiTrongKho == id);
            db.KHOTHIETBI.Remove(khothietbi);
            db.SaveChanges();
            return RedirectToAction("DeviceListInStock");
        }

    }
}