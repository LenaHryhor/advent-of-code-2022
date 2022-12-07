using System;

namespace Advent_of_code_2022
{
    internal class Day7
    {
        private static string GetCdDirection(string str) => str.Split(' ')[2];

        public class Directory
        {
            public string Name;
            public ulong Size;
            public List<Directory> Directories;
            public Directory Parent;

            public Directory(string name, Directory parent)
            {
                Name = name;
                Size = 0;
                Directories = new();
                Parent = parent;
            }

            public Directory GetDirectory(string name)
            {
                return Name == name? this : Directories.Find(d => d.Name == name);
            }

            public void AddFile(ulong size)
            {
                Size += size;
            }

            public void AddDirectory(Directory d)
            {
                Directories.Add(d);
            }
        }

        private List<ulong> FindedDirectories = new();

        private void CountDirectories(Directory dir)
        {
            foreach (var item in dir.Directories)
            {
                CountDirectories(item);
            }
            
            if (dir.Size < 100000)
                FindedDirectories.Add(dir.Size);
        }

        public void Run()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\dev\\advent-of-code-2022\\Advent of code 2022\\day7\\day7.txt");
                String line = sr.ReadLine();
                int res = 0;

                Directory root = new Directory("/", null);
                Directory currentDir = root;

                bool isReadingElements = false;
                while (line != null)
                {
                    if (line.Contains("cd"))
                    {
                        var direction = GetCdDirection(line);
                        if (direction == "..")
                        {
                            currentDir = currentDir.Parent;
                        }
                        else
                            currentDir = currentDir.GetDirectory(direction);

                        isReadingElements = false;
                    }
                    else if (line.Contains("ls"))
                    {
                        isReadingElements = true;
                    }
                    else if (line.Contains("dir"))
                        currentDir.AddDirectory(new Directory(line.Split(' ')[1], currentDir));
                    else
                    {
                        var list = line.Split(' ');
                        currentDir.AddFile(ulong.Parse(list[0]));
                    }

                    line = sr.ReadLine();
                }

                sr.Close();
                    
                CountDirectories(root);
                foreach (var item in FindedDirectories)
                    Console.WriteLine($"Result: {item}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}