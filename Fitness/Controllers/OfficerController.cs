using Fitness.Data;
using Fitness.Helpers;
using Fitness.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace Fitness.Controllers
{
    public class OfficerController : Controller
    {
        public readonly FitnessDBContext _db;
        public OfficerController(FitnessDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            string OffId = "";
            string maxId = _db.Officer.Max(c => c.Officer_Id);
            if(maxId == null)
            {
                maxId = "OFFICER-000";
                OffId = GenerateOfficer.GenerateOfficerId(maxId);
            }
            else
            {
                OffId = GenerateOfficer.GenerateOfficerId(maxId);
            }

            Officer off = new Officer();

            off.Officer_Id = OffId;

            ViewData["SexList"] = _db.Sex.OrderBy(c => c.SexName).ToList();
            ViewData["RoleList"] = _db.Role.Where(x => x.RoleId <= 2).OrderBy(c => c.RoleName).ToList();


            return View(off);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Officer data)
        {
            try
            {
                data.Password = GenerateOfficer.Encryption(data.Password);
                data.CreateDate = DateTime.Now;
                data.CreateBy = HttpContext.Session.GetString("OfficerId").ToString();
                if (data.RoleId == null)
                {
                    data.RoleId = 2;
                }
                _db.Officer.Add(data);
                _db.SaveChanges();
                int save = _db.SaveChanges();
                if (save == 0)
                {
                    ViewBag.username = "";
                    ViewBag.password = "";
                    return RedirectToAction("Index", "Officer");

                }
                else
                {
                    return View(data);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception Message: " + ex.InnerException.Message);

                }
            }

            return View();
        }

        public IActionResult GetAllData()
        {
            var query =
            from Officer in _db.Officer // ตารางที่ 1
            join Sex in _db.Sex // ตารางที่ 2
            on Officer.SexId equals Sex.SexId // เงื่อนไขในการเชื่อมตาราง
            join Role in _db.Role
            on Officer.RoleId equals Role.RoleId
            select new
            {
                Id = Officer.Officer_Id,
                Username = Officer.Username,
                Name = Officer.Firstname,
                Sirname = Officer.Lastname,
                Phone = Officer.Phone_number,
                Role = Role.RoleName,
                SexName = Sex.SexName,
            };

            int i = 0;
            var OfficerList = new List<dynamic>();
            foreach (var item in query)
            {
                dynamic obj = new ExpandoObject();
                obj.i = ++i;
                obj.Id = item.Id;
                obj.Username = item.Username;
                obj.Name = item.Name;
                obj.Sirname = item.Sirname;
                obj.Phone = item.Phone;
                obj.Role = item.Role;
                obj.SexName = item.SexName;
                OfficerList.Add(obj);
            }

            return Json(new { data = OfficerList.OrderBy(o => o.Id) });
        }

        [HttpPost]
        public JsonResult Edit([FromBody] Officer obj)
        {
            Officer officer = new Officer();
            if(obj != null)
            {
                officer = _db.Officer.Where(c => c.Officer_Id == obj.Officer_Id).FirstOrDefault();
            }
            return Json(officer);
        }

    }
}
