using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using VP.Models;
using System.ComponentModel.DataAnnotations.Schema;
using VP.Controllers;


namespace VP.Models;

public partial class Uposlenik
{
    [Key]
    public int IdUposlenik { get; set; }

    public string Ime { get; set; } = null!; 

    public string Prezime { get; set; }  = null!;

    public int? PozicijaId { get; set; } = null!;

    public string Adresa { get; set; }  = null!;

    public string BrojMobitela { get; set; } = null!; 

    public string Jmbg { get; set; }  = null!;
     
    public string Email { get; set; }  = null!;

    public DateOnly DatumRodjenja { get; set; }

    public virtual ICollection<DodjelaVozila> DodjelaVozilas { get; set; } = new List<DodjelaVozila>();

    public virtual Pozicija? Pozicija { get; set; } = null!;

    public virtual ICollection<UposlenikKategorija> UposlenikKategorijas { get; set; } = new List<UposlenikKategorija>();

    public string ImePrezime => $"{Ime} {Prezime}";

}
