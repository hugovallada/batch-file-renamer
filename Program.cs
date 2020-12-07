using System.IO;
using System;
using batch_file_renamer.Renamer;

namespace batch_file_renamer
{
    class Program
    {

        public static string option;
        public static string path;
        public static string baseName;
        static void Main(string[] args)
        {

            Console.WriteLine("Batch File Renamer - Versão 1.0");
            Console.WriteLine("Deseja trabalhar com arquivo ou diretório? (file/dir)");

            option = Console.ReadLine();

            if (option.ToLower().Trim() == "dir")
            {
                Console.WriteLine("Qual o caminho do diretório?");
                path = Console.ReadLine();

                if (Directory.Exists(path))
                {
                    Console.WriteLine("Qual o nome base dos novos arquivos? Deixe em branco para utilizar um contador");
                    baseName = Console.ReadLine();

                    FileRenamer.RenameFiles(path, baseName);
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
            else
            {
                Console.WriteLine("A opção selecionada não existe");
            }
        }
    }
}
