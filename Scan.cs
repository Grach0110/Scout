using System;
using System.IO;

namespace Scout
{
    /// <summary>
    /// Сканирование дисков
    /// </summary>
    public class Scan
    {
        /// <summary>
        /// OS Windows
        /// </summary>
        public static string windows_OS = @"C:\";

        /// <summary>
        /// Текущая ОС
        /// </summary>
        public static string current_Os;

        /// <summary>
        /// Определение ОС
        /// </summary>
        public static void The_definition_of_OS()
        {
            Console.WriteLine("Определение ОС || The definition of OS: ...");
            Console.WriteLine();

            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo drive in driveInfos)
            {
                if (drive.IsReady)
                {
                    if (drive.Name.ToLower() == windows_OS.ToLower())
                    {
                        // Windows OS
                        current_Os = "Windows";

                        Console.WriteLine("ОС Windows: ...");
                        Console.WriteLine();
                        Console.WriteLine("ОС определена: ...");
                        Console.WriteLine();

                        Windows_OS.DefiningThePathForTheFlashDrive();
                        break;
                    }
                    else
                    {
                        // Other OS
                        current_Os = "Другая || Other";
                        Console.WriteLine("Другая ОС || Other OS: ...");
                        Console.WriteLine();
                        break;
                    }
                }
            }
        }
    }
}
