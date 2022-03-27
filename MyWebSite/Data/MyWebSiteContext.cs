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
        public MyWebSiteContext (DbContextOptions<MyWebSiteContext> options) : base(options)
        {
        }

        public DbSet<Article> Article { get; set; }

        public DbSet<Experience> Experience { get; set; }

        public DbSet<Portfolio> Portfolio { get; set; }

        public DbSet<Skill> Skill { get; set; }

        public DbSet<Message> Message { get; set; }

        

    }
}
