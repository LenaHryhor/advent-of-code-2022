using System;

namespace Advent_of_code_2022.day3
{
    internal static class Day3
    {
        // a through z : 1 through 26.
        // A through Z : 27 through 52.

        private static int GetPriorityChar(char item) => Char.IsLower(item) ? item - 'a' + 1 : item - 'A' + 1 + 27;

        public static void Run()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\dev\\advent-of-code-2022\\Advent of code 2022\\day3\\day3.txt");
                String line = "";

                int sum = 0;
                int checker = 0;
                List<string> list = new List<string>();
                while (line != null)
                {
                    line = sr.ReadLine();
                    list.Add(line);
                    
                    if (checker == 3)
                    {
                        var firstDiff = list[0].Intersect(list[1]);
                        var res = firstDiff.Intersect(list[2]).Distinct().First();

                        sum += GetPriorityChar(res);

                        checker = 0;
                        list.Clear();
                    }

                    checker++;
                }
                sr.Close();


                var res1 = list[0].Intersect(list[1]).ToList().Intersect(list[2]).Distinct().First();

                sum += GetPriorityChar(res1);

                Console.WriteLine(sum);

                //part 1
                Console.WriteLine($"Total part1: {sum}");

                //part 2
                //Console.WriteLine($"Total part2: {sumPart2}");
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
