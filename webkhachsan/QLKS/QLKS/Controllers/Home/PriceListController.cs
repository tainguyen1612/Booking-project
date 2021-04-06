using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class PriceListController : Controller
    {
        // GET: BangGia
        QLKS.Models.dataQLKSEntities db = new Models.dataQLKSEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Rooms()
        {
            return View(db.tblLoaiPhongs.ToList());
        }
        public ActionResult Services()
        {
            return View(db.tblDichVus.ToList());
        }
    }
}