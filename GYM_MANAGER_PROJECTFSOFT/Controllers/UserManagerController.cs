using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYM_MANAGER_PROJECTFSOFT.Models;
using PagedList;

namespace GYM_MANAGER_PROJECTFSOFT.Controllers
{
    public class UserManagerController : Controller
    {
        GYM_Manager_DBEntities db = new GYM_Manager_DBEntities();
        // GET: UserManager
        public List<ProfileDetail> DisplayProFileUser()
        {
            List<ProfileDetail> profileDetails = new List<ProfileDetail>();
            var lsttaikhoan = db.TAIKHOAN;
            foreach (var taikhoan in lsttaikhoan)
            {
                var profile = db.Profile.SingleOrDefault(x => x.MaTaiKhoan == taikhoan.MaTaiKhoan);
                if (profile != null)
                {
                    var lstTaiKhoanHaveProfile = new ProfileDetail
                    {
                        MaTaiKhoan = taikhoan.MaTaiKhoan,
                        Avatar = profile.Avatar,
                        HoTen = profile.HoTen,
                        DiaChi = profile.DiaChi,
                        NgaySinh = profile.NgaySinh,
                        TaiKhoan = taikhoan.TaiKhoan1,
                        Email = taikhoan.Email,
                        SoDienThoai = taikhoan.SoDienThoai,
                        Role = taikhoan.Role,
                    };
                    profileDetails.Add(lstTaiKhoanHaveProfile);
                }
                else
                {
                    var lstTaiKhoanNoProrile = new ProfileDetail
                    {
                        MaTaiKhoan = taikhoan.MaTaiKhoan,
                        Avatar = null,
                        HoTen = null,
                        DiaChi = null,
                        NgaySinh = null,
                        TaiKhoan = taikhoan.TaiKhoan1,
                        Email = taikhoan.Email,
                        SoDienThoai = taikhoan.SoDienThoai,
                        Role = taikhoan.Role,   
                    };
                    profileDetails.Add(lstTaiKhoanNoProrile);
                }
            }
            return profileDetails;
        }
        public ActionResult ListUser(int? page)
        {
            var pageNum = page ?? 1;
            var pageSize = 5;
            List<ProfileDetail> profileDetails = DisplayProFileUser();
            return View(profileDetails.OrderBy(x => x.MaTaiKhoan).ToPagedList(pageNum, pageSize));
        }

        public ActionResult Delete(int MaTaiKhoan)
        {
            TAIKHOAN taikhoan = db.TAIKHOAN.SingleOrDefault(x => x.MaTaiKhoan == MaTaiKhoan);
            Profile profile = db.Profile.SingleOrDefault(x => x.MaTaiKhoan == MaTaiKhoan);
            if (profile != null)
            {
                db.Profile.Remove(profile);
                db.TAIKHOAN.Remove(taikhoan);
                db.SaveChanges();
            }
            else
            {
                db.TAIKHOAN.Remove(taikhoan);
                db.SaveChanges();
            }
            return RedirectToAction("ListUser");
        }

        [HttpGet]
        public ActionResult Edit(int? MaTaiKhoan)
        {
            int mataikhoan = (int)MaTaiKhoan;
            TAIKHOAN taikhoan = db.TAIKHOAN.SingleOrDefault(x => x.MaTaiKhoan == mataikhoan);
            var profile = db.Profile.SingleOrDefault(x => x.MaTaiKhoan == mataikhoan);
            if (profile != null)
            {
                var lstTaiKhoanHaveProfile = new ProfileDetail
                {
                    MaTaiKhoan = mataikhoan,
                    Avatar = profile.Avatar,
                    HoTen = profile.HoTen,
                    DiaChi = profile.DiaChi,
                    NgaySinh = profile.NgaySinh,
                    TaiKhoan = taikhoan.TaiKhoan1,
                    Email = taikhoan.Email,
                    SoDienThoai = taikhoan.SoDienThoai,
                    Role = taikhoan.Role,
                };
                return View(lstTaiKhoanHaveProfile);
            }
            else
            {
                var lstTaiKhoanNoProrile = new ProfileDetail
                {
                    MaTaiKhoan = taikhoan.MaTaiKhoan,
                    Avatar = null,
                    HoTen = null,
                    DiaChi = null,
                    NgaySinh = null,
                    TaiKhoan = taikhoan.TaiKhoan1,
                    Email = taikhoan.Email,
                    SoDienThoai = taikhoan.SoDienThoai
                };
                return View(lstTaiKhoanNoProrile);
            }
        }

        [HttpPost]  
        public ActionResult Edit(ProfileDetail profiledetail)
        {
            TAIKHOAN taikhoan = db.TAIKHOAN.SingleOrDefault(x => x.MaTaiKhoan == profiledetail.MaTaiKhoan);
            taikhoan.Role = profiledetail.Role;
            db.SaveChanges();
            return RedirectToAction("ListUser");
        }
    }
}