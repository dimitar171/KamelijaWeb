using KamelijaWeb.Data.Entities;
using System.Collections.Generic;

namespace KamelijaWeb.Data
{
    public interface IKamRepository
    {

        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveChanges();
    }
   
}