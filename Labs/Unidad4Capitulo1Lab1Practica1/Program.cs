using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Unidad4Capitulo1Lab1Practica1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream lector = new FileStream("Agenda.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            while ( lector.Length >lector.Position)
            {
                Console.Write((char)lector.ReadByte());
            }
            lector.Close();
            Console.ReadKey();

        }
    }
}
