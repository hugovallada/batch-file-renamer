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
            Console.WriteLine("Deseja trabalhar com arquivo ou diretório? (file/dir)");
            var option = Console.ReadLine();


            if (option.ToLower().Trim() == "dir")
            {
                Console.WriteLine("Qual o caminho do diretório?");
                var path = Console.ReadLine();

                if (Directory.Exists(path))
                {
                    Console.WriteLine("Qual o nome base dos novos arquivos? Deixe em branco para utilizar um contador");
                    var baseName = Console.ReadLine();

                    FileRenamer.BulkRenamer(path, baseName);
                }
                else
                {
                    Console.WriteLine("O diretório não existe");
                }
            }
            else if (option.ToLower().Trim() == "file")
            {
                Console.WriteLine("Qual o caminho do arquivo ?");
                var path = Console.ReadLine();
                Console.WriteLine("Qual o nome base dos novos arquivos? Deixe em branco para utilizar um contador");
                var baseName = Console.ReadLine();
                FileRenamer.SingleRenamer(path, baseName);
            }
            else
            {
                Console.WriteLine("A opção selecionada não existe");
            }
        }

        //TODO: Criar funções para cada opção e fazer tratamento de erros
        static void menu()
        {
            Console.WriteLine("Deseja trabalhar com arquivo ou diretório? (file/dir)");
            var option = Console.ReadLine();

            if (option.ToLower().Trim() == "dir")
            {

            }
            else if (option.ToLower().Trim() == "file")
            {

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

        static void fileDir()
        {
            Console.WriteLine("Qual o caminho do arquivo ?");
            var path = Console.ReadLine();

            if (!File.Exists(path)) throw new Exception("O arquivo não existe");

            Console.WriteLine("Qual o novo nome do arquivo ?");
            var newName = Console.ReadLine();

            FileRenamer.SingleRenamer(path, newName);

        }
    }
}
