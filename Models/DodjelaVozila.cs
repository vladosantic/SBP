using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class DodjelaVozila
{
    public int Id { get; set; }

    public int IdUposlenika { get; set; }

    public int IdVozila { get; set; }

    public DateOnly Dodjeljeno { get; set; }

    public DateOnly VratitiDo { get; set; }

    public string Dodatak { get; set; } = null!;

    public virtual Uposlenik IdUposlenikaNavigation { get; set; } = null!;

    public virtual Vozilo IdVozilaNavigation { get; set; } = null!;
}
