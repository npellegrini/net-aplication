using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad2Capitulo2Lab1Practica2Clases;

namespace Unidad2Capitulo2Lab1Practica2Consola
{
    class Program
    {
        static void Main(string[] args)
        {

            B b = new B();
            A a = b;
            a.F();
            b.F();
            a.G();
            b.G();

            Console.ReadKey();

        }
    }
}
