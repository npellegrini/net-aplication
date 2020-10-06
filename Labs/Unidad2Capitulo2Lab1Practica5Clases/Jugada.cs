using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2Capitulo2Lab1Practica5Clases
{
    class Jugada
    {
        private int numero, intentos;
        private bool adivino;
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public int Intentos { get; set; }
        public bool Adivino { get; set; }

        public Jugada (int maxNumero)
        {
            Random rnd = new Random();
            Numero = rnd.Next(maxNumero);
        }

    }
}
