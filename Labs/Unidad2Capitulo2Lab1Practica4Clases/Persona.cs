using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2Capitulo2Lab1Practica4Clases
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        private int edad;
        private string dni;

        public Persona (string n, string a, int e, string d)
        {
            Nombre = n;
            Apellido = a;
            Edad = e;
            Dni = d;
            Console.WriteLine("Persona creada.");
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public int Edad { get; set; }
        ~Persona()
        {
            Console.WriteLine("El objeto persona ha sido destruido.");
        }

        public string getFullName()
        {
            return Nombre + " " + Apellido;
        }

    }
}
