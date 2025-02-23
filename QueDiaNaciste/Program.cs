using System;

namespace QueDiaNaciste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fechaNacimiento;
            DateTime fechaNacimientoDate;

            Console.Write("Escribe tu fecha de nacimiento (dia mes año): ");
            fechaNacimiento = Console.ReadLine();

            fechaNacimientoDate = DateTime.Parse(fechaNacimiento);

            Console.WriteLine($"Naciste un día {fechaNacimientoDate.ToString("dddd")}");
        }
    }
}
