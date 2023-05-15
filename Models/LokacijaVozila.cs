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

public partial class LokacijaVozila
{
    [Key]
    public int Id { get; set; }

    public string NazivLokacije { get; set; }  = null!;

    public virtual ICollection<Vozilo> Vozilos { get; set; } = new List<Vozilo>();
}
