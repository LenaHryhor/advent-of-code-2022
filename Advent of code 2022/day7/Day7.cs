using System;

namespace Advent_of_code_2022
{
    internal class Day7
    {
        private static string GetCdDirection(string str) => str.Split(' ')[2];

        public abstract class Element
        {
            public string Name;
            public ulong Size;
            public abstract void Add(Element e);
        }

        public class Directory : Element
        {

            public List<Element> Directories;
            public List<Element> Files;

            public Directory(string name)
            {
                Name = name;
                Size = 0;
                Directories = new List<Element>();
                Files = new List<Element>();
            }

            public override void Add(Element e)
            {
                if (e is Files)
                {
                    Files.Add(e);
                    Size += e.Size;
                }
                else
                    Directories.Add(e);
            }
        }

        public class Files : Element
        {
            public Files(string name, ulong size)
            {
                Name = name;
                Size = size;
            }
            public override void Add(Element e)
            {
            }
        }
        public static void Run()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\dev\\advent-of-code-2022\\Advent of code 2022\\day7\\day7.txt");
                String line = sr.ReadLine();
                int res = 0;

                List<Element> elements = new();
                Element root = new Directory("/");
                elements.Add(root);

                int currentDirIndex = 0;

                bool isReadingElements = false;
                while (line != null)
                {
                    if (line.Contains("cd"))
                    {
                        var direction = GetCdDirection(line);
                        if (direction == "..")
                        {
                            currentDirIndex = elements.Count - 1;
                        }
                        else
                            currentDirIndex = elements.IndexOf(elements.Find(e => e.Name == direction));

                        isReadingElements = false;
                        
                    }
                    else if (line.Contains("ls"))
                    {
                        isReadingElements = true;
                       
                    }
                    else if (line.Contains("dir"))
                        elements[currentDirIndex].Add(new Directory(line.Split(' ')[1]));
                    else
                    {
                        var list = line.Split(' ');
                        elements[currentDirIndex].Add(new Files(list[1], ulong.Parse(list[0])));
                    }

                    line = sr.ReadLine();
                }
                sr.Close();

                foreach (var item in elements)
                    Console.WriteLine($"Result: {item.Size}");
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
