using CapaDatos;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Clases
{
    public class LogicProduct : IProduct
    {
        private ApiContext db;

        public LogicProduct(ApiContext db)
        {
            this.db = db;
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public void SetProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
    }
}
