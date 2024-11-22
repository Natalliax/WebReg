using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Mathematics;
using System;
using System.Diagnostics;
using System.Globalization;
using WebTest.Models;

namespace WebTest.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home/Index
        public IActionResult Index()
        {
            PopulateViewBags();
            return View();
        }

        // POST: Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(People person)
        {
            if (ModelState.IsValid)
            {
                    _context.Add(person);
                    _context.SaveChanges();

                var masterSchedule = _context.MastSchedules.FirstOrDefault(m => m.Id == person.MastSchedule_Id && m.Date == person.Date);
                if (masterSchedule != null)
                {
                    masterSchedule.IsRegistered = false;
                    _context.SaveChanges();
                }


                TempData["SuccessMessage"] = "Вы успешно записаны!";
                return RedirectToAction(nameof(Index));
            }
            PopulateViewBags();
            return View(person);
        }

        private void PopulateViewBags()
        {
            var time = _context.MastSchedules
                .Select(m => new SelectListItem
                {
                    Value = m.Time.ToString(),
                    Text = m.Time.ToString()
                })
                .ToList();

            var schedule = _context.MastSchedules
                .Where(m => m.IsRegistered)
                .Select(m => DateTime.Parse(m.Date).ToString("dd.MM.yyyy"))
                
                .ToList();

           

            var masters = _context.MastSchedules
      .Select(m => new SelectListItem
      {
          Value = m.Id.ToString(),
          Text = m.Master
      })
      .ToList();

            var services = _context.NameServices
         .Select(s => new SelectListItem
         {
             Value = s.Id.ToString(), // Используем Id
             Text = s.Usl
         }).ToList();

            var materials = _context.Materials
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(), // Используем Id
                    Text = s.Name
                }).ToList();


            ViewBag.TimeOptions = time;
            ViewBag.AvailableDates = schedule;
            ViewBag.MasterOptions = masters;
            ViewBag.NameServices = services;
            ViewBag.MaterialOptions = materials;
        }
    


    [HttpGet]
        public JsonResult GetServicePrice(int serviceId)
        {
            var service = _context.NameServices.FirstOrDefault(s => s.Id == serviceId);
            if (service != null)
            {
                if (decimal.TryParse(service.Price, out decimal price))
                {
                    return Json(price);
                }
            }
            return Json(0);
        }
        
        [HttpGet]
        public JsonResult GetMaterialPrice(int materialId)
        {
            var material = _context.Materials.FirstOrDefault(m => m.Id == materialId);
            if (material != null)
            {
                if (decimal.TryParse(material.Price, out decimal price))
                {
                    return Json(price);
                }
            }
            return Json(0);
        }
        public IActionResult GetMastersByDate(string date)
        {
            if (DateTime.TryParse(date, out DateTime parsedDate))
            {
                var masters = _context.MastSchedules
                    .Where(m => m.Date == parsedDate.ToString("dd.MM.yyyy") && m.IsRegistered)
                    .Select(m => new { id = m.Id, name = m.Master })
                    .ToList();
                return Json(masters);
            }
            return Json(new List<object>());
        }

        public IActionResult GetTimesByDateAndMaster(string date, int masterId)
        {
            if (DateTime.TryParse(date, out DateTime parsedDate))
            {
                var times = _context.MastSchedules
                    .Where(m => m.Date == parsedDate.ToString("dd.MM.yyyy") && m.Id == masterId && m.IsRegistered)
                    .Select(m => m.Time.ToString())
                    .ToList();
                return Json(times);
            }
            return Json(new List<string>());
        }

    }

}








