#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Models;

namespace MyWebSite.Data
{
    public class MyWebSiteContext : DbContext
    {
        public MyWebSiteContext (DbContextOptions<MyWebSiteContext> options)
            : base(options)
        {
        }

        public DbSet<MyWebSite.Models.Article> Article { get; set; }

        public DbSet<MyWebSite.Models.Experience> Experience { get; set; }

        public DbSet<MyWebSite.Models.Portfolio> Portfolio { get; set; }

        public DbSet<MyWebSite.Models.Skill> Skill { get; set; }

        public DbSet<MyWebSite.Models.Message> Message { get; set; }

        

    }
}
