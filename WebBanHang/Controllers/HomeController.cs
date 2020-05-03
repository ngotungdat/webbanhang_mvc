using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Model;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        WebBanHangDbContext db = new WebBanHangDbContext();
        public ActionResult Index()
        {
            ViewBag.SanPhamMoi = db.SanPhams.OrderByDescending(x => x.NgayCapNhat).Take(4).ToList();
            ViewBag.SanPhamBanChay = db.SanPhams.OrderByDescending(x => x.SoLuongBan).Take(4).ToList();
            return View();
        }

        public ActionResult Detailes(string id)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(x => x.MaSanPham == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}