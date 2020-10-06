using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2Capitulo2Lab1Practica3Clases
{
    public class Circulo
    {
        private int m_radio;

        public int radio
        {
            get
            {
                return m_radio;
            }

            set
            {
                m_radio = value;
            }
        }

        public void calcularPerimetro()
        {
            double p = radio * 2 * 3.14;
            Console.WriteLine("El perímetro es " + p);
            Console.ReadKey();
        }

        public void calcularSuperficie()
        {
            double s = radio * radio * 3.14;
            Console.WriteLine("La superficie es " + s);
            Console.ReadKey();
        }
    }
}
