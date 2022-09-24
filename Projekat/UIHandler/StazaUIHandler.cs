using Projekat.Model;
using Projekat.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.UIHandler
{
    public class StazaUIHandler
    {
        private static readonly StazaService stazaService = new StazaService();

        public void HandleMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite funkcionalnost:");
                Console.WriteLine("1  - Prikaz svih");
                Console.WriteLine("2  - Prikaz po identifikatoru");
                Console.WriteLine("3  - Unos jednog");
                Console.WriteLine("4  - Unos vise");
                Console.WriteLine("5  - Izmena po identifikatoru");
                Console.WriteLine("6  - Brisanje po identifikatoru");
                Console.WriteLine("X  - Izlazak iz rukovanja stazama");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowById();
                        break;
                    case "3":
                        HandleSingleInsert();
                        break;
                    case "4":
                        HandleMultipleInserts();
                        break;
                    case "5":
                        HandleUpdate();
                        break;
                    case "6":
                        HandleDelete();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
        private void ShowAll()
        {
            try
            {
                List<Staza> staze = stazaService.FindAll().ToList();
                Console.WriteLine(Staza.getFormatedHeader());
                foreach (var item in staze)
                {
                    Console.WriteLine(item);
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ShowById()
        {
            try
            {
                Console.WriteLine("Unesite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Staza staza = stazaService.FindById(id);
                if (staza == null)
                {
                    Console.WriteLine("Staza ne postoji");
                    return;
                }
                Console.WriteLine(Staza.getFormatedHeader());
                Console.WriteLine(staza);

            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleSingleInsert()
        {
            Console.WriteLine("Unesite id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (!stazaService.ExistsById(id))
                {
                    Console.WriteLine("Unesi naziv staze:");
                    string naziv = Console.ReadLine();
                    Console.WriteLine("Unesi broj krugova staze:");
                    int bk = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Unesi duzinu kruga:");
                    double dk = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Unesi drzavu staze:");
                    int drzs = Convert.ToInt32(Console.ReadLine());
                    Staza s = new Staza(id, naziv, bk, dk, drzs);
                    stazaService.Save(s);
                }
                else
                {
                    Console.WriteLine("Staza sa unetim ID-om vec postoji");
                }

            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleUpdate()
        {
            Console.WriteLine("Unesite id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (stazaService.ExistsById(id))
                {
                    Console.WriteLine("Unesi naziv staze:");
                    string naziv = Console.ReadLine();
                    Console.WriteLine("Unesi broj krugova staze:");
                    int bk = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Unesi duzinu staze:");
                    double dk = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Unesi drzavu staze:");
                    int drzs = Convert.ToInt32(Console.ReadLine());
                    Staza s = new Staza(id, naziv, bk, dk, drzs);
                    stazaService.Save(s);
                }
                else
                {
                    Console.WriteLine("Staza sa unetim ID-om ne postoji");
                }

            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }




        private void HandleDelete()
        {
            Console.WriteLine("Unesite id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (stazaService.ExistsById(id))
                {
                    stazaService.DeleteById(id);
                    Console.WriteLine("Uspesno brisanje");
                }
                else
                {
                    Console.WriteLine("Staza sa unetim ID-om ne postoji");
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }



        private void HandleMultipleInserts()
        {
            {
                int op;
                while (true)
                {
                    Console.WriteLine("[1] Dodaj");
                    Console.WriteLine("[0] Kraj dodavanja");
                    Console.WriteLine("Izaberi opciju");
                    op = Convert.ToInt32(Console.ReadLine());
                    if (op == 0)
                        break;
                    HandleSingleInsert();
                }
            }
        }

    }
}
