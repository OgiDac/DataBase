using Projekat.DTO;
using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DAO
{
    public interface IRezultatDao
    {
        List<Rezultat> GetRezultatiVozaca(int idv);
        int GetBrojTitulaKuci(List<Vozac> vozaci);
        void DodajRezultat(Rezultat rezultat);
        List<Prvoplasirani> GetPrvoplasiraniNaStazi(int ids);
    }
}
