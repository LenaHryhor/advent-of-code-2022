namespace Advent_of_code_2022
{
    internal class Day7
    {
        private static ulong __TotalSum = 0; // part 1
        private static ulong __SmallestDirForDelete = 0; // part 2
        private static ulong __NeedToDelete = 0; // part 2
        private static readonly ulong TOTAL_DISK_SPACE = 70000000;
        private static readonly ulong MIN_NEEDED_SPACE = 30000000;

        public class Directory
        {
            public string Name;
            public ulong FilesSize;
            public ulong DirectorySize;
            public List<Directory> Directories;
            public Directory Parent;

            public Directory(string name, Directory parent)
            {
                Name = name;
                FilesSize = 0;
                DirectorySize = 0;
                Directories = new();
                Parent = parent;
            }

            public void AddFile(ulong size) =>
                FilesSize += size;
        }

        public void Run()
        {
            try
            {
                var sr = new StreamReader("C:\\WorkFolder\\advent-of-code-2022\\Advent of code 2022\\day7\\day7.txt");
                var line = sr.ReadLine();

                Directory root = new Directory("/", null);
                Directory currentDir = root;

                while (line != null)
                {
                    if (line.Contains("$"))
                    {
                        var list = line.Split(' ');

                        if (list[1] is not "ls" && list[2] is not "/") // cd & not root
                            currentDir = list[2] is ".."
                                ? currentDir.Parent
                                : currentDir.Directories.Find(n => n.Name == list[2]);

                        line = sr.ReadLine();
                        continue;
                    }

                    if (line.Contains("dir"))
                        currentDir.Directories.Add(new Directory(line.Split(' ')[1], currentDir));
                    else
                        currentDir.AddFile(ulong.Parse(line.Split(' ')[0]));

                    line = sr.ReadLine();
                }

                sr.Close();

                CalculateDirectorySize(root);
                //Print(root, 0);

                //first part
                //FindDirectoriesFirstPart(root);

                //second part
                __NeedToDelete = root.DirectorySize - (TOTAL_DISK_SPACE - MIN_NEEDED_SPACE);
                __SmallestDirForDelete = root.DirectorySize;
                FindDirectoriesSecondPart(root);
                
                Console.WriteLine($"Total: {__SmallestDirForDelete}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private void FindDirectoriesSecondPart(Directory dir)
        {
            if (dir.DirectorySize > __NeedToDelete && dir.DirectorySize < __SmallestDirForDelete)
                __SmallestDirForDelete = dir.DirectorySize;

            foreach (var d in dir.Directories)
                FindDirectoriesSecondPart(d);
        }
        
        private void FindDirectoriesFirstPart(Directory dir)
        {
            if (dir.DirectorySize < 100000) 
                __TotalSum += dir.DirectorySize;

            foreach (var d in dir.Directories)
                FindDirectoriesFirstPart(d);
        }

        private ulong CalculateDirectorySize(Directory dir)
        {
            dir.DirectorySize += dir.FilesSize;

            foreach (var d in dir.Directories)
                dir.DirectorySize += CalculateDirectorySize(d);

            return dir.DirectorySize;
        }

        private void Print(Directory dir, int depth)
        {
            string _depthStr = new string('-', depth);
            Console.WriteLine(_depthStr + dir.Name);
            Console.WriteLine($"{_depthStr}FilesSize: {dir.FilesSize}");
            Console.WriteLine($"{_depthStr}DirectorySize: {dir.DirectorySize}");

            if (dir.Directories.Count == 0)
                return;

            depth += 1;
            foreach (var d in dir.Directories)
                Print(d, depth);
        }
    }
}