using Microsoft.AspNetCore.Mvc;
using MovieMVC.Data;
using MovieMVC.Models;
using SQLitePCL;
using System.Diagnostics;

namespace MovieMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieMVCContext _context;

        public HomeController(ILogger<HomeController> logger, MovieMVCContext context)
        {
            _logger = logger;
            _context = context;
        }

        private List<Post> GetAllPosts()
        {
            List<Post> posts = _context.Posts.OrderByDescending(p => p.ReleaseDate).ToList();
            return posts;
        }
        public IActionResult Index()
        {
            List<Post> posts = GetAllPosts();
            return View(posts);
        }
        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}