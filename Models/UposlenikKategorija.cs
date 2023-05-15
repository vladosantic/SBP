using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Data;
using VP.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace VP.Models;

public partial class UposlenikKategorija
{
    [Key]
    public int Id { get; set; }

    public int? IdUposlenik { get; set; } = null!;

    public int? IdKategorije { get; set; } = null!;

    public virtual Kategorija? IdKategorijeNavigation { get; set; } = null!;

    public virtual Uposlenik? IdUposlenikNavigation { get; set; } = null!;
}
