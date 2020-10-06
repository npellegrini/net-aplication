using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2Capitulo2Lab1Practica1Clases
{
    public class A
    {
        String _nombreInstancia;

        public A()
        {
            _nombreInstancia = "Instancia sin nombre";
        }

        public A(String n)
        {
            _nombreInstancia = n;
        }

        public void mostrarNombre()
        {
            Console.WriteLine(_nombreInstancia);
            Console.ReadKey();
        }

        public void m1()
        {
            Console.WriteLine("M1 invocado.");
            Console.ReadKey();
        }

        public void m2()
        {
            Console.WriteLine("M2 invocado.");
            Console.ReadKey();
        }

        public void m3()
        {
            Console.WriteLine("M3 invocado.");
            Console.ReadKey();
        }
    }
}
