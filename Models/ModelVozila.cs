using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Data;
using VP.Models;
using System.ComponentModel.DataAnnotations.Schema;
using VP.Controllers;

namespace VP.Models;


public partial class ModelVozila
{
    [Key]
    public int Id { get; set; }

    public string Naziv { get; set; }  = null!;

    public int? IdMarke { get; set; } = null!;

    public virtual Marka? IdMarkeNavigation { get; set; } = null!;

    public virtual ICollection<Vozilo> Vozilos { get; set; } = new List<Vozilo>();
}
