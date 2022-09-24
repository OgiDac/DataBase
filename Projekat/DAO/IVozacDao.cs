using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DAO
{
    public interface IVozacDao
    {
        double ProsecnaMaksimalnaBrzina(int idv);
        IEnumerable<Vozac> VozaciIzDrzave(int idd);
        Tuple<double, int> ProsecnoGodisteITitule(int idd);
    }
}
