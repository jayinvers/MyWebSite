using Microsoft.AspNetCore.Mvc;
using MyWebSite.Models;
using MyWebSite.Data;


namespace MyWebSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly MyWebSiteContext _context;
        public ContactController(MyWebSiteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        /*[Route("/contact-test")]*/
        [HttpPost]
        public IActionResult LeaveMessage(string fullName, string email, string message)
        {
            Message message1 = new Message();
            message1.FullName = fullName;
            message1.Email = email;
            message1.Body = message;
            message1.CreatedAt = DateTime.Now;
            _context.Message.Add(message1);
            try
            {
                _context.SaveChanges();
                ViewData["msg"] = $"A message from {fullName}, {email} has been sent successfully. <br /> Message Body: {message}";
            }
            catch (Exception ex)
            {

                ViewData["msg"] = $"Some thing went wrong.{ex.Message}";
            }
            
            
            return View();

        }
    }
}
