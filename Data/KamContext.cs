
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using KamelijaWeb.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace KamelijaWeb.Data
{
    public class KamContext:DbContext
    {
        private readonly IConfiguration _config;
        public KamContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public string ContentRootPath { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:KamContextDb"]);
        }
            
    }
}
