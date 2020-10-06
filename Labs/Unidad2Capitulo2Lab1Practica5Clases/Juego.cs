using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2Capitulo2Lab1Practica5Clases
{
    public class Juego
    {
        // private int record; lo declare en el main con variable de clase.
        public int Record { get; set; }
        public int Jugar()
        {
            Console.WriteLine("Ingrese el numero máximo para adivinar:");
            int max = Int32.Parse(Console.ReadLine());
            Jugada j = new Jugada(max);
            j.Adivino = false;
            j.Intentos = 0; //consultar si esta inicialziado por defecto
            while(j.Adivino == false)
            {
                Console.WriteLine("¡A jugar! Ingrese un número: ");
                int num = Int32.Parse(Console.ReadLine());
                j.Intentos++;
                while (num > max)
                {
                    Console.WriteLine("El número excede al máximo. Intente nuevamente:");
                    num = Int32.Parse(Console.ReadLine());
                }
                if (j.Numero == num)
                {
                    Console.WriteLine("¡Ganaste!");
                    j.Adivino = true;
                    return CompararRecord(j.Intentos);


                }
                else
                {
                    Console.WriteLine("¡Incorrecto! ¿Continuar? (S/N): ");
                    char o = Char.Parse(Console.ReadLine());
                    if (o == 'N')
                    {
                        PreguntarNumero(j.Numero);
                        j.Adivino = true;

                        return PreguntaNuevaPartida();
                    }

                }
            }
            return PreguntaNuevaPartida(); //Verificar que esta condicion de return este correcta y que no finalice el juego antes de tiempo
        }

        public int CompararRecord(int intentos)
        {
            if (intentos > Record)
            {
                Record = intentos;
                Console.WriteLine("¡Nuevo record!");
            }

            return PreguntaNuevaPartida();
                
                
        }

        public void PreguntarMaximo()
        {
            Console.WriteLine("El máximo es " + Record);
        }

        public void PreguntarNumero(int n)
        {
            Console.WriteLine("El número es " + n);
        }
        public int PreguntaNuevaPartida() 
        {
            Console.WriteLine("¿Iniciar una nueva partida? 1: Si, 2: No");
            int n = Int32.Parse(Console.ReadLine());
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
