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

public partial class VrstaVozila
{
    [Key]
    public int VrstaId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Vozilo> Vozilos { get; set; } = new List<Vozilo>();
}
