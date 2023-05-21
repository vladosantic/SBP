using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VP.Models
{
    public class DodjelaVozilaVozilo
    {
        public string Naziv { get; set; } = null!;

        public int Id { get; set; }

        public int? IdUposlenika { get; set; } = null!;

        public int? IdVozila { get; set; } = null!;

        public DateOnly Dodjeljeno { get; set; }

        public DateOnly VratitiDo { get; set; }

        public string Dodatak { get; set; } = null!;

        public virtual Uposlenik? IdUposlenikaNavigation { get; set; } = null!;

        public virtual Vozilo? IdVozilaNavigation { get; set; } = null!;
    }
}
