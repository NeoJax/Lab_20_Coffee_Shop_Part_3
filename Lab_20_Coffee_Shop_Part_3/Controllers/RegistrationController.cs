using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Lab_20_Coffee_Shop_Part_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_20_Coffee_Shop_Part_3.Controllers
{
    public class RegistrationController : Controller
    {
        public List<User> users = new List<User>();
        string filePath = @"../Models/Users.txt";
        //private readonly UserDbContext _context;

        //public RegistrationController(UserDbContext context)
        //{
        //    _context = context;
        //}

        // GET: /<controller>/
        public IActionResult Index()
        {
            string userListJson = HttpContext.Session.GetString("UserListSession");
            if (userListJson != null)
            {
                List<User> userses = JsonConvert.DeserializeObject<List<User>>(userListJson);
                return View(userses);
            }
            return View();
        }

        public IActionResult SaveUser(User user)
        {
            PopulateFromSession();
            users.Add(user);
            //StreamWriter writer = new StreamWriter(filePath, true);
            //writer.WriteLine(user.UserName + "|" + user.Email + "|" + user.Pass + "|" + user.Regular + "|" + user.Member);
            //writer.Close();
            //_context.Users.Add(user);
            HttpContext.Session.SetString("UserListSession", JsonConvert.SerializeObject(users));
            return RedirectToAction("Index");
        }

        public IActionResult Registration()
        {
            return View();
        }


        public void PopulateFromSession()
        {
            string userListJson = HttpContext.Session.GetString("UserListSession");
            if (userListJson != null)
            {
                users = JsonConvert.DeserializeObject<List<User>>(userListJson);
            }
        }
    }
}
