using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ISupermarket
    {
        List<Supermarket> GetSupermarkets();

        void SetSupermarket(Supermarket supermarket);

        void UpdateSupermarket(int id, Supermarket updatedSupermarket);


        void DeleteSupermarket(int id);

        List<Supermarket> GetSupermarketsByCityAndWorkers(string ciudad, int? cantTrabajadores);

    }
}
