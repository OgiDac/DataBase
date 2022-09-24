using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Model
{
    public class Vozac
    {
        private int idv;
        private string imev;
        private string prezv;
        private int brojTit;
        private int godRodj;
        private int drzv;

        public Vozac() { }

        public Vozac(int idv, string imev, string prezv, int brojTit, int godRodj, int drzv)
        {
            this.Idv = idv;
            this.Imev = imev;
            this.Prezv = prezv;
            this.BrojTit = brojTit;
            this.GodRodj = godRodj;
            this.Drzv = drzv;
        }

        public int Idv { get => idv; set => idv = value; }
        public string Imev { get => imev; set => imev = value; }
        public string Prezv { get => prezv; set => prezv = value; }
        public int BrojTit { get => brojTit; set => brojTit = value; }
        public int GodRodj { get => godRodj; set => godRodj = value; }
        public int Drzv { get => drzv; set => drzv = value; }

        public static string getFormatedHeader()
        {
            return string.Format("{0,-4} {1,-15} {2,-15} {3,-7} {4,-7} {5,-4}", "IDV", "IMEV", "PREZV", "GODRODJ", "BROJTIT", "DRZV");
        }
        public override string ToString()
        {
            return string.Format("{0,-4} {1,-15} {2,-15} {3,-7} {4,-7} {5,-4}", Idv, Imev, Prezv, GodRodj, BrojTit, Drzv);
        }
    }
}
