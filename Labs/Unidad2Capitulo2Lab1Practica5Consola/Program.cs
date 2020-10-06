using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad2Capitulo2Lab1Practica5Clases;

namespace Unidad2Capitulo2Lab1Practica5Consola
{
    class Program
    {
        public static int record;

        static void Main(string[] args)
        {
            Juego j = new Juego();
            while (j.Jugar() != 2) {
                j.Jugar();
            };
            //Varificar que funcione comenzar una nueva partida. Y ya estaria listo.
        }
    }
}
