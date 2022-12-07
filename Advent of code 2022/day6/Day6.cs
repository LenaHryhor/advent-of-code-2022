using System;

namespace Advent_of_code_2022
{
    internal static class Day6
    {
        private static bool HasDifferentLetters(string str)
        {
            var additionalStr = "";
            for(int i = 0; i < str.Length; i++)
            {
                if (additionalStr.Contains(str[i]))
                    return false;
                else additionalStr += str[i];
            }
            return true;
        }
        public static void Run()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\dev\\advent-of-code-2022\\Advent of code 2022\\day6\\day6.txt");
                String line = sr.ReadLine();
                int res = 0;
                while (line != null)
                {
                    for(int i = 13; i < line.Length; i++)
                    {
                        var subStr = line.Substring(i - 13, 14);
                        if (HasDifferentLetters(subStr))
                        {
                            res = i + 1;
                            break;
                        }
                    }

                    line = sr.ReadLine();
                }
                sr.Close();

                Console.WriteLine($"Result: {res}"); 
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
