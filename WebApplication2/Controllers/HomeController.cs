﻿using com.bsidesoft.cs;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers {
    public class HomeController:Controller {
        private bs bs;
        public HomeController(bs b) {
            bs = b;
        }
        public IActionResult Index() {
            var err = bs.dbError();
            var rs = bs.dbSelect(out err, "remote:a", "title", "1PD시험a");
            return Json(new { data = rs, a = 3 });
        }
    }
}