using Fitness.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // ตรวจสอบว่าเป็นครั้งแรกที่โหลดหน้า view หรือไม่
            int isFirstLoad = HttpContext.Session?.GetInt32("IsFirstLoad") ?? 1;
            if (isFirstLoad == 1)
            {
                // เซ็ต Session เพื่อบอกว่าไม่ใช่ครั้งแรกแล้ว
                HttpContext.Session.SetInt32("IsFirstLoad", 0);

                // ส่งข้อความแจ้งเตือนไปยัง View
                ViewBag.ShowAlert = true;
            }
            else
            {
                ViewBag.ShowAlert = false;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
