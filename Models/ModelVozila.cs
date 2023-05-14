using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class ModelVozila
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public int IdMarke { get; set; }

    public virtual Marka IdMarkeNavigation { get; set; } = null!;

    public virtual ICollection<Vozilo> Vozilos { get; set; } = new List<Vozilo>();
}
