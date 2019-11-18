using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_20_Coffee_Shop_Part_3.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_20_Coffee_Shop_Part_3.Controllers
{
    public class ShopController : Controller
    {
        private readonly UserDbContext _context;

        public ShopController(UserDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
