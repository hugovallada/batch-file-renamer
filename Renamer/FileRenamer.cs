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
            if (!files.Any())
            {
                Console.WriteLine("Nenhum arquivo com as extensões selecionadas foram encontrados no diretório.");
                return false;
            }

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

        private static bool CheckIfListIsEmpty(List<string> extensionRename)
        {
            if (!extensionRename.Any())
            {
                return true;
            }
            return false;
        }

        private static bool ExistsInList(List<string> extensionRename, string file)
        {
            var ext = Path.GetExtension(file);

            if (CheckIfListIsEmpty(extensionRename))
            {
                return true;
            }

            foreach (var extRename in extensionRename)
            {
                if (extRename == ext)
                {
                    return true;
                }
            }

            return false;
        }

        private static void RenameFile(string file, string name)
        {
            var extension = Path.GetExtension(file);
            var rootPath = Directory.GetParent(file);
            var newPath = String.Format($"{rootPath}/{name}{extension}");

            File.Move(file, newPath);
        }

        private static List<string> FileFilter(List<string> files, List<string> extensionRename)
        {
            List<string> filteredFiles = new List<string>();

            files.ForEach(file =>
            {
                if (ExistsInList(extensionRename, file))
                {
                    filteredFiles.Add(file);
                }
            });

            return filteredFiles;
        }

        public static void BulkRenamer(string path, string baseName)
        {
            int counter = 0;

            List<string> files = new List<string>(ReturnFiles(path));

            var extensionsRename = ExtensionFilter();

            var filesToRename = FileFilter(files, extensionsRename);


            var continueRename = ContinueRename(filesToRename);

            if (continueRename)
            {
                filesToRename.ForEach(file =>
                {
                    String name = "";

                    if (baseName.Trim().Length > 0)
                    {
                        name = $"{counter:D4}-{baseName}";
                    }
                    else
                    {
                        name = $"{counter:D4}";
                    }

                    RenameFile(file, name);

                    counter++;
                });
            }
            else
            {
                Console.WriteLine("Renomeação cancelada");
            }
        }

        public static void SingleRenamer(string path, string newName)
        {
            RenameFile(path, newName);
            //TODO: Adicionar opção de abrir o file explorer
        }
    }
}