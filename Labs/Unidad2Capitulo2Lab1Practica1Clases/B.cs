using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2Capitulo2Lab1Practica1Clases
{
    public class B : A
    {
        public B() : base("Instancia de B.")
        { }
        public void m4()
        {
            Console.WriteLine("Método del hijo invocado.");
            Console.ReadKey();
        }
    }
}
