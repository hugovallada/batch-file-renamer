using System;
using System.IO;
namespace batch_file_renamer.Renamer
{
    public class FileRenamer
    {
        private static string[] ReturnFiles(string path)
        {
            string[] files = Directory.GetFiles(path);

            return files;
        }

        private static bool ContinueRename(string[] files)
        {
            Console.WriteLine("Os seguintes arquivos serão renomeados: ");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("Deseja continuar?(y/N)");
            var continuar = Console.ReadLine();

            if (continuar.ToLower().Trim() == "y") return true;

            return false;
        }

        public static void RenameFiles(string path, string baseName)
        {
            int counter = 0000;

            string[] files = ReturnFiles(path);

            //TODO: Realizar a operação para cancelar a renomeação, caso seja falso
            if (ContinueRename(files))
            {
                Console.WriteLine("Continuará");
            }

            //TODO: Criar a função para identificar as extensões que devem ser renomeadas

            foreach (var file in files)
            {
                Console.WriteLine($"{file} --- {counter}");
                counter++;
                //TODO: Realizar a renomeação

                /*
                * Path.GetExtension(file) retorna a extensão -- Path possui métodos estáticos para trabalhar com os nomes dos arquivos
                */
            }
        }
    }
}