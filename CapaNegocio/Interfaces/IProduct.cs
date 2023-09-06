using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface IProduct
    {
        List<Product> GetProducts();

        void SetProduct(Product product);


    }
}
