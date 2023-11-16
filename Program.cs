using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentPath = "";
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();

                if (currentPath == "")
                {
                    Console.WriteLine("Drive Selection:");
                    string[] drives = Directory.GetLogicalDrives();
                    for (int i = 0; i < drives.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.WriteLine($"> {drives[i]}");
                        }
                        else
                        {
                            Console.WriteLine($"  {drives[i]}");
                        }
                    }

                    Console.WriteLine("Enter Q to quit.");
                }
                else
                {
                    Console.WriteLine($"Current Path: {currentPath}");
                    Console.WriteLine();

                    string[] directories = Directory.GetDirectories(currentPath);
                    string[] files = Directory.GetFiles(currentPath);

                    for (int i = 0; i < directories.Length; i++)
                    {
                        string dirName = Path.GetFileName(directories[i]);
                        string creationDate = Directory.GetCreationTime(directories[i]).ToString();
                        if (i == selectedIndex)
                        {
                            Console.WriteLine($"> {dirName} [DIR]        Created: {creationDate}");
                        }
                        else
                        {
                            Console.WriteLine($"  {dirName} [DIR]        Created: {creationDate}");
                        }
                    }

                    for (int i = 0; i < files.Length; i++)
                    {
                        string fileName = Path.GetFileName(files[i]);
                        string fileExtension = Path.GetExtension(files[i]);
                        string creationDate = File.GetCreationTime(files[i]).ToString();
                        if (i + directories.Length == selectedIndex)
                        {
                            Console.WriteLine($"> {fileName}        Extension: {fileExtension}        Created: {creationDate}");
                        }
                        else
                        {
                            Console.WriteLine($"  {fileName}        Extension: {fileExtension}        Created: {creationDate}");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Enter 0 to go up, R to refresh, or Q to quit.");
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();

                if (keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.R)
                {
                    continue;
                }

                if (currentPath == "")
                {
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = Math.Min(selectedIndex + 1, Directory.GetLogicalDrives().Length - 1);
                    }
                    else if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = Math.Max(selectedIndex - 1, 0);
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        string[] drives = Directory.GetLogicalDrives();
                        currentPath = drives[selectedIndex];
                    }
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad0)
                    {
                        currentPath = Directory.GetParent(currentPath)?.FullName ?? "";
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = Math.Min(selectedIndex + 1, Directory.GetDirectories(currentPath).Length + Directory.GetFiles(currentPath).Length - 1);
                    }
                    else if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = Math.Max(selectedIndex - 1, 0);
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        string[] directories = Directory.GetDirectories(currentPath);
                        string[] files = Directory.GetFiles(currentPath);
                        if (selectedIndex < directories.Length)
                        {
                            currentPath = directories[selectedIndex];
                        }
                        else if (selectedIndex < directories.Length + files.Length)
                        {
                            string fileName = files[selectedIndex - directories.Length];
                            string extension = Path.GetExtension(fileName);

                            if (extension == ".txt")
                            {
                                Process.Start("notepad.exe", fileName);
                                Console.WriteLine($"Opening file: {fileName} in Notepad");
                            }
                            else if (extension == ".docx")
                            {
                                Process.Start("winword.exe", fileName);
                                Console.WriteLine($"Opening file: {fileName} in Word");
                            }
                            else
                            {
                                Console.WriteLine($"Unsupported file type: {extension}");
                            }
                        }
                    }
                }

            }
        }
    }
}
