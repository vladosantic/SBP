using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using VP.Models;
using VP.Controllers;



namespace VP.Models;

public partial class Vozilo
{
    [Key]
    public int IdVozila { get; set; }

    public int? ModelVozila { get; set; } 

    public string? BrojSasije { get; set; } 

    public string? RegistracijskaOznaka { get; set; } 

    public int GodinaProizvodnje { get; set; } 

    public int? VrstaVozila { get; set; } 

    public int? IdLokacije { get; set; } 

    public string? Gorivo { get; set; } 

    public string? Kategorija { get; set; }

    public virtual ICollection<DodjelaVozila> DodjelaVozilas { get; set; } = new List<DodjelaVozila>();

    public virtual LokacijaVozila? IdLokacijeNavigation { get; set; }

    public virtual ModelVozila? ModelVozilaNavigation { get; set; } 

    public virtual VrstaVozila? VrstaVozilaNavigation { get; set; }

    public string? PictureName { get; set; }

    public byte[]? PictureData { get; set; }
}
