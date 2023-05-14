using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class UposlenikKategorija
{
    public int Id { get; set; }

    public int IdUposlenik { get; set; }

    public int IdKategorije { get; set; }

    public virtual Kategorija IdKategorijeNavigation { get; set; } = null!;

    public virtual Uposlenik IdUposlenikNavigation { get; set; } = null!;
}
