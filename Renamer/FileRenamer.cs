using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
                throw new Exception("Nenhum arquivo encontrado.Confirme o caminho digitado");
            }

            Console.WriteLine("Os seguintes arquivos serão renomeados: ");
            files.ForEach(file => Console.WriteLine(file));
            
            Console.WriteLine("\nDeseja continuar?(y/N)");
            var continuar = Console.ReadLine();
            Console.WriteLine();

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

        //REVIEW: Precisa ser testado no Mac e no Windows
        private static void OpenExplorerOS(string path)
        {
            if (!OpenExplorerInquirer()) return;

            // Checa se o sistema é linux
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                OpenExplorer(path, "xdg-open");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                OpenExplorer(path, "open");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                OpenExplorer(path, "explorer");
            }
            else
            {
                Console.WriteLine("Não foi possível abrir o explorer");
            }

        }

        private static void OpenExplorer(string path, string cmd)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = path,
                    FileName = cmd
                }
            };

            process.Start();

            process.WaitForExit();
        }

        private static bool OpenExplorerInquirer()
        {
            Console.WriteLine("Deseja abrir o explorer no diretório do(s) arquivo(s) renomeado(s) ? (y/N)");
            var option = Console.ReadLine().ToLower();

            if (option == "y" || option == "yes") return true;

            return false;

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

                OpenExplorerOS(path);
            }
            else
            {
                Console.WriteLine("Renomeação cancelada");
            }
        }

        public static void SingleRenamer(string path, string newFileName)
        {
            RenameFile(path, newFileName);
            OpenExplorerOS(path);
        }
    }
}