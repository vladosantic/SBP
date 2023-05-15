using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VP.Models;
using System.ComponentModel.DataAnnotations.Schema;
using VP.Controllers;

namespace VP.Models;

public partial class Pozicija
{
    [Key]
    public int PozicijaId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Uposlenik> Uposleniks { get; set; } = new List<Uposlenik>();
}
