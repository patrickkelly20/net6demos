using System;
using System.Security.Cryptography;
using System.IO;


namespace DemoNet6FileSHA256HashingConsoleApp
{
    public class Program
    {


        public static void Main(string[] args)
        {
            string message = "Please enter a file name";
            string outputHash = "";
            string inputFileName = Console.ReadLine().Trim().Trim('.');
            if (File.Exists(inputFileName))
            {
                outputHash = Sha256Hash(inputFileName);
            }
            if (outputHash == "")
            {

                Console.WriteLine("Something went wrong. We could not find the file. ");
            }
            else
            {
                Console.WriteLine("The HASH is: ");
                Console.WriteLine(outputHash);
            }
            Console.WriteLine("Thank you have a great day!");
            Console.ReadLine();
        }


        private static string Sha256Hash(string fileName) { 
            using (var SHA = SHA256.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(SHA.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }
    }
}
