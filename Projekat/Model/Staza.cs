using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Model
{
    public class Staza
    {
        private int ids;
        private string nazivs;
        private int brojKrug;
        private double duzKrug;
        private int drzs;

        public int Ids { get => ids; set => ids = value; }
        public string Nazivs { get => nazivs; set => nazivs = value; }
        public int BrojKrug { get => brojKrug; set => brojKrug = value; }
        public double DuzKrug { get => duzKrug; set => duzKrug = value; }
        public int Drzs { get => drzs; set => drzs = value; }

        public Staza() { }

        public Staza(int ids, string nazivs, int brojKrug, double duzKrug, int drzs)
        {
            this.Ids = ids;
            this.Nazivs = nazivs;
            this.BrojKrug = brojKrug;
            this.DuzKrug = duzKrug;
            this.Drzs = drzs;
        }

        public static string getFormatedHeader()
        {
            return string.Format("{0,-4} {1,-20} {2,-9} {3,-7} {4,-4}", "IDS", "NAZIVS", "BROJKRUG", "DUZKRUG", "DRZS");
        }
        public override string ToString()
        {
            return string.Format("{0,-4} {1,-20} {2,-9} {3,-7} {4,-4}", Ids, Nazivs, BrojKrug, DuzKrug, Drzs);
        }
    }
}
