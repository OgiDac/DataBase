using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Model
{
    public class Rezultat
    {
        private string idr;
        private int idv;
        private int ids;
        private int sezona;
        private int plasman;
        private int bodovi;
        private double maksBrzina;

        public string Idr { get => idr; set => idr = value; }
        public int Idv { get => idv; set => idv = value; }
        public int Ids { get => ids; set => ids = value; }
        public int Sezona { get => sezona; set => sezona = value; }
        public int Plasman { get => plasman; set => plasman = value; }
        public int Bodovi { get => bodovi; set => bodovi = value; }
        public double MaksBrzina { get => maksBrzina; set => maksBrzina = value; }

        public Rezultat() { }

        public Rezultat(string idr, int idv, int ids, int sezona, int plasman, int bodovi, float maksBrzina)
        {
            this.Idr = idr;
            this.Idv = idv;
            this.Ids = ids;
            this.Sezona = sezona;
            this.Plasman = plasman;
            this.Bodovi = bodovi;
            this.MaksBrzina = maksBrzina;
        }

        public static string getFormatedHeader()
        {
            return string.Format("{0,-4} {1,-6} {2,-6} {3,-6} {4,-7} {5,-6} {6,-10}", "IDR", "IDV", "IDS", "SEZONA", "PLASMAN", "BODOVI", "MAKSBRZINA");
        }
        public override string ToString()
        {
            return string.Format("{0,-4} {1,-6} {2,-6} {3,-6} {4,-7} {5,-6} {6,-10:F2}", Idr, Idv, Ids, Sezona, Plasman, Bodovi, MaksBrzina);
        }
    }
}
