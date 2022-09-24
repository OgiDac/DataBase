using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DTO
{
    public class Prvoplasirani
    {
        private string ime, prezime;
        private int sezona, brojBodova;

        public int Sezona { get => sezona; set => sezona = value; }
        public int BrojBodova { get => brojBodova; set => brojBodova = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
    }
}
