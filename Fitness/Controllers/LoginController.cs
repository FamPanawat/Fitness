using Fitness.Data;
using Fitness.Helpers;
using Fitness.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public IActionResult VerifyUser([FromBody] Authentication model)
        {
            // ตรวจสอบข้อมูลผู้ใช้
            if (ModelState.IsValid)
            {
                // ตรวจสอบการเข้าสู่ระบบ
                bool isAuthenticated = PerformAuthentication(model.Username, model.Password);

                if (isAuthenticated)
                {

                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, error = "Invalid username or password" });
                }
            }
            else
            {
                return Json(new { success = false, error = "Invalid data" });
            }
        }

        public bool PerformAuthentication(string username, string password)
        {
            password = GenerateOfficer.Encryption(password);
            // ตรวจสอบข้อมูลผู้ใช้และการเข้าสู่ระบบ
            var data = _db.Officer.Where(c => c.Username == username && c.Password == password).FirstOrDefault();

            if (data != null)
            {
                var Role = _db.Role.Where(c => c.RoleId == data.RoleId).FirstOrDefault();
                // กำหนดค่าให้ Session
                HttpContext.Session.SetString("OfficerId", data.Officer_Id);
                HttpContext.Session.SetString("Fullname", data.Firstname + " " + data.Lastname);
                HttpContext.Session.SetString("Role", Role.RoleName);
                return true; // การเข้าสู่ระบบสำเร็จ
            }
            else
            {
                return false; // การเข้าสู่ระบบไม่สำเร็จ
            }

        }

        public IActionResult LogOutButton()
        {
            HttpContext.Session.Remove("OfficerId");
            HttpContext.Session.Remove("Fullname");
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("IsFirstLoad");
            return RedirectToAction("Index", "Login");
        }


    }
}
