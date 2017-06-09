using System;
using Alp3476;

namespace TestRinjdael
{
    class Program
    {
        static void Main(string[] args)
        {
            string original = "This is a text to encrypt!";
            string password = "ThisIsMyPassword";


            string encriptado = SimpleRijndael.Encrypt(original, password);
            string desencriptado = SimpleRijndael.Decrypt(encriptado, password);

            Console.WriteLine("Encriptado:");
            Console.WriteLine(encriptado);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Desencriptado:");
            Console.WriteLine(desencriptado);

            Console.ReadKey();

        }
    }
}
