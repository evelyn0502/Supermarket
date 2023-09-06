using CapaDatos;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Clases
{
    public class LogicSupermarket : ISupermarket
    {
        private ApiContext db;

        public LogicSupermarket(ApiContext db)
        {
            this.db = db;
        }

        public List<Supermarket> GetSupermarkets() 
        {
            return db.Supermarkets.ToList();
        }

        public void SetSupermarket(Supermarket supermarket)
        {
            db.Supermarkets.Add(supermarket);
            db.SaveChanges();
        }

        public void UpdateSupermarket(int id, Supermarket updatedSupermarket)
        {
            var existingSupermarket = db.Supermarkets.Find(id);

            if (existingSupermarket == null)
            {
                throw new Exception("No se encontró el supermercado");
            }

            // Actualiza las propiedades del supermercado existente con las propiedades del objeto actualizado
            existingSupermarket.Nombre = updatedSupermarket.Nombre;
            existingSupermarket.CantTrabajadores = updatedSupermarket.CantTrabajadores;
            existingSupermarket.Telefono = updatedSupermarket.Telefono;
            existingSupermarket.Direccion = updatedSupermarket.Direccion;
            existingSupermarket.Ciudad = updatedSupermarket.Ciudad;

            // Guarda los cambios en la base de datos
            db.SaveChanges();
        }



        public void DeleteSupermarket(int id)
        {
            try
            {
                var existingSupermarket = db.Supermarkets.Find(id);

                if (existingSupermarket == null)
                {
                    throw new Exception("No se encontró el supermercado");
                }

                // Elimina el supermercado de la base de datos
                db.Supermarkets.Remove(existingSupermarket);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el supermercado: " + ex.Message);
            }
        }


        public List<Supermarket> GetSupermarketsByCityAndWorkers(string ciudad, int? cantTrabajadores)
        {
            return db.Supermarkets
                     .Where(s => s.Ciudad == ciudad && (!cantTrabajadores.HasValue || s.CantTrabajadores == cantTrabajadores))
                     .ToList();
        }


    }
}
