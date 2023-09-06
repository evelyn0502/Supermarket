using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDatos;

public partial class Product
{
    public int ProductId { get; set; }

    public int SupermarketId { get; set; }

    public string Nombre { get; set; } = null!;

    public int Precio { get; set; }

    public int Stock { get; set; }

    public string Categoria { get; set; } = null!;

    public string Proveedor { get; set; } = null!;

    public virtual Supermarket Supermarket { get; set; } = null!;
}
