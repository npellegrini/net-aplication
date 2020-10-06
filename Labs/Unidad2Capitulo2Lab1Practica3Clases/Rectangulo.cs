using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unidad2Capitulo2Lab1Practica3Clases
{
    public class Rectangulo : Poligono
    {
        private int m_base;
        private int m_altura;

        public Rectangulo(int b, int h)
        {
            m_altura = h;
            m_base = b;
        }
        public int b
        {
            get
            {
                return m_base;
            }

            set
            {
                m_base = value;
            }
        }

        public int h
        {
            get
            {
                return m_altura;
            }

            set
            {
                m_altura = value;
            }
        }

        public override void calcularPerimetro()
        {
            int p = (b + h) * 2;
            Console.WriteLine("El perímetro es " + p); 
        }

        public override void calcularSuperficie()
        {
            int s = b * h;
            Console.WriteLine("La superficie es " + s);
        }
    }
}