using CapaDatos;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupermarketController : ControllerBase
    {
        ISupermarket _supermarket;//instancia

        public SupermarketController(ISupermarket supermarket)
        {
            _supermarket = supermarket;
        }

        // GET: api/<SupermarketController>
        [HttpGet]
        public IEnumerable<Supermarket> Get()
        {
           return _supermarket.GetSupermarkets();
        }

        // GET api/<SupermarketController>
        [HttpGet("{ciudad}/{cantTrabajadores}")]
        public IActionResult Get(string ciudad, int? cantTrabajadores)
        {
            try
            {
                // Llama al método de la capa de lógica para obtener información del supermercado
                // utilizando los parámetros ciudad y cantTrabajadores para filtrar
                var supermarkets = _supermarket.GetSupermarketsByCityAndWorkers(ciudad, cantTrabajadores);

                if (supermarkets == null || supermarkets.Count == 0)
                {
                    return NotFound("No se encontraron supermercados que coincidan con los criterios de búsqueda");
                }

                return Ok(supermarkets); // Devuelve la lista de supermercados encontrados
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la consulta
                return BadRequest(ex.Message); // Devuelve un resultado BadRequest con un mensaje de error
            }
        }


        // POST api/<SupermarketController>
        [HttpPost]
        public void Post([FromBody] Supermarket value)
        {
            _supermarket.SetSupermarket(value);
        }

        // PUT api/<SupermarketController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Supermarket updatedSupermarket)
        {
            try
            {
                // Llama al método de la capa de lógica para actualizar el supermercado
                _supermarket.UpdateSupermarket(id, updatedSupermarket);

                return Ok(updatedSupermarket); // Devuelve el supermercado actualizado
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la actualización
                return BadRequest(ex.Message); // Devuelve un resultado BadRequest con un mensaje de error
            }
        }


        // DELETE api/<SupermarketController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Llama al método de la capa de lógica para eliminar el supermercado
                _supermarket.DeleteSupermarket(id);

                return Ok("Supermercado eliminado exitosamente");
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la eliminación
                return BadRequest(ex.Message);
            }
        }

    }
}
