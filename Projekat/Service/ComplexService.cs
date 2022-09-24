using Projekat.DAO;
using Projekat.DAO.Implementacija;
using Projekat.DTO;
using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Service
{
    public class ComplexService
    {
        private static readonly IRezultatDao rezultatDao = new RezultatDaoImpl();
        private static readonly IVozacDao vozacDao = new VozacDaoImpl();
        private static readonly IDrzavaDao drzavaDao= new DrzavaDaoImpl();
        private static readonly IStazaDao stazaDao= new StazaDaoImpl();
        public RezultatiVozaca GetRezultatiVozaca(int idv)
        {
            RezultatiVozaca rez = new RezultatiVozaca();
            rez.Idv = idv;
            rez.Rezultati = rezultatDao.GetRezultatiVozaca(idv);
            if(rez.Rezultati.Count==0)
            {
                rez.Prosecna = 0;
                return rez;
            }
            rez.Prosecna = vozacDao.ProsecnaMaksimalnaBrzina(idv);
            return rez;
        }
        public List<VozaciPoDrzavama> VozaciPoDrzavama()
        {
            List<Drzava> drzave = drzavaDao.FindAll().ToList();
            List<VozaciPoDrzavama> rez = new List<VozaciPoDrzavama>();
            foreach (var item in drzave)
            {
                VozaciPoDrzavama v = new VozaciPoDrzavama();
                v.Drzava = item.NazivD;
                v.Vozaci = vozacDao.VozaciIzDrzave(item.Idd).ToList();
                if (v.Vozaci.Count == 0)
                    continue;
                var tmp = vozacDao.ProsecnoGodisteITitule(item.Idd);
                v.ProsecnoGodiste = tmp.Item1;
                v.UkupnoTitula = tmp.Item2;
                v.TituleKuci = rezultatDao.GetBrojTitulaKuci(v.Vozaci);
                rez.Add(v);
            }
            return rez;
        }

        public void DodajRezultat(Rezultat rezultat)
        {
            rezultatDao.DodajRezultat(rezultat);
        }
        public List<VozaciPoStazi> GetVozaciPoStaziUDrzavi(string drzava)
        {
            List<Staza> Staze = stazaDao.GetStazePoDrzavi(drzava).ToList();
            List<VozaciPoStazi> vozaciPoStazama = new List<VozaciPoStazi>();
            foreach (var item in Staze)
            {
                VozaciPoStazi vps = new VozaciPoStazi();
                vps.Staza = item;
                vps.ProsecnaMaksimalnaBrzina = stazaDao.GetProsecnaMaksBrzina(item.Ids);
                vps.Prvoplasirani = rezultatDao.GetPrvoplasiraniNaStazi(item.Ids);
                vozaciPoStazama.Add(vps);
            }
            return vozaciPoStazama;
        }
    }
}
