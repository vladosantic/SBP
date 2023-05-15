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

public partial class Kategorija
{
    [Key]
    public int IdKategorije { get; set; }

    public string NazivKategorije { get; set; } = null!; 

    public string OpisKategorije { get; set; }  = null!;

    public virtual ICollection<UposlenikKategorija> UposlenikKategorijas { get; set; } = new List<UposlenikKategorija>();
}
