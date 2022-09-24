using Oracle.ManagedDataAccess.Client;
using Projekat.DTO;
using Projekat.Model;
using Projekat.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmovi.UIHandler
{
    public class ComplexQueryUIHandler
    {
        ComplexService complexService = new ComplexService();
        public void HandleComplexQueryMenu()
        {
            String answer;
            do
            {
                Console.WriteLine("\nOdaberite funkcionalnost:");
                Console.WriteLine("\n1  - Rezultati vozaca po id");
                Console.WriteLine("\n2  - Vozaci po drzavama");
                Console.WriteLine("\n3  - Dodavanje rezultata");
                Console.WriteLine("\n4  - Ispis staza po drzavi");
                Console.WriteLine("\nX  - Izlazak iz kompleksnih upita");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        RezVozaca();
                        break;
                    case "2":
                        VozaciPoDrzavama();
                        break;      
                    case "3":
                        DodajRezultat();
                        break;    
                    case "4":
                        StazePoDrzavi();
                        break;                    
                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void StazePoDrzavi()
        {
            Console.WriteLine("Unesi naziv drzave: ");
            string drzava = Console.ReadLine();
            List<VozaciPoStazi> lista = complexService.GetVozaciPoStaziUDrzavi(drzava);
            foreach (VozaciPoStazi item in lista)
            {
                Staza s = item.Staza;
                Console.WriteLine(Staza.getFormatedHeader()+"     Ukupna duzina  Prosecna maksimana brzina");
                Console.WriteLine(s+"      "+(s.DuzKrug*s.BrojKrug)+"               "+item.ProsecnaMaksimalnaBrzina);
                Console.WriteLine("Prvoplasirani vozaci:");
                foreach (Prvoplasirani p in item.Prvoplasirani)
                {
                    Console.WriteLine(p.Ime+"   "+ p.Prezime + "   "+ p.Sezona + "   "+p.BrojBodova);
                }
            }

        }

        void RezVozaca()
        {
            try
            {


                Console.WriteLine("Unesite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                RezultatiVozaca rez = complexService.GetRezultatiVozaca(id);
                Console.WriteLine("Vozac sa idom {0}: ", rez.Idv);
                Console.WriteLine(Rezultat.getFormatedHeader());
                foreach (var item in rez.Rezultati)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Prosecna maksimalna brzina je: " + rez.Prosecna);
            }
            catch(DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        void VozaciPoDrzavama()
        {
            try
            { 
            var rez = complexService.VozaciPoDrzavama();
            foreach (var item in rez)
            {
                Console.WriteLine(item.Drzava+":");
                Console.WriteLine(Vozac.getFormatedHeader());
                foreach (var vozac in item.Vozaci)
                {
                    Console.WriteLine(vozac);
                }
                Console.WriteLine("Prosecno godiste vozaca: {0}; Ukupno titula: {1}",item.ProsecnoGodiste, item.UkupnoTitula);
                Console.WriteLine("Vozaci su uzeli {0} titula na stazama svoje drzave",item.TituleKuci);
                Console.WriteLine();
            }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        void DodajRezultat()
        {
            try
            {
            Console.WriteLine("Unesi idr: ");
            string idr = Console.ReadLine();
            Console.WriteLine("Unesi idv: ");
            int idv = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesi ids: ");
            int ids = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesi sezonu: ");
            int sezona = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesi plasman: ");
            int plasman = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesi bodove: ");
            int bodovi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesi maksimalnu brzinu: ");
            double maks= Convert.ToDouble(Console.ReadLine());
            Rezultat rezultat = new Rezultat { Idr = idr, Bodovi = bodovi, Ids = ids, Idv = idv, MaksBrzina = maks, Plasman = plasman, Sezona = sezona };
            complexService.DodajRezultat(rezultat);
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
