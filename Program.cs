using System.IO;
using System;

namespace batch_file_renamer
{
    class Program
    {

        public static string op;
        public static string caminho;
        static void Main(string[] args)
        {

            Console.WriteLine("Batch File Renamer - Versão 1.0");
            Console.WriteLine("Deseja trabalhar com arquivo ou diretório? (file/dir)");

            op = Console.ReadLine();

            if (op.ToLower().Trim() == "dir")
            {
                Console.WriteLine("Qual o caminho do diretório?");
                caminho = Console.ReadLine();

                Console.WriteLine(caminho);

                if (Directory.Exists(caminho))
                {
                    Console.WriteLine("O diretório existe");
                    string[] files = Directory.GetFiles(caminho);
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
            else if (op.ToLower().Trim() == "file")
            {
                Console.WriteLine("Você selecionou arquivo");
            }
        }
    }
}
