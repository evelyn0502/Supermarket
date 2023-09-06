using System;
using System.Collections.Generic;

namespace CapaDatos;

public partial class Supermarket
{
    public int SupermarketId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? CantTrabajadores { get; set; }

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
