using System;

namespace Scout
{
    public class Program
    {
        // Название USB должно быть TriTon

        /// <summary>
        /// Название USB
        /// </summary>
        public static string name_USB_For_Windows = @"TriTon";
        /// <summary>
        /// Имя программы для копирования
        /// </summary>
        public static string name_Of_The_Program_To_Copy = "ConsoleApp.exe";

        private static void Main(string[] args)
        {
            Console.WriteLine("'Разведчик' начал работу || The 'Scout' started working: ...");
            Console.WriteLine();
            
            Scan.The_definition_of_OS();

            //AddApp.CopyApp();

            Console.WriteLine("'Разведчик' закончил работу || The 'Scout' finished his work: ...");
            //Console.ReadLine();
        }
    }
}
// Добавить запись всех папок и подпапок + файлы в них