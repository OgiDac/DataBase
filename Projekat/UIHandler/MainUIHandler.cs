using Filmovi.UIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.UIHandler
{
    public class MainUIHandler
    {
        private readonly ComplexQueryUIHandler complexQueryUIHandler = new ComplexQueryUIHandler();
        private readonly StazaUIHandler stazaUIHandler = new StazaUIHandler();

        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Rukovanje stazama");
                Console.WriteLine("2 - Kompleksni upiti");
                Console.WriteLine("X - Izlazak iz programa");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        stazaUIHandler.HandleMenu();
                        break;
                    case "2":
                        complexQueryUIHandler.HandleComplexQueryMenu();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
    }
}
