using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2022.day1
{
    internal static class Day1
    {
        private static int FindMaxValue(int exeptFirst = -1, int exeptSecond = -1)
        {
            StreamReader sr = new StreamReader("C:\\dev\\advent-of-code-2022\\Advent of code 2022\\day1\\day1.txt");

            String line = sr.ReadLine();
            var maxValue = 0;
            var sum = 0;

            while (line != null)
            {
                if (int.TryParse(line, out int number))
                {
                    sum += number;
                }
                else
                {
                    if (sum > maxValue && sum != exeptFirst && sum != exeptSecond)
                        maxValue = sum;
                    sum = 0;
                }

                line = sr.ReadLine();
            }

            sr.Close();
            return maxValue;

        }

        //part 1:  Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?
        //part 2:  Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
        public static void Run()
        {
            try
            {
                //part 1
                Console.WriteLine($"Total calories: {FindMaxValue()}");

                //part 2
                var firstCal = FindMaxValue();
                var secondCal = FindMaxValue(firstCal);
                var thirdCal = FindMaxValue(firstCal, secondCal);
                Console.WriteLine($"Total top three: {firstCal + secondCal + thirdCal}");

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
