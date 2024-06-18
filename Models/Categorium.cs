﻿using System;
using System.Collections.Generic;

namespace Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
