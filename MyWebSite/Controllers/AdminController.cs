#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;

namespace MyWebSite.Controllers
{
   /* [Route("/admin/[controller]/[action]")] */
    public class AdminController : Controller
    {
        private readonly MyWebSiteContext _context;

        public AdminController(MyWebSiteContext context)
        {
            _context = context;
        }

        // GET: Admin/Messages
        public async Task<IActionResult> Messages(int page=1)
        {
            int pageIndex = page;
            int pageSize = 10;

            IQueryable<Message> messageIQ = from m in _context.Message select m;
            messageIQ = messageIQ.OrderByDescending(m => m.CreatedAt);

            int count = await messageIQ.CountAsync();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);

            messageIQ = messageIQ.Skip((pageIndex-1)*pageSize).Take(pageSize);

            ViewData["PaginationTotalPage"] = totalPages;
            ViewData["PaginationIndex"] = pageIndex;

            return View(await messageIQ.AsNoTracking().ToListAsync());
        }

    }
}
