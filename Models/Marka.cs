using System;
using System.Collections.Generic;

namespace VP.Models;

public partial class Marka
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<ModelVozila> ModelVozilas { get; set; } = new List<ModelVozila>();
}
