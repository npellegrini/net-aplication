using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantIteraciones = 5;
            string[] palabras = new string[5];

            for (int i = 0; i < cantIteraciones; i++)
            {
                System.Console.WriteLine("Ingrese palabra " + i);
                palabras[i] = System.Console.ReadLine();
            }

            for (int i = 4; i >= 0; i--)
                System.Console.WriteLine(palabras[i]);
            System.Console.ReadLine();
        }
    }
}
