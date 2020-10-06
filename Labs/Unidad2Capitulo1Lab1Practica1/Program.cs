using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Ingrese un texto: ");
            string inputTexto = System.Console.ReadLine();
            if (inputTexto == null)
                System.Console.WriteLine("No ha ingresado nada.");
            else
            {
                System.Console.WriteLine("Ingrese una opción: \n1) A mayúsculas \n2) A minúsculas \n3) Longitud");
                ConsoleKeyInfo opcion = Console.ReadKey();
                if (opcion.Key == ConsoleKey.D1)
                {
                    inputTexto = inputTexto.ToUpper();
                    Console.WriteLine(inputTexto);
                    Console.ReadKey();
                }
                else if (opcion.Key == ConsoleKey.D2)
                {
                    inputTexto = inputTexto.ToLower();
                    Console.WriteLine(inputTexto);
                    Console.ReadKey();
                }
                else if (opcion.Key == ConsoleKey.D3)
                {
                    Console.WriteLine(inputTexto.Length);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Opción incorrecta.");
                    Console.ReadKey();
                }

            }
        }
    }
}