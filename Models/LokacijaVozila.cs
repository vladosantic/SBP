using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class LokacijaVozila
{
    public int Id { get; set; }

    public string NazivLokacije { get; set; } = null!;

    public virtual ICollection<Vozilo> Vozilos { get; set; } = new List<Vozilo>();
}
