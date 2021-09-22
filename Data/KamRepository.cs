using KamelijaWeb.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamelijaWeb.Data
{
    public class KamRepository : IKamRepository
    {
        private readonly KamContext _ctx;
        private readonly ILogger<KamRepository> _logger;

        public KamRepository(KamContext ctx,ILogger<KamRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            _logger.LogInformation("GetAllProducts");
            
                return _ctx.Products
                .OrderBy(p => p.Title)
                .ToList();
        }
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }
     
        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
