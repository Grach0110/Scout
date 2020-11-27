using System;
using System.IO;

namespace Scout
{
    public class Windows_OS
    {
        /// <summary>
        /// Количество дисков
        /// </summary>
        public static int countDrivers = 0;
        /// <summary>
        /// Количество папок
        /// </summary>
        public static int countFolders = 0;
        /// <summary>
        /// Количество файло
        /// </summary>
        public static int countFiles = 0;
        /// <summary>
        /// Название флешки
        /// </summary>
        public static string nameMyDriver = Program.name_USB_For_Windows; 
        /// <summary>
        /// Путь флешки
        /// </summary>
        public static string pathMyDriver;
        /// <summary>
        /// Путь до дисков (список доступных дисков в системе)
        /// </summary>
        public static string pathDrivers;
        /// <summary>
        /// Название файла для записи
        /// </summary>
        public static string nameFileForWin = pathMyDriver + "Windows_Data.txt";

        /// <summary>
        /// Определение пути для флешки
        /// </summary>
        public static void DefiningThePathForTheFlashDrive()
        {
            Console.WriteLine("Определение пути для флешки: ...");
            Console.WriteLine();

            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo drive in driveInfos)
            {
                if (drive.IsReady)
                {
                    if (drive.VolumeLabel.ToLower() == nameMyDriver.ToLower())
                    {
                        pathMyDriver = drive.Name;

                        Console.WriteLine("Путь определен: ...");
                        Console.WriteLine();
                    }
                }
            }
            Checking();
        }

        /// <summary>
        /// Проверка наличия файла
        /// </summary>
        public static void Checking()
        {
            Console.WriteLine("Создание файла для записи: ...");
            Console.WriteLine();

            StreamWriter streamWriter = new StreamWriter(pathMyDriver + nameFileForWin, false);
            streamWriter.WriteLine("ОС: " + Scan.current_Os + "\n");
            streamWriter.Close();

            Console.WriteLine("Файл создан: ...");
            Console.WriteLine();
            
            Scanning_Disks_And_Writing_To_File();
        }

        /// <summary>
        /// Сканирование дисков и запись в файл
        /// </summary>
        public static void Scanning_Disks_And_Writing_To_File()
        {
            Console.WriteLine("Сканирование дисков в системе пользователя : ...");
            Console.WriteLine();

            // Запись общее место / оставшевося места
            DriveInfo[] info = DriveInfo.GetDrives();
            foreach (DriveInfo d in info)
            {
                if (d.IsReady)
                {
                    if (d.VolumeLabel.ToLower() != nameMyDriver.ToLower())
                    {
                        if (Directory.Exists(d.Name))
                        {
                            countDrivers++;

                            StreamWriter streamWriter = new StreamWriter(pathMyDriver + nameFileForWin, true);
                            streamWriter.WriteLineAsync(d.Name + " :Имя диска \n " + d.TotalSize +
                                " Общий размер места для хранения на диске в байтах. \n "
                                + d.TotalFreeSpace + " Общий объем свободного места, доступного на диске, в байтах. \n "
                                + d.AvailableFreeSpace + " Объем доступного свободного места на диске в байтах");

                            streamWriter.WriteLineAsync("__________");
                            streamWriter.WriteLineAsync();

                            streamWriter.Close();
                        }
                    }
                }
            }

            // Запись папок и файлов
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach (DriveInfo drive in driveInfo)
            {
                if (drive.IsReady)
                {
                    if (drive.VolumeLabel.ToLower() != nameMyDriver.ToLower())
                    {
                        if (Directory.Exists(drive.Name))
                        {
                            string[] dirs = Directory.GetDirectories(drive.Name);
                            foreach (string d in dirs)
                            {
                                StreamWriter streamWriter = new StreamWriter(pathMyDriver + nameFileForWin, true);
                                streamWriter.WriteLineAsync("Папка : __________");
                                streamWriter.WriteLineAsync("");
                                streamWriter.WriteLineAsync(d);
                                streamWriter.WriteLineAsync("");
                                streamWriter.Close();
                                countFolders++;
                            }

                            string[] fils = Directory.GetFiles(drive.Name);
                            foreach (string f in fils)
                            {
                                StreamWriter streamWriter = new StreamWriter(pathMyDriver + nameFileForWin, true);
                                streamWriter.WriteLineAsync("Файл : __________");
                                streamWriter.WriteLineAsync("");
                                streamWriter.WriteLineAsync(f);
                                streamWriter.WriteLineAsync("");
                                streamWriter.Close();
                                countFiles++;
                            }
                        }
                    }
                }
            }

            StreamWriter streamWriter1 = new StreamWriter(pathMyDriver + nameFileForWin, true);
            streamWriter1.WriteLineAsync("Количество дисков: __" + countDrivers + " || " + "Количество папок: __" 
                + countFolders + " || " + "Количество файлов: __" + countFiles);

            streamWriter1.Close();

            Console.WriteLine("Сканирование дисков закончено : ...");
            Console.WriteLine();
        }
    }
}
