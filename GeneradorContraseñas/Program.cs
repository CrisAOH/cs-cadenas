using System;
using System.Text;  

namespace GeneradorContraseñas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombreUsuario, opcion, contrasenia;
            (bool contraseniaValida, string mensajeError) verificarContrasenia;

            Console.WriteLine("\t\tRegistro\n\n");

            Console.Write("Ingresa el nombre de usuario: ");
            nombreUsuario = Console.ReadLine();

            Console.Write("¿Desea que le generemos una contraseña segura? (si/no): ");
            opcion = Console.ReadLine();

            opcion = opcion.ToLower();

            switch (opcion)
            {
                case "si":
                    Contrasenia contrasenia1 = new Contrasenia();
                    contrasenia = contrasenia1.GenerarContrasenia();

                    Console.WriteLine($"Esta es la contraseña que se generó para ti, guárdala en un lugar seguro: {contrasenia}");

                    Console.Write("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine($"\nTus datos de acceso son los siguientes: \n\tusuario: {nombreUsuario}\n\tcontraseña: {contrasenia}");
                    break;
                case "no":
                    Console.Write("\nIngrese una contraseña segura (La contraseña debe contener entre 8 a 20 caracteres, incluyendo un número, una mayúscula, una minúscula y uno de los siguientes caracteres especiales: $%#&!?): ");
                    contrasenia = Console.ReadLine();

                    Contrasenia contrasenia2 = new Contrasenia();

                    verificarContrasenia = contrasenia2.ComprobarContrasenia(contrasenia);

                    if (verificarContrasenia.contraseniaValida)
                    {
                        Console.Write("\nPresiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine($"\nTus datos de acceso son los siguientes: \n\tusuario: {nombreUsuario}\n\tcontraseña: {contrasenia}");
                    }
                    else
                    {
                        Console.WriteLine(verificarContrasenia.mensajeError + ". Ingresa una contraseña válida.");
                    }
                    break;
            }
        }
    }

    class Contrasenia
    {
        string numeros = "0123456789";
        string letrasMin = "abcdefghijklmnopqrstuvwxyz";
        string letrasMay = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string caracterSpecial = "$%&#!?";
        int numContiene = 0, minContiene = 0, mayContiene = 0, espContiene = 0;

        public string GenerarContrasenia()
        {
            //string contraseniaGenerada = "";
            StringBuilder contraseniaGeneradaSB = new StringBuilder();
            Random random = new Random();
            int longitudContrasenia = random.Next(8, 21);

            double numTener = longitudContrasenia * .15;
            double minTener = longitudContrasenia * .35;
            double mayTener = longitudContrasenia * .35;
            double espTener = longitudContrasenia * .15;

            char caracterSeleccionado;

            while (contraseniaGeneradaSB.Length < longitudContrasenia)
            {
                switch(random.Next(0, 4))
                {
                    case 0:
                        if (numContiene < numTener)
                        {
                            caracterSeleccionado = numeros[random.Next(numeros.Length)];
                            contraseniaGeneradaSB.Append(caracterSeleccionado);
                            numContiene++;
                        }
                        break;
                    case 1:
                        if (minContiene < minTener)
                        {
                            caracterSeleccionado = letrasMin[random.Next(letrasMin.Length)];
                            contraseniaGeneradaSB.Append(caracterSeleccionado);
                            minContiene++;
                        }
                        break;
                    case 2:
                        if (mayContiene < mayTener)
                        {
                            caracterSeleccionado = letrasMay[random.Next(letrasMay.Length)];
                            contraseniaGeneradaSB.Append(caracterSeleccionado);
                            mayContiene++;
                        }
                        break;
                    case 3:
                        if (espContiene < espTener)
                        {
                            caracterSeleccionado = caracterSpecial[random.Next(caracterSpecial.Length)];
                            contraseniaGeneradaSB.Append(caracterSeleccionado);
                            espContiene++;
                        }
                        break;
                }
            }

            return contraseniaGeneradaSB.ToString();
        }

        public (bool, string) ComprobarContrasenia(string contraseniaParam)
        {
            bool contraseniaValida = false;
            bool hayNumero = false, hayMinuscula = false, hayMayuscula = false, hayEspecial = false;
            string mensajeError = "";

            if (contraseniaParam.Length >= 8 && contraseniaParam.Length <= 20)
            {
                foreach (char elemento in numeros)
                {
                    if (contraseniaParam.IndexOf(elemento) >= 0)
                    {
                        hayNumero = true;
                        break;
                    }
                    else
                    {
                        hayNumero = false;
                        mensajeError = "La contraseña debe tener al menos un número.";
                    }
                }

                if (hayNumero)
                {
                    foreach (char elemento in letrasMin)
                    {
                        if (contraseniaParam.IndexOf(elemento) >= 0)
                        {
                            hayMinuscula = true;
                            break;
                        }
                        else
                        { 
                            hayMinuscula = false;
                            mensajeError = "La contraseña debe contener al menos una letra minúscula.";
                        }
                    }

                    if (hayMinuscula)
                    {
                        foreach (char elemento in letrasMay)
                        {
                            if (contraseniaParam.IndexOf(elemento) >= 0)
                            {
                                hayMayuscula = true;
                                break;
                            }
                            else
                            {
                                hayMayuscula = false;
                                mensajeError = "La contraseña debe contener al menos una letra mayúscula.";
                            }
                        }

                        if (hayMayuscula)
                        {
                            foreach (char elemento in caracterSpecial)
                            {
                                if (contraseniaParam.IndexOf(elemento) >= 0)
                                {
                                    hayEspecial = true;
                                    break;
                                }
                                else
                                {
                                    hayEspecial = false;
                                    mensajeError = "La contraseña debe contener al menos un caracter especial ($%#&!?).";
                                }
                            }
                        }
                    }
                }

                if (hayNumero && hayMinuscula && hayMayuscula && hayEspecial)
                {
                    contraseniaValida = true;
                }
                else
                {
                    contraseniaValida = false;
                }
            }
            else
            {
                mensajeError = "La contraseña debe tener entre 8-20 caracteres.";
                contraseniaValida = false;
            }

            return (contraseniaValida, mensajeError);
        }
    }
}
