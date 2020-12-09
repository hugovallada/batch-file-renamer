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

        public static void openTerminal(string path)
        {
            Console.WriteLine(RuntimeInformation.IsOSPlatform(OSPlatform.Linux));
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = path,
                    FileName = "xdg-open"
                }
            };

            process.Start();

            process.WaitForExit();




        }

        public static void RenameFiles(string path, string baseName)
        {
            int counter = 0000;
            string[] extensionsToRename;

            List<string> files = new List<string>(ReturnFiles(path));

            Console.WriteLine("Qual extensões devem ser renomeadas? Deixe em branco para renomear todas");
            var extensions = Console.ReadLine();

            extensionsToRename = extensions.Split(",");



            List<string> extensionRename = new List<string>();

            foreach (var extRename in extensionsToRename)
            {
                if (extRename.Length > 0) extensionRename.Add(extRename.ToLower().Trim());
            }


            if (!extensionRename.Any())
            {
                //TODO: Realizar o exclude das extensões que não façam parte do rename
                Console.WriteLine("Lista Vazia, Todas as extensões serão renomeadas");
            }
            else
            {
                Console.WriteLine("A Lista possui extensões: As seguintes serão renomeadas");
                extensionRename.ForEach(ext => Console.WriteLine(ext));
            }




            //TODO: Realizar a operação para cancelar a renomeação, caso seja falso
            if (ContinueRename(files))
            {
                Console.WriteLine("Continuará");
            }

            foreach (var file in files)
            {
                Console.WriteLine($"{file} --- {counter}");
                counter++;
                //TODO: Realizar a renomeação

                /*
                * Path.GetExtension(file) retorna a extensão -- Path possui métodos estáticos para trabalhar com os nomes dos arquivos
                */
            }

            openTerminal(path);
        }
    }
}