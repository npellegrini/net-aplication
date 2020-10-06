using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Ingrese un texto: ");
            string inputTexto = System.Console.ReadLine();
            if (inputTexto == null)
                System.Console.WriteLine("No ha ingresado nada.");
            else
            {
                System.Console.WriteLine("Ingrese una opción: \n1) A mayúsculas \n2) A minúsculas \n3) Longitud");
                ConsoleKeyInfo opcion = Console.ReadKey();
                int caseSwitch = 0;
                if (opcion.Key == ConsoleKey.D1)
                {
                    caseSwitch = 1;
                }
                else if (opcion.Key == ConsoleKey.D2)
                {
                    caseSwitch = 2;
                }
                else if (opcion.Key == ConsoleKey.D3)
                {
                    caseSwitch = 3;
                }

                switch (caseSwitch)
                {
                    case 1:
                        inputTexto = inputTexto.ToUpper();
                        Console.WriteLine(inputTexto);
                        Console.ReadKey();

                        break;
                    case 2:
                        inputTexto = inputTexto.ToLower();
                        Console.WriteLine(inputTexto);
                        Console.ReadKey();

                        break;
                    case 3:
                        Console.WriteLine(inputTexto.Length);
                        Console.ReadKey();


                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;
                }
            }
        }
    }
}
