using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DTO
{
    public class RezultatiVozaca
    {
        public int Idv{ get; set; }
        public List<Rezultat> Rezultati { get; set; } = new List<Rezultat>();
        public double Prosecna { get; set; }
    }
}
