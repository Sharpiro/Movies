using Microsoft.AspNetCore.Mvc;

namespace Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("GetMovieData", "Movies");
        }
    }
}
