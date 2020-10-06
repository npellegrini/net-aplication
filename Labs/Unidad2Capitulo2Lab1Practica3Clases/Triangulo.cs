using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unidad2Capitulo2Lab1Practica3Clases
{
    public class Triangulo : Poligono
    {
        private int m_base;
        private int m_cat2;
        private int m_cat3;
        private int m_altura;

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

        public int c2
        {
            get
            {
                return m_cat2;
            }

            set
            {
                m_cat2 = value;
            }
        }

        public int c3
        {
            get
            {
                return m_cat3;
            }

            set
            {
                m_cat3 = value;
            }
        }

        public override void calcularPerimetro()
        {
            double p = b + c2 + c3;
            Console.WriteLine("El perímetro es " + p);
            Console.ReadKey();
        }

        public override void calcularSuperficie()
        {
            double s = b * h / 2;
            Console.WriteLine("La superficie es " + s);
            Console.ReadKey();
        }
    }
}