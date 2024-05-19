using BakeryWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BakeryWebSite.Controllers
{
    public class GoodController : Controller
    {
        private BakeryContext db;
        public GoodController(BakeryContext context) 
        {
            db = context;
        }
        public ActionResult Main()
        {
            CategoryGood cg = new CategoryGood();
            using (db)
            {
                cg.Category = db.Categories.ToList<Category>();
                cg.Goods = db.Goods.ToList<Good>();
                if (Policy.Authorized)
                {
                    ViewBag.auth = "Выйти";
                    return View(cg);
                }
            }
            ViewBag.auth = "Войти";
            return View(cg);
        }
        public ActionResult CategoryGoods(int id)
        {
            CategoryGood cg = new CategoryGood();
            using (db)
            {
                cg.Category = db.Categories.ToList<Category>();
                cg.Goods = db.Goods.Where(item => item.Categories_Id == id).ToList();
                if (Policy.Authorized)
                {
                    ViewBag.auth = "Выйти";

                    return View(cg);
                }
            }
            ViewBag.auth = "Войти";
            return View(cg);
        }

        public ActionResult Good(int id)
        {
            GoodComponent gc = new GoodComponent();
            using (db)
            {
                gc.Good = db.Goods.Find(id);
                gc.Components = new List<Component>();
                List<Composition> composition = db.Composition.Where(item => item.Goods_Id == id).ToList();
                foreach(Composition c in composition) {
                    gc.Components.Add(db.Components.Find(c.Components_Id));
                }
            }
            ViewBag.auth = "Продукция";
            return View(gc);
        }

    }
}
