using GYM_MANAGER_PROJECTFSOFT.Models;
using System.Linq;
using System.Web.Mvc;

namespace GYM_MANAGER_PROJECTFSOFT.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        GYM_Manager_DBEntities db = new GYM_Manager_DBEntities();

        public ActionResult Index()
        {
            var lstDichVu = db.DICHVU.Where(x => x.MaClub == 1);
            return View(lstDichVu);
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string username = form["txtUsername"].ToString();
            string password = form["txtPassword"].ToString();

            TAIKHOAN taikhoan = db.TAIKHOAN.SingleOrDefault(x => x.TaiKhoan1 == username && x.MatKhau == password);
            TAIKHOAN admincaonhat = db.TAIKHOAN.SingleOrDefault(x => x.TaiKhoan1 == "Kit");
            

            if (taikhoan != null)
            {
                Profile profile = db.Profile.SingleOrDefault(x => x.MaTaiKhoan == taikhoan.MaTaiKhoan);
                Session["TaiKhoan"] = taikhoan;
                Session["Profile"] = profile;
                Session["Role"] = taikhoan.Role;
                return RedirectToAction("Index");
            }

            ViewBag.MessageLogin = "Wrong Your Account Or Password";
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(TAIKHOAN user, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var check = db.TAIKHOAN.SingleOrDefault(x => x.TaiKhoan1 == user.TaiKhoan1);
                if (check == null)
                {
                    if(user.MatKhau == form["txtPassword"])
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TAIKHOAN.Add(user);
                        db.SaveChanges();
                        var setRole = db.TAIKHOAN.SingleOrDefault(x => x.TaiKhoan1 == user.TaiKhoan1 && x.MatKhau == user.MatKhau);
                        setRole.Role = false;
                        db.SaveChanges();
                        ViewBag.Message = "Register success! Please login again";
                        return View(user);
                    } else
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        ViewBag.Message = "Password and Confirm Password do not match";
                        return View(user);
                    }           
                }
                else
                {
                    ViewBag.Message = "Username already exits!Please use another username please.";
                    return View(user);
                }
            }
            return View();
        }

        public ActionResult MenuParital()
        {
            var lstService = db.DICHVU;
            return PartialView(lstService);
        }

        public ActionResult DeviceMap()
        {
            return View();
        }
    }
}