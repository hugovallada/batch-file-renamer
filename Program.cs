using System.IO;
using System;
using batch_file_renamer.Renamer;

namespace batch_file_renamer
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Batch File Renamer - Versão 1.0");
            try
            {
                menu();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Um erro aconteceu: {exception.Message}");
            }
        }

        static void menu()
        {
            Console.WriteLine("Deseja trabalhar com arquivo ou diretório? (file/dir)\nCaso deseje sair, digite exit!");
            var option = Console.ReadLine();

            if (option.ToLower().Trim() == "dir")
            {
                sandBox(menuDir);
            }
            else if (option.ToLower().Trim() == "file")
            {
                sandBox(menuFile);
            }
            else if (option.ToLower().Trim() == "exit")
            {
                Console.WriteLine("Programa finalizado!!!");
            }
            else
            {
                menu();
            }
        }

        static void menuDir()
        {
            Console.WriteLine("Qual o caminho do diretório?");
            var path = Console.ReadLine();

            if (!Directory.Exists(path)) throw new Exception("O diretório não existe");

            Console.WriteLine("Qual o nome base dos novos arquivos? Deixe em branco para utilizar um contador");
            var baseName = Console.ReadLine();

            FileRenamer.BulkRenamer(path, baseName);
        }

        static void menuFile()
        {
            Console.WriteLine("Qual o caminho do arquivo ?");
            var path = Console.ReadLine();

            if (!File.Exists(path)) throw new Exception("O arquivo não existe");

            Console.WriteLine("Qual o novo nome do arquivo ?");
            var newFileName = Console.ReadLine();

            FileRenamer.SingleRenamer(path, newFileName);

        }

        // Realiza o try/catch das funções específicas e chama o menuPrincipal em caso de erro
        static void sandBox(Action menuFunc)
        {
            try
            {
                menuFunc();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Um erro aconteceu: {exception.Message}");
                menu();
            }
        }

    }
}
