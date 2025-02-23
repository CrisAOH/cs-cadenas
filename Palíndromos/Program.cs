using System;

namespace Palíndromos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string palabra;
            bool esPalindromo;

            Console.WriteLine("¿Es un Palíndromo?");
            Console.Write("Ingrese una palabra para saber si es un palíndromo o no: ");
            palabra = Console.ReadLine();

            esPalindromo = EsPalindromo(palabra.ToLower());

            if (esPalindromo)
            {
                Console.WriteLine($"{palabra} es un palíndromo.");
            }
            else
            {
                Console.WriteLine($"{palabra} no es un palíndromo.");
            }
        }

        public static bool EsPalindromo(string palabra)
        {
            bool esPalindromo = false;
            char[] palabraArray = palabra.ToCharArray();
            char[] palabraReversaArray = new char [palabraArray.Length];
            int j = 0;

            for (int i = palabraArray.Length - 1; i >= 0; i--) 
            {
                palabraReversaArray[j] = palabraArray[i];
                j++;
            }

            for (int i = 0; i <= palabraArray.Length - 1; i++)
            {
                if (palabraArray[i] != palabraReversaArray[i])
                {
                    esPalindromo = false;
                    break;
                }
                else
                {
                    esPalindromo = true;
                }
            }
            return esPalindromo;
        }
    }
}
