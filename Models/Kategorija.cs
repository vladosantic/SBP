using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class Kategorija
{
    public int IdKategorije { get; set; }

    public string NazivKategorije { get; set; } = null!;

    public string OpisKategorije { get; set; } = null!;

    public virtual ICollection<UposlenikKategorija> UposlenikKategorijas { get; set; } = new List<UposlenikKategorija>();
}
