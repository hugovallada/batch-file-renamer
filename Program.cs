using System.IO;
using System;

namespace batch_file_renamer
{
    class Program
    {

        public static string option;
        public static string path;
        static void Main(string[] args)
        {

            Console.WriteLine("Batch File Renamer - Versão 1.0");
            Console.WriteLine("Deseja trabalhar com arquivo ou diretório? (file/dir)");

            option = Console.ReadLine();

            if (option.ToLower().Trim() == "dir")
            {
                Console.WriteLine("Qual o caminho do diretório?");
                path = Console.ReadLine();

                Console.WriteLine(path);

                if (Directory.Exists(path))
                {
                    Console.WriteLine("O diretório existe");
                    string[] files = Directory.GetFiles(path);
                    Console.WriteLine("Files: ");

                    foreach (var file in files)
                    {
                        Console.WriteLine(file);
                    }
                }
                else
                {
                    Console.WriteLine("O diretório não existe");
                }

            }
            else if (option.ToLower().Trim() == "file")
            {
                Console.WriteLine("Você selecionou arquivo");
            }
        }
    }
}
