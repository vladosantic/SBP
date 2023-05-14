using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class Vozilo
{
    public int IdVozila { get; set; }

    public int ModelVozila { get; set; }

    public string BrojSasije { get; set; } = null!;

    public string RegistracijskaOznaka { get; set; } = null!;

    public int GodinaProizvodnje { get; set; }

    public int VrstaVozila { get; set; }

    public int IdLokacije { get; set; }

    public string Gorivo { get; set; } = null!;

    public string Kategorija { get; set; } = null!;

    public virtual ICollection<DodjelaVozila> DodjelaVozilas { get; set; } = new List<DodjelaVozila>();

    public virtual LokacijaVozila IdLokacijeNavigation { get; set; } = null!;

    public virtual ModelVozila ModelVozilaNavigation { get; set; } = null!;

    public virtual VrstaVozila VrstaVozilaNavigation { get; set; } = null!;
}
