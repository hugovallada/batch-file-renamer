using System.IO;
using System;
using batch_file_renamer.Renamer;
using System.Runtime.InteropServices;

namespace batch_file_renamer
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Batch File Renamer - Versão 2.0");
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
            Console.WriteLine();

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
            var path = HomePathFix(Console.ReadLine());
            Console.WriteLine();

            if (!Directory.Exists(path)) throw new Exception("O diretório não existe");

            Console.WriteLine("Qual o nome base dos novos arquivos? Deixe em branco para utilizar um contador");
            var baseName = Console.ReadLine();
            Console.WriteLine();

            FileRenamer.BulkRenamer(path, baseName);
        }

        static void menuFile()
        {
            Console.WriteLine("Qual o caminho do arquivo ?");
            var path = HomePathFix(Console.ReadLine());
            Console.WriteLine();

            if (!File.Exists(path)) throw new Exception("O arquivo não existe");

            Console.WriteLine("Qual o novo nome do arquivo ?");
            var newFileName = Console.ReadLine();
            Console.WriteLine();

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

        // Permite o uso de ~ como /home/user no sistema linux
        static string HomePathFix(string path)
        {
            // Caso o sistema não seja linux, retorna o valor digitado sem fazer a verificação
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return path;

            // Pega o caminho diretório Home do usuário 
            var home = Environment.GetEnvironmentVariable("HOME");
            if (path.StartsWith('~'))
            {
                // ~/Documents -> /home/usuario/Documents
                path = path.Replace("~", home);
            }

            return path;
        }
    }
}
