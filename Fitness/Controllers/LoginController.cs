using Fitness.Data;
using Fitness.Helpers;
using Fitness.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Fitness.Controllers
{
    public class LoginController : Controller
    {

        private readonly FitnessDBContext _db;

        public LoginController(FitnessDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Officer user)
        {
            user.Password = GenerateOfficer.Encryption(user.Password);
            var data = _db.Officer.Where(c => c.Username == user.Username && c.Password== user.Password).FirstOrDefault();
            if (data != null)
            {
                // กำหนดค่าให้ Session
                HttpContext.Session.SetString("OfficerId", data.Officer_Id);

                //ลบ session
                //HttpContext.Session.Remove("Userid");

                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

    }
}
