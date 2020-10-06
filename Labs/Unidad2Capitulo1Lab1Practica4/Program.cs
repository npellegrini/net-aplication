using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el primer sumando: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo sumando: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("El resultado de la suma de " + n1 + " y " + n2 + " es " + n1 + n2 + ".");
            Console.ReadKey();
        }
    }
}
