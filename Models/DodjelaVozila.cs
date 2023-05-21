using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VP.Models;
using VP.Controllers;

namespace VP.Models;

public partial class DodjelaVozila
{
    [Key]
    public int Id { get; set; }

    public int? IdUposlenika { get; set; } = null!;

    public int? IdVozila { get; set; } = null!;

    public DateOnly Dodjeljeno { get; set; }

    public DateOnly VratitiDo { get; set; }

    public string Dodatak { get; set; } = null!; 

    public virtual Uposlenik? IdUposlenikaNavigation { get; set; } = null!;

    public virtual Vozilo? IdVozilaNavigation { get; set; } = null!;

    public virtual ModelVozila? ModelVozila
    {
        get { return IdVozilaNavigation?.ModelVozilaNavigation; }
    }


    
}
