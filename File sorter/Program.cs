using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("// The file sorter version 0.1 (Light) by AlexeyUmka \\");

            Console.Write("Enter the path to the folder for sorting files : ");
            string path = Console.ReadLine();
            // Проверяем на существование введённый пользователем путь
            if (Directory.Exists(path)) 
            {
                Console.WriteLine("Start scanning...");
                // Получаем данные о файлах в строковой массив files
                string[] files = Directory.GetFiles(path);
                // Проверка на наличие файлов для сортировки
                if (files.Length > 0)
                {
                    // Обрабатываем каждый элемент массива
                    for (int i = 0; i < files.Length; i++)
                    {
                        // Создание экземпляра класса FileInfo для манипуляций с выбраным файлом
                        FileInfo file = new FileInfo(files[i]);
                        string extension = file.Extension;
                        string PathFiles = path + "Fs" + extension;
                        // Создание экземпляра класса FileInfo для проверки на существование копии данного файла 
                        FileInfo FileVerifyne = new FileInfo(PathFiles + @"\" + file.Name);
                        if (file.Exists)
                        {
                            if (Directory.Exists(PathFiles))
                            {
                                if (!FileVerifyne.Exists)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    file.MoveTo(PathFiles + @"\" + file.Name);
                                    Console.WriteLine("Completed - File {0} moved to folder {1}", file.Name, PathFiles + @"\");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error - File {0} already exist in folder {1}", file.Name, PathFiles + @"\");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Directory.CreateDirectory(PathFiles);
                                Console.WriteLine("Completed - Folder with name {0} successfully created", "Fs" + extension);
                                file.MoveTo(PathFiles + @"\" + file.Name);
                                Console.WriteLine("Completed - File {0} moved to folder {1}", file.Name, PathFiles + @"\");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error - File not exist {0}", files[i]);
                            Console.ResetColor();
                        }
                        file = null;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No files found for sorting!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("folder in the specified path does not exist");
                Console.ResetColor();
            }
            Console.Write("Press any button to exit the program : ");
            Console.ReadKey();
            
        }
    }
}
