using System.Web.Mvc;

namespace BookeNeest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "BookeNeest is the best place to find great books to read as it is designed to share ideas between most passionate and pretentious readers all over the world!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "la la la";

            return View();
        }
    }
}