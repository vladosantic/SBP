using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using VP.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using VP.Controllers;

namespace VP.Models;

public partial class Marka
{
    [Key]         
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<ModelVozila> ModelVozilas { get; set; } = new List<ModelVozila>();
}
