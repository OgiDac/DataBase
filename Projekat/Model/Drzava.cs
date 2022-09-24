using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Model
{
    public class Drzava
    {
        private int idd;
        private string nazivd;

        public int Idd { get => idd; set => idd = value; }
        public string NazivD { get => nazivd; set => nazivd = value; }

        public Drzava() { }

        public Drzava(int idd, string nazivg)
        {
            this.Idd = idd;
            this.NazivD = nazivg;
        }

        public static string getFormatedHeader()
        {
            return string.Format("{0,-4} {1,-30}", "IDD", "NAZIVG");
        }
        public override string ToString()
        {
            return string.Format("{0,-4} {1,-30}", Idd, NazivD);
        }

    }
}
