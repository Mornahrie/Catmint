using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Catmint.Data;
using Catmint.Models;
using Catmint.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Globalization;

namespace Catmint.Controllers
{
    public class ReservController : Controller
    { 
        private readonly ApplicationDbContext _context;

        public ReservController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Create(int tableid = 1, DateTime dateInput = default(DateTime))
        {

            List<Tables> tables = _context.Tables.ToList();
            List<Booked> booked = _context.Bookeds.ToList();

            ReservViewModel ivm = new ReservViewModel { Tables = tables, Booked = booked };
            return View(ivm);
        }
        public IActionResult Choose(int tableid, DateTime dateInput)
        {
            Get.ifChosen = 1;
            Get.table_num = tableid; 
            Get.ForBookTime = dateInput;
            return RedirectToAction("Create");
        }
    }
}
