using BakeryWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BakeryWebSite.Controllers
{
    public class UserController : Controller
    {
        BakeryContext db;
        public UserController(BakeryContext context)
        {
            db = context;
        }
        public string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
        public IActionResult Login()
        {
            Policy.Authorized = false;
            ViewBag.auth = "Продукция";
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            using (db)
            {
                CategoryGood cg = new CategoryGood();
                cg.Category = db.Categories.ToList<Category>();
                cg.Goods = db.Goods.ToList<Good>();
                foreach (User item in db.Users)
                {
                    if (item.Login == login)
                    {
                        if (item.Password == GetHashString(password))
                        {
                            if (item.Role == "Клиент")
                            {
                                Policy.userid = item.Id;
                                Policy.Authorized = true;
                                string name = db.Users.Find(Policy.userid).Name;
                                ViewBag.auth="Выйти";
                                return View("~/Views/Good/CategoryGoods.cshtml", cg);
                            }
                        }
                    }
                }
            }
            ViewBag.profile = "";
            ViewBag.auth = "Продукция";
            return View();
        }
        public IActionResult SignUp()
        {
            ViewBag.auth = "Продукция";
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(string login, string password, string surname, string name, string email, string phone)
        {
            using (db)
            {
                CategoryGood cg = new CategoryGood();
                cg.Category = db.Categories.ToList<Category>();
                cg.Goods = db.Goods.ToList<Good>();
                foreach (User item in db.Users)
                {
                    if (item.Login == login)
                    {
                        return View();
                    }
                }
                User user = new User(login, GetHashString(password), email, "Клиент", phone, name, surname, "");
                db.Users.Add(user);
                db.SaveChanges();
                Policy.userid = user.Id;
                ViewBag.auth = "Выйти";
                return View("~/Views/Good/CategoryGoods.cshtml", cg);
            }
        }
    }
}
