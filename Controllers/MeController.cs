﻿using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    public class MeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
