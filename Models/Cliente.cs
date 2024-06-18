using System;
using System.Collections.Generic;

namespace Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? NombreUsuario { get; set; }

    public int? TarjetaId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly? Nacimiento { get; set; }

    public string? Direccion { get; set; }

    public string? Pais { get; set; }

    public virtual Usuario? NombreUsuarioNavigation { get; set; }

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual Tarjetum? Tarjeta { get; set; }
}
