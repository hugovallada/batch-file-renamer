using System;
using System.IO;
namespace batch_file_renamer.Renamer
{
    public class FileRenamer
    {
        private static string[] ShowFiles(string path)
        {
            string[] files = Directory.GetFiles(path);

            return files;
        }

        public static void RenameFiles(string path, string baseName)
        {
            int counter = 0000;

            string[] files = ShowFiles(path);

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