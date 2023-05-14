using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class Uposlenik
{
    public int IdUposlenik { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public int PozicijaId { get; set; }

    public string Adresa { get; set; } = null!;

    public string BrojMobitela { get; set; } = null!;

    public string Jmbg { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly DatumRodjenja { get; set; }

    public virtual ICollection<DodjelaVozila> DodjelaVozilas { get; set; } = new List<DodjelaVozila>();

    public virtual Pozicija Pozicija { get; set; } = null!;

    public virtual ICollection<UposlenikKategorija> UposlenikKategorijas { get; set; } = new List<UposlenikKategorija>();
}
