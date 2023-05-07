using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYM_MANAGER_PROJECTFSOFT.Models;
using PagedList;
using System.Data.Entity;

namespace GYM_MANAGER_PROJECTFSOFT.Controllers
{
    public class BrowseRegPackageManagerController : Controller
    {
        GYM_Manager_DBEntities db = new GYM_Manager_DBEntities();

        public List<RegisterPackageDetail> DisplayListReg()
        {
            var lstdangkygoitap = db.DANGKYGOITAP;
            List<RegisterPackageDetail> lstRegPackage = new List<RegisterPackageDetail>();
            if (lstdangkygoitap != null)
            {
                foreach (var item in lstdangkygoitap)
                {
                    THETHANHVIEN thethanhvien = db.THETHANHVIEN.SingleOrDefault(x => x.MaDangKyGoiTap == item.MaDangKyGoiTap);
                    GOITAP goitap = db.GOITAP.SingleOrDefault(x => x.MaGoiTap == item.MaGoiTap);
                    var regPackageDetail = new RegisterPackageDetail
                    {
                        MaDangKyGoiTap = item.MaDangKyGoiTap,
                        CodeThe = thethanhvien.CodeThe,
                        TenGoiTap = goitap.TenGoiTap,
                        NgayDangKi = item.NgayDangKi,
                        GiaDangKi = item.GiaDangKi,
                        TrangThai = thethanhvien.TrangThai,
                    };
                    lstRegPackage.Add(regPackageDetail);
                }
                return lstRegPackage;
            }
            return null;
        }
        // GET: BrowseRegPackageManager
        public ActionResult BrowseRegPackage(int? page)
        {
            var pageNum = page ?? 1;
            var pageSize = 10;

            List<RegisterPackageDetail> lstRegPackage = DisplayListReg();  
            return View(lstRegPackage.OrderBy(x => x.MaDangKyGoiTap).ToPagedList(pageNum, pageSize));
        }

        public ActionResult ApproveRegPackage(int MaDangKyGoiTap, string CodeThe)
        {

            int madangkygoitap = (int)MaDangKyGoiTap;
            DANGKYGOITAP dangkygoitap = db.DANGKYGOITAP.SingleOrDefault(x => x.MaDangKyGoiTap == madangkygoitap);
            THETHANHVIEN thethanhvien = db.THETHANHVIEN.SingleOrDefault(x => x.MaDangKyGoiTap == madangkygoitap);
            GOITAP goitap = db.GOITAP.SingleOrDefault(x => x.MaGoiTap == dangkygoitap.MaGoiTap);

            int thoihangoitap = (int)goitap.ThoiHanGoiTap;
            DateTime ngaydangky = DateTime.Now;
            DateTime ngayhethan = ngaydangky.AddDays(thoihangoitap);

            thethanhvien.NgayDangKy = dangkygoitap.NgayDangKi;
            thethanhvien.NgayHetHan = ngayhethan;
            thethanhvien.TrangThai = true;
            db.SaveChanges();

            THANHVIEN thanhvien = db.THANHVIEN.SingleOrDefault(x => x.MaTheThanhVien == thethanhvien.MaTheThanhVien);
            thanhvien.NgayDangKi = thethanhvien.NgayDangKy;
            db.SaveChanges();

            return RedirectToAction("BrowseRegPackage");
        }
    }
}