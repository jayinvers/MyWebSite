using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.Controllers
{
    public class ContactController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [Route("/contact-test")]
        public string test()
        {
            return "test";
        }
    }
}
