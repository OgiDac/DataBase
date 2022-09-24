using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DTO
{
    public class VozaciPoStazi
    {
        private Staza staza;
        private double prosecnaMaksimalnaBrzina;
        private List<Prvoplasirani> prvoplasirani=new List<Prvoplasirani>();

        public double ProsecnaMaksimalnaBrzina { get => prosecnaMaksimalnaBrzina; set => prosecnaMaksimalnaBrzina = value; }
        public Staza Staza { get => staza; set => staza = value; }
        public List<Prvoplasirani> Prvoplasirani { get => prvoplasirani; set => prvoplasirani = value; }
    }
}
