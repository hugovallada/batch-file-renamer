using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
namespace batch_file_renamer.Renamer
{
    public class FileRenamer
    {
        private static string[] ReturnFiles(string path)
        {
            string[] files = Directory.GetFiles(path);

            return files;
        }

        private static bool ContinueRename(List<string> files)
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

        private static List<string> ExtensionFilter()
        {
            Console.WriteLine("Qual extensões devem ser renomeadas(Separar por vírgula)?Deixe em branco para renomear todas");
            var extensions = Console.ReadLine();

            var extensionsToRename = extensions.Split(",");

            List<string> extensionRename = new List<string>();

            foreach (var extRename in extensionsToRename)
            {
                if (extRename.Length > 0) extensionRename.Add(extRename.ToLower().Trim());
            }

            return extensionRename;
        }

        private static bool checkIfListIsEmpty(List<string> extensionRename)
        {
            if (!extensionRename.Any())
            {
                return true;
            }
            return false;
        }

        public static void BulkRenamer(string path, string baseName)
        {
            int counter = 0;

            List<string> files = new List<string>(ReturnFiles(path));

            var extensionsRename = ExtensionFilter();

            if (checkIfListIsEmpty(extensionsRename))
            {
                Console.WriteLine("A lista está vazia... Todas as extensões serão renomeadas");
            }
            else
            {
                Console.WriteLine("As seguintes extensões serão renomeadas:");
                extensionsRename.ForEach(ext => Console.WriteLine(ext));
            }

            //TODO: Realizar a operação para cancelar a renomeação, caso seja falso
            if (ContinueRename(files))
            {
                Console.WriteLine("Continuará");
            }

            foreach (var file in files)
            {
                Console.WriteLine($"{file} --- {counter:D4}");
                counter++;
                //TODO: Realizar a renomeação

                /*
                * Path.GetExtension(file) retorna a extensão -- Path possui métodos estáticos para trabalhar com os nomes dos arquivos
                */
            }
        }
    }
}