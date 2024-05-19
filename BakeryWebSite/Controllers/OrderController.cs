using BakeryWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BakeryWebSite.Controllers
{
    public class OrderController : Controller
    {
        private BakeryContext db;
        public OrderController(BakeryContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Basket()
        {
            User user = new User();
            using (db)
            {
                if (Policy.Authorized)
                {
                    ViewBag.auth = "Продукция";
                    user = db.Users.Find(Policy.userid);

                    return View(user);
                }
            }
            ViewBag.auth = "Продукция";
            return View("~/Views/User/Login.cshtml");
        }
        public ActionResult Order()
        {
            User user = new User();
            using (db)
            {
                if (Policy.Authorized)
                {
                    ViewBag.auth = "Продукция";
                    user = db.Users.Find(Policy.userid);

                    return View(user);
                }
            }
            ViewBag.auth = "Продукция";
            return View("~/Views/User/Login.cshtml");
        }
    }
}
