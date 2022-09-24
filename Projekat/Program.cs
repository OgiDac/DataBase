using Projekat.UIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Projekat
{
    class Program
    {
        static void Main(string[] args)
        {
            MainUIHandler mainUIHandler = new MainUIHandler();
            mainUIHandler.HandleMainMenu();
            Console.WriteLine("Kraj programa");
            Console.ReadKey();
        }
    }
}
