using System;
using System.Collections.Generic;

namespace Models;

public partial class Tarjetum
{
    public int TarjetaId { get; set; }

    public int clienteID { get; set }

    public string? Numero { get; set; }

    public string? Cvc { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<TokenPago> TokenPagos { get; set; } = new List<TokenPago>();
}
