﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThuVien.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult HeaderTop()
        {

            return PartialView();
        }
        public PartialViewResult HeaderMid()
        {

            return PartialView();
        }

    }
}