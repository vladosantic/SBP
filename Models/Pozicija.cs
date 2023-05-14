using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class Pozicija
{
    public int PozicijaId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Uposlenik> Uposleniks { get; set; } = new List<Uposlenik>();
}
