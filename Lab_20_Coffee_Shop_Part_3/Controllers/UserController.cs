using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_20_Coffee_Shop_Part_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_20_Coffee_Shop_Part_3.Controllers
{
    public class UserController : Controller
    {
        public List<User> users = new List<User>();

        // GET: /<controller>/

        public IActionResult Index()
        {
            string userJson = HttpContext.Session.GetString("UserSession");
            if (userJson != null)
            {
                User currentUser = JsonConvert.DeserializeObject<User>(userJson);
                return View("Index", currentUser);
            }
            return View();
        }

        public IActionResult LogIn(User user)
        {
            PopulateFromSession();
            foreach (var checkUser in users)
            {
                if (checkUser.UserName == user.UserName)
                {
                    if (checkUser.Pass == user.Pass)
                    {
                        HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(checkUser));
                        return View("Index", checkUser);
                    }
                }
            }
            User newUser = new User()
            {
                Member = "Fail"
            };
            return View("Index", newUser);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserSession");
            return View("Index");
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
