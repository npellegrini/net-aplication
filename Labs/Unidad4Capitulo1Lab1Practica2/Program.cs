﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Unidad4Capitulo1Lab1Practica2
{
    class Program
    {
        static void Main(string[] args)
        {
            leer();
            escribir();
            leer();
            Console.ReadKey();

        }

        private static void leer()
        {
            StreamReader lector = File.OpenText("Agenda.txt");
            string linea;
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    string[] valores = linea.Split(';');
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", valores[0], valores[1], valores[2], valores[3]);
                }
            } while (linea != null);
            lector.Close();
        }
        private static void escribir()
        {
            StreamWriter escritor = File.AppendText("Agenda.txt");
            Console.WriteLine("Ingrese nuevos contactos (S/N)");
            string rta = "S";
            while (rta== "S")
            {
                Console.Write("Ingrese nombre:");
                string nombre = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese apellido:");
                string apellido = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese e-mail:");
                string email = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese telefono:");
                string telefono = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                escritor.WriteLine(nombre + ";" + apellido + ";" + email + ";" + telefono );
                Console.Write("¿desea ingresar otro contacto? (S/N)");
                rta = Console.ReadLine();
            }
            escritor.Close();
        }
    }
}
