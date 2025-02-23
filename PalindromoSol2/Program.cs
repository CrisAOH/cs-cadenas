namespace PalindromoSol2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string palabra, palabraInvertida = "";

            Console.Write("Ingresa una palabra para saber si es un palíndromo o no: ");
            palabra = Console.ReadLine();

            foreach (char letra in palabraInvertida)
            {
                palabraInvertida = letra + palabraInvertida
            }

            if (palabra.Equals(palabraInvertida, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\"{palabra}\" es un palíndromo");
            }
            else
            {
                Console.WriteLine($"\"{palabra}\" no es un palíndromo");
            }
        }
    }
}
