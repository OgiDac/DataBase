using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DTO
{
    public class VozaciPoDrzavama
    {
        public string Drzava { get; set; }
        public List<Vozac> Vozaci { get; set; }
        public double ProsecnoGodiste { get; set; }
        public int UkupnoTitula { get; set; }
        public int TituleKuci { get; set; }

    }
}
