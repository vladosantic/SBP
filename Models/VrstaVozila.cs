using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class VrstaVozila
{
    public int VrstaId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Vozilo> Vozilos { get; set; } = new List<Vozilo>();
}
